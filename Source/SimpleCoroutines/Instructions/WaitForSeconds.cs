using FlaxEngine;

namespace SimpleCoroutines;

/// <summary>
/// A class that represents a yield instruction to wait for a specific number of seconds.
/// </summary>
public struct WaitForSeconds : IYieldInstruction
{
    private float _secondsRemaining;
    private bool _timeScaleIndependent;

    public WaitForSeconds(float seconds, bool timeScaleIndependent = false)
    {
        _secondsRemaining = seconds;
        _timeScaleIndependent = timeScaleIndependent;
    }

    /// <inheritdoc />
    public bool Step(float deltaTime)
    {
        _secondsRemaining -= _timeScaleIndependent ? Time.UnscaledDeltaTime : deltaTime;
        // Return true if the remaining time is zero or less.
        return _secondsRemaining <= 0;
    }
}