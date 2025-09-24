using System;
using System.Collections;
using System.Collections.Generic;
using FlaxEngine;

namespace SimpleCoroutines;

/// <summary>
/// SimpleCoroutine class.
/// </summary>
public static class SimpleCoroutine
{
    private static CoroutineSystem _system;

    internal static void Initialize(CoroutineSystem coroutineSystem)
    {
        _system = coroutineSystem;
    }

    internal static void DeInitialize()
    {
        _system = null;
    }
    
    /// <summary>
    /// Starts a new coroutine.
    /// </summary>
    /// <param name="coroutine">The IEnumerator to start.</param>
    /// <param name="owner">The owner of the coroutine. Generally a script or an actor.</param>
    public static void StartCoroutine(IEnumerator coroutine, object owner)
    {
        _system.StartCoroutine(coroutine, owner);
    }
    
    /// <summary>
    /// Stops the given coroutine.
    /// </summary>
    /// <param name="coroutine">The coroutine to stop.</param>
    public static void StopCoroutine(IEnumerator coroutine)
    {
        _system.StopCoroutine(coroutine);
    }

    /// <summary>
    /// Stops all active coroutines.
    /// </summary>
    public static void StopAllCoroutines()
    {
        _system.StopAllCoroutines();
    }

    /// <summary>
    /// Removes all coroutines owned by the given object.
    /// </summary>
    /// <param name="owner">The owning object.</param>
    public static void StopAllObjectCoroutines(object owner)
    {
        _system.StopAllObjectCoroutines(owner);
    }
    
    /// <summary>
    /// Whether there are any active coroutines.
    /// </summary>
    public static bool HasCoroutines()
    {
        return _system.HasCoroutines();
    }
}
