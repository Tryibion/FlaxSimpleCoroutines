namespace SimpleCoroutines;

/// <summary>
/// The interface for all yield instructions.
/// </summary>
public interface IYieldInstruction
{
    /// <summary>
    /// How to step the instruction. Responsible for determining if the instruction is finished.
    /// </summary>
    /// <param name="deltaTime">Time.DeltaTime</param>
    /// <returns>Returns true if the instruction is complete, false otherwise.</returns>
    public bool Step(float deltaTime);
}