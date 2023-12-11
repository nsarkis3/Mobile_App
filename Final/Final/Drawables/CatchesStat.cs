using System;
using Microsoft.Maui.Graphics;

namespace Final.Drawabels;

public class CatchesStat : IDrawable
{
    private Color[] colors = { Colors.Gold, Colors.Silver, Colors.Magenta, Colors.Cyan, Colors.Green };
    public List<Player> players { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float W = dirtyRect.Width;
        float H = dirtyRect.Height;

        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 3;
        canvas.DrawRectangle(0, 0, W, H);

        float widthPerDatum = W / 5;
        int[] data = { 0, 0, 0, 0, 0};
        for (int i = 0; i < players.Count; i++) data[i] = players[i].Catches;
        int maxData = data.Max();

        float leftOfDatum = 0;
        for (int i = 0; i < 5; i++)
        {
            const float BarPercOfInterval = 0.9f;
            const float EmptyPercOfInterval = 1.0f - BarPercOfInterval;
            canvas.FillColor = colors[i % colors.Length];
            float barWidth = widthPerDatum * BarPercOfInterval;
            float barHeight = (float)players[i].Catches / maxData * H;
            float barLeft = leftOfDatum + EmptyPercOfInterval / 2 * widthPerDatum;
            float barTop = H - barHeight;
            canvas.FillRectangle(barLeft, barTop, barWidth, barHeight);
            canvas.FontColor = Colors.Black;
            canvas.FontSize = 14;
            leftOfDatum += widthPerDatum;
            canvas.DrawString(players[i].Catches.ToString(), barLeft, H - 20, barWidth, 20, HorizontalAlignment.Center, VerticalAlignment.Center);
        }
    }
}
