using System;

namespace SimpleCoroutines;

/// <summary>
/// Represents a yield instruction to wait until a condition is met.
/// </summary>
public struct WaitUntil : IYieldInstruction
{
    private readonly Func<bool> _condition;

    public WaitUntil(Func<bool> condition)
    {
        _condition = condition;
    }

    /// <inheritdoc />
    public bool Step(float deltaTime)
    {
        return _condition();
    }
}