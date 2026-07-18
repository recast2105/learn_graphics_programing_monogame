#nullable enable
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.Include;

// Super classe responsavel em lidar com a abstração da parte grafica.
public abstract class MonogameGraphics : Game
{
    public GraphicsDeviceManager Graphics { get; private set; }

    // Construtor precisa ser chamador para executar os graficos
    protected MonogameGraphics(int screenWidth, int screenHeight, string? screenTitle)
    {
        Graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = screenWidth,
            PreferredBackBufferHeight = screenHeight
        };

        Window.Title = screenTitle;
        Content.RootDirectory = "Content";
    }

    /// <summary>
    /// Warning: No linux se o window estiver no modo fullscreen = true, é preciso coloca-lo no false ou a resolução quando fechar não voltara ao normal
    /// </summary>
    public void CloseWindow()
    {
        Exit();
    }

    public void SetFullScreen(bool fullScreen)
    {
        Graphics.IsFullScreen = fullScreen;
        Graphics.ApplyChanges();
    }

    public void SetScreenColor(Color screenColor)
    {
        GraphicsDevice.Clear(screenColor);
    }
}
