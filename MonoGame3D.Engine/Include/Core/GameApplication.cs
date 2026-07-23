using Include.Graphics;
using Include.Window;
using Microsoft.Xna.Framework;

namespace Include.Core;

public abstract class GameApplication : Game
{
    protected readonly Renderer Renderer;
    protected readonly WindowManager WindowManager;

    private readonly GraphicsDeviceManager _graphics;

    protected GameApplication(int width, int height, string title)
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = width,
            PreferredBackBufferHeight = height
        };

        Window.Title = title;

        Content.RootDirectory = "Content";

        Renderer = new Renderer();
        WindowManager = new WindowManager(_graphics);
    }

    protected override void Draw(GameTime gameTime)
    {
        Renderer.BeginFrame(GraphicsDevice, Color.CornflowerBlue);

        base.Draw(gameTime);
    }


    /// <summary>
    /// Warning: No linux para que esse method seja chamado é preciso ter certeza que 
    /// Fullscreen = false, pois a resolução não retorna ao normal ao fechar a janela
    /// se esse modo estiver ativo.
    /// </summary>
    protected void CloseWindow()
    {
        Exit();
    }
}
