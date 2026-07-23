using Microsoft.Xna.Framework;

namespace Include.Window;

public class WindowManager(GraphicsDeviceManager graphics)
{
    private readonly GraphicsDeviceManager _graphics = graphics;

    public void SetFullscreen(bool enabled)
    {
        _graphics.IsFullScreen = enabled;
        _graphics.ApplyChanges();
    }
}
