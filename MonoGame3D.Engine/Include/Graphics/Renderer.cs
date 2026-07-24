#nullable enable
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Include.Graphics;

public class Renderer
{
    private BasicEffect? _effect;


    /// <summary>
    /// Aplica os shaders no vertex
    /// </summary>
    /// <param name="device"></param>
    /// <param name="clearColor">Cor inicial que deseja desenhar na tela</param>
    public void BeginFrame(GraphicsDevice device, Color clearColor)
    {
        device.Clear(clearColor);

        _effect ??= new BasicEffect(device)
        {
            VertexColorEnabled = true
        };
    }

    public void DrawTriangle(GraphicsDevice device)
    {
        TriangleMesh mesh = new();

        VertexBuffer buffer = new(
            device,
            typeof(VertexPositionColor),
            mesh.Vertices.Length,
            BufferUsage.None);

        buffer.SetData(mesh.Vertices);

        device.SetVertexBuffer(buffer);

        foreach (EffectPass pass in _effect!.CurrentTechnique.Passes)
        {
            pass.Apply();

            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
        }
    }
}
