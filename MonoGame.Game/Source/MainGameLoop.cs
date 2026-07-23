using Microsoft.Xna.Framework;

using Include.Core;
using Microsoft.Xna.Framework.Input;

namespace MonoGame.Game.Source;

public class MainGameLoop : GameApplication
{
    public MainGameLoop() : base(800, 600, "MonoGame Application") { }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
    }


    protected override void Update(GameTime gameTime)
    {
        CloseWindowHandler();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);

        Renderer.BeginFrame(GraphicsDevice, Color.Black);
        Renderer.DrawTriangle(GraphicsDevice);
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }

    private KeyboardState _previousKeyboardState;
    /// <summary>
    /// Quando for usar o SetFullScreen() e desejar fechar o Window, esse method 
    /// deve ser usado.
    /// </summary>
    public void CloseWindowHandler()
    {
        KeyboardState currentState = Keyboard.GetState();

        if (currentState.IsKeyDown(Keys.Escape) &&
        !_previousKeyboardState.IsKeyDown(Keys.Escape))
        {
            WindowManager.SetFullscreen(false);
            CloseWindow();
        }
        _previousKeyboardState = currentState;
    }
}

