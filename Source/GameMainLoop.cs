#nullable enable
using Microsoft.Xna.Framework;
using MonoGame3D.Include;

namespace MonoGame3D.Source;

public class GameMainLoop : MonogameGraphics
{

    public GameMainLoop()
    : base(800, 600, "MonoGame Window") { }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
    }

    protected override void Draw(GameTime gameTime)
    {

        SetScreenColor(Color.Black);

        DrawTriangle();

        base.Draw(gameTime);
    }

    protected override void Update(GameTime gameTime)
    {
        CloseWindowHandler();
        base.Update(gameTime);
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }
}
