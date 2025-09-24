using System;

namespace SimpleCoroutines;

/// <summary>
/// Represents a yield instruction to wait while a condition is met.
/// </summary>
public struct WaitWhile : IYieldInstruction
{
    private readonly Func<bool> _predicate;

    public WaitWhile(Func<bool> predicate)
    {
        _predicate = predicate;
    }

    /// <inheritdoc />
    public bool Step(float deltaTime)
    {
        return _predicate();
    }
}