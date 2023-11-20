using Microsoft.Maui.Graphics;
using System;
using Microsoft.Maui.Graphics;
namespace Graphics.Drawables;

public class PrimitivesDrawable : IDrawable {

    public void Draw(ICanvas canvas, RectF dirtyRect) {
        float W = dirtyRect.Width;
        float H = dirtyRect.Height;

        canvas.StrokeColor = Colors.Blue;
        canvas.StrokeSize = 5;
        canvas.DrawRectangle(0, 0, W, H);

        canvas.FontColor = Colors.Blue;
        canvas.FontSize = 18;

        canvas.Font = new Microsoft.Maui.Graphics.Font("Arial");
        canvas.DrawString("Hello world!", 10,  10, W - 20, 50, HorizontalAlignment.Left, VerticalAlignment.Top);
        canvas.DrawString("Hello world!", 10,  60, W - 20, 50, HorizontalAlignment.Center, VerticalAlignment.Center);
        canvas.DrawString("Hello world!", 10, 110, W - 20, 50, HorizontalAlignment.Right, VerticalAlignment.Bottom);

        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 1;
        canvas.DrawRectangle(10,  10, W - 20, 50);
        canvas.DrawRectangle(10,  60, W - 20, 50);
        canvas.DrawRectangle(10, 110, W - 20, 50);
    }
}