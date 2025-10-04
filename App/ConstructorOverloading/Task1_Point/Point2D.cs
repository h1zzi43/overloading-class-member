// Задача: Перегрузка конструкторов — Point2D
// Реализуйте класс Point2D с несколькими конструкторами согласно README.

using System.Text.RegularExpressions;

namespace App.ConstructorOverloading.Task1_Point;

public class Point2D
{
    private int x;
    private int y;

    public Point2D()
    {
        x = 0;
        y = 0;
    }

    public Point2D(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point2D(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            throw new FormatException("Invalid string format");

        var match = Regex.Match(str.Trim(), @"^\s*(-?\d+)\s*;\s*(-?\d+)\s*$");

        if (!match.Success)
            throw new FormatException("Invalid string format");

        x = int.Parse(match.Groups[1].Value);
        y = int.Parse(match.Groups[2].Value);
    }

    public Point2D(Point2D other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        x = other.x;
        y = other.y;
    }

    public int X
    {
        get => x;
        set => x = value;
    }

    public int Y
    {
        get => y;
        set => y = value;
    }
}