namespace SimpleCoroutines;

/// <summary>
/// Waits for the next frame.
/// </summary>
public struct WaitForNextFrame : IYieldInstruction
{
    /// <inheritdoc />
    public bool Step(float deltaTime)
    {
        return true;
    }
}