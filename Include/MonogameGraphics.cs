#nullable enable
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame3D.Include;

// Super classe responsavel em lidar com a abstração da parte grafica.
public abstract partial class MonogameGraphics : Game
{
    private GraphicsDeviceManager _graphics;

    // Construtor precisa ser chamador para executar os graficos
    protected MonogameGraphics(int screenWidth, int screenHeight, string? screenTitle)
    {
        _graphics = new GraphicsDeviceManager(this)
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
        _graphics.IsFullScreen = fullScreen;
        _graphics.ApplyChanges();
    }

    public void SetScreenColor(Color screenColor)
    {
        GraphicsDevice.Clear(screenColor);
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
            SetFullScreen(false);
            CloseWindow();
        }
        _previousKeyboardState = currentState;
    }
}

partial class MonogameGraphics
{
    public void DrawTriangle()
    {
        VertexPositionColor[] vertices =
        {
            new( new Vector3(0, 0.5f, 0), Color.Red),

            new( new Vector3(0.5f, -0.5f, 0), Color.Green),

            new( new Vector3(-0.5f, -0.5f, 0), Color.Blue)
        };

        VertexBuffer vertexBuffer = new(
            GraphicsDevice,
            typeof(VertexPositionColor),
            vertices.Length,
            BufferUsage.None
        );


        BasicEffect effect = new(GraphicsDevice)
        {
            VertexColorEnabled = true
        };

        GraphicsDevice.SetVertexBuffer(vertexBuffer);

        foreach (var pass in effect.CurrentTechnique.Passes)
        {
            pass.Apply();

            GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
        }

        vertexBuffer.SetData(vertices);
    }
}


