using Flax.Build;

public class SimpleCoroutinesTarget : GameProjectTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for game
        Modules.Add("SimpleCoroutines");
    }
}
