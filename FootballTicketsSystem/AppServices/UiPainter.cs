using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public static class UiPainter
{
    public static void DrawGradientBackground(Control control, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rectFull = control.ClientRectangle;

        using (LinearGradientBrush brush = new LinearGradientBrush(
            rectFull,
            Color.FromArgb(120, 255, 255, 255),
            Color.FromArgb(80, 204, 204, 232),
            LinearGradientMode.ForwardDiagonal))
        {
            g.FillRectangle(brush, rectFull);
        }

        int borderWidth = 3;
        Rectangle rect = new Rectangle(1, 1, control.Width - 3, control.Height - 3);

        using (LinearGradientBrush borderBrush = new LinearGradientBrush(
            rect,
            Color.FromArgb(90, 255, 200),
            Color.FromArgb(0, 200, 150),
            LinearGradientMode.Horizontal))
        using (Pen pen = new Pen(borderBrush, borderWidth))
        {
            GraphicsPath path = GetRoundedRect(rect, 20);
            g.DrawPath(pen, path);
        }
    }

    public static GraphicsPath GetRoundedRect(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
        path.CloseAllFigures();

        return path;
    }
}