using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Include.Graphics;

internal class TriangleMesh
{
    public VertexPositionColor[] Vertices =>
    [
        new(new Vector3(0, 0.5f, 0), Color.Red),
        new(new Vector3(0.5f, -0.5f, 0), Color.Green),
        new(new Vector3(-0.5f, -0.5f, 0), Color.Blue)
    ];
}
