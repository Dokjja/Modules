using System.Drawing.Drawing2D;

namespace Module_5._1;

class Shape
{
    public int State; // 1 - линия, 2 - прямоугольник, 3 - круг
    public Point Start;
    public Point End;
    
    public Rectangle GetBounds()
    {
        return new Rectangle(
            Math.Min(Start.X, End.X),
            Math.Min(Start.Y, End.Y),
            Math.Abs(End.X - Start.X),
            Math.Abs(End.Y - Start.Y));
    }
}

public partial class Form1 : Form
{
    private List<Shape> shapes = new List<Shape>(); // Список всех нарисованных фигу
    private Point startPoint, endPoint;     // Точки начала и конца текущей фигуры
    private float PenWidth = 3;             // Толщина пера
    private int _state = 1;                 // Текущий выбранный тип фигуры
    public Form1()
    {
        InitializeComponent();
    }
    private void Form_Paint(object sender, PaintEventArgs e)
    {
        Pen pen = new Pen(Color.Black, PenWidth);

        foreach (var shape in shapes)
        {
            switch (shape.State)
            {
                case 1:
                    e.Graphics.DrawLine(pen, shape.Start, shape.End);
                    break;
                case 2:
                    e.Graphics.DrawRectangle(pen, shape.GetBounds());
                    break;
                case 3:
                    e.Graphics.DrawEllipse(pen, shape.GetBounds());
                    break;
            }
        }

        pen.Dispose();
    }
    private void Form_MouseDown(object sender, MouseEventArgs e)
    {
        startPoint = e.Location;
    }

    private void Form_MouseUp(object sender, MouseEventArgs e)
    {
        endPoint = e.Location;
        shapes.Add(new Shape { State = _state, Start = startPoint, End = endPoint });
        Invalidate();

    }
    private void btnLine_Click(object sender, EventArgs e)
    {
        _state = 1;
    }

    private void btnRect_Click(object sender, EventArgs e)
    {
        _state = 2;
    }

    private void btnCircle_Click(object sender, EventArgs e)
    {
        _state = 3;
    }
}