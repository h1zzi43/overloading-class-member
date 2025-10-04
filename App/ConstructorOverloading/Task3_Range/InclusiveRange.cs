// Задача: Перегрузка конструкторов — InclusiveRange
// Реализуйте класс InclusiveRange согласно README. Диапазон включительный.

namespace App.ConstructorOverloading.Task3_Range;

public class InclusiveRange
{
    public int Start { get; }
    public int End { get; }

    public InclusiveRange(int start, int end)
    {
        if (start > end)
            throw new ArgumentOutOfRangeException(nameof(start), "Start cannot be greater than end");

        Start = start;
        End = end;
    }

    public InclusiveRange(int single) : this(single, single)
    {
    }

    public InclusiveRange(string range)
    {
        if (string.IsNullOrWhiteSpace(range))
            throw new FormatException("Range string cannot be null or empty");

        string[] parts = range.Split(new[] { ".." }, StringSplitOptions.None);

        if (parts.Length != 2)
            throw new FormatException("Invalid range format. Expected 'start..end'");

        if (!int.TryParse(parts[0], out int start) || !int.TryParse(parts[1], out int end))
            throw new FormatException("Start and end must be valid integers");

        if (start > end)
            throw new ArgumentOutOfRangeException(nameof(start), "Start cannot be greater than end");

        Start = start;
        End = end;
    }
}