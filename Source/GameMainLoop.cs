#nullable enable
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame3D.Include;

namespace MonoGame3D.Source;

public class GameMainLoop : MonogameGraphics
{

    public GameMainLoop()
    : base(800, 600, "MonoGame Window") { }

    protected override void Initialize()
    {
        SetFullScreen(true);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
    }

    protected override void Draw(GameTime gameTime)
    {
        SetScreenColor(Color.MonoGameOrange);

        base.Draw(gameTime);
    }

    private KeyboardState _previousKeyboardState;
    protected override void Update(GameTime gameTime)
    {
        HandlerCloseWindow();
        
        base.Update(gameTime);
    }

    private void HandlerCloseWindow()
    {
        KeyboardState currentState = Keyboard.GetState();

        if (currentState.IsKeyDown(Keys.Escape) &&
        !_previousKeyboardState.IsKeyDown(Keys.Escape))
        {
            SetFullScreen(false);
            CloseWindow();
        }
        _previousKeyboardState = currentState;
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }
}
