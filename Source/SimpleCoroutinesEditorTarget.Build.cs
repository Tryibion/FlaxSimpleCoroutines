using Flax.Build;

public class SimpleCoroutinesEditorTarget : GameProjectEditorTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for editor
        Modules.Add("SimpleCoroutines");
    }
}
