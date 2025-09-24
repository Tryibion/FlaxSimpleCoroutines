using System;
using System.Collections;
using System.Collections.Generic;
using FlaxEngine;

namespace SimpleCoroutines;

/// <summary>
/// CoroutineSystem GamePlugin.
/// </summary>
public class CoroutineSystem : GamePlugin
{
    // The list of active coroutine instances.
    private List<CoroutineHandle> _activeCoroutines = new List<CoroutineHandle>();
    
    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();
        SimpleCoroutine.Initialize(this);
        Scripting.Update += Update;
    }
    
    /// <summary>
    /// Starts a new coroutine.
    /// </summary>
    /// <param name="coroutine">The IEnumerator to start.</param>
    /// <param name="owner">The owner of the coroutine. Generally a script or an actor.</param>
    public void StartCoroutine(IEnumerator coroutine, object owner)
    {
        _activeCoroutines.Add(new CoroutineHandle(coroutine, owner));
    }
    
    /// <summary>
    /// Stops the given coroutine.
    /// </summary>
    /// <param name="coroutine">The coroutine to stop.</param>
    public void StopCoroutine(IEnumerator coroutine)
    {
        // Iterate backward to safely remove items from the list.
        for (int i = _activeCoroutines.Count - 1; i >= 0; i--)
        {
            if (Equals(_activeCoroutines[i].Coroutine, coroutine))
            {
                _activeCoroutines.RemoveAt(i);
                return;
            }
        }
    }

    /// <summary>
    /// Stops all active coroutines.
    /// </summary>
    public void StopAllCoroutines()
    {
        _activeCoroutines.Clear();
    }

    /// <summary>
    /// Removes all coroutines owned by the given object.
    /// </summary>
    /// <param name="owner">The owning object.</param>
    public void StopAllObjectCoroutines(object owner)
    {
        // Iterate backward to safely remove items from the list.
        for (int i = _activeCoroutines.Count - 1; i >= 0; i--)
        {
            if (Equals(_activeCoroutines[i].Owner, owner))
            {
                _activeCoroutines.RemoveAt(i);
                return;
            }
        }
    }
    
    /// <summary>
    /// Whether there are any active coroutines.
    /// </summary>
    public bool HasCoroutines()
    {
        return _activeCoroutines.Count > 0;
    }

    private void Update()
    {
        Profiler.BeginEvent("Update Coroutines");
        // Iterate backward to safely remove items from the list.
        for (int i = _activeCoroutines.Count - 1; i >= 0; i--)
        {
            var instance = _activeCoroutines[i];

            // Skip and remove if owner does not exist.
            if (instance.Owner == null)
            {
                _activeCoroutines.RemoveAt(i);
                continue;
            }

            // If coroutine is started but not at next instruction, move to next instruction.
            if (instance.Coroutine.Current == null)
            {
                if (!instance.Coroutine.MoveNext())
                    _activeCoroutines.RemoveAt(i);
            }

            // Check coroutine Step to see if can move to next instruction.
            if (instance.Coroutine.Current is IYieldInstruction instruction)
            {
                instance.CurrentInstruction = instruction;
                if (!instruction.Step(Time.DeltaTime))
                    continue;
                if (!instance.Coroutine.MoveNext())
                    _activeCoroutines.RemoveAt(i);
            }
        }
        Profiler.EndEvent();
    }

    /// <inheritdoc/>
    public override void Deinitialize()
    {
        StopAllCoroutines();
        Scripting.Update -= Update;
        SimpleCoroutine.DeInitialize();
        base.Deinitialize();
    }
}