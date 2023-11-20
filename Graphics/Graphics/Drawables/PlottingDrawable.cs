using Microsoft.Maui.Graphics;
using System;

namespace Graphics.Drawables;

public class PlottingDrawable : IDrawable {
    public string [] Labels { get; set; }
    public int[] Data { get; set; }
    private Color[] colors = {
                                Colors.Red, Colors.Green, Colors.Blue,
                                Colors.Cyan, Colors.Magenta, Colors.Yellow,
                                Colors.Gray, Colors.Orange,
                                };
    public void Draw(ICanvas canvas, RectF dirtyRect) {
        float W = dirtyRect.Width;
        float H = dirtyRect.Height;
        
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 3;
        canvas.DrawRectangle(0, 0, W, H);

        if (Data == null || Labels == null || Data.Length != Labels.Length) {
            return;
        }
        int numBars = Data.Length;

        float widthPerDatum = W / numBars;
        int maxData = Data.Max();

        float leftOfDatum = 0;
        for (int i=0; i < numBars; i++) {
            const float BarPercOfInterval = 0.9f;
            const float EmptyPercOfInterval = 1.0f - BarPercOfInterval;
            canvas.FillColor = colors[ i % colors.Length ];
            float barWidth = widthPerDatum * BarPercOfInterval;
            float barHeight = (float)Data[i] / maxData * H;
            float barLeft = leftOfDatum + EmptyPercOfInterval / 2 * widthPerDatum;
            float barTop = H - barHeight;
            canvas.FillRectangle(barLeft, barTop, barWidth, barHeight);
            canvas.FontColor = Colors.Black;
            canvas.FontSize = 12;
            canvas.DrawString(Labels[i], barLeft, H - 20, barWidth, 20,
                                HorizontalAlignment.Center, VerticalAlignment.Center);
            leftOfDatum += widthPerDatum;
        }
    }
}