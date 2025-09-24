namespace SimpleCoroutines;

/// <summary>
/// Represents a yield instruction to wait until a certain number of frames have passed.
/// </summary>
public struct WaitForFrames : IYieldInstruction
{
    private int _expectedFramesCount;
    private int _currentFrameCount;
    
    public WaitForFrames(int expectedFramesCount = 0)
    {
        _expectedFramesCount = expectedFramesCount;
        _currentFrameCount = 0;
    }
    
    /// <inheritdoc />
    public bool Step(float deltaTime)
    {
        _currentFrameCount++;
        return _currentFrameCount >= _expectedFramesCount;
    }
}