using Microsoft.Maui.Graphics;
using System;

namespace Graphics.Drawables;

public class GraphicsSample : IDrawable {
    public float Percent { get; set; }
    public void Draw(ICanvas canvas, RectF dirtyRect) {
        float W = dirtyRect.Width;
        float H = dirtyRect.Height;

        canvas.StrokeColor = Colors.Blue;
        canvas.FillColor = Colors.Red;

        canvas.FillRectangle(0, 0, W, H);

        canvas.StrokeColor = Colors.Green;
        canvas.StrokeSize = 3;

        float sqrW = W * Percent;
        float sqrH = H * Percent;
        float leftOverW = W - sqrW;
        float leftOverH = H - sqrH;
        canvas.DrawRectangle(leftOverW / 2, leftOverH / 2, sqrW, sqrH);
    }
}