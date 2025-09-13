// Задача: Перегрузка методов — Parse
// Реализуйте несколько перегруженных методов Parse согласно README.
// Подсказки:
// - используйте int.Parse / int.TryParse
// - учитывайте культуру и NumberStyles

using System.Globalization;

namespace App.MethodOverloading.Task2_ParseOverloads;

public static class NumberParser
{
    /// Разбирает строку в int. При неверном формате должен кидать FormatException
    public static int Parse(string s)
    {
        if (s == null)
            throw new ArgumentNullException(nameof(s), "Строка не может быть null");

        s = s.Trim();

        if (string.IsNullOrEmpty(s))
            throw new FormatException("Строка не может быть пустой или содержать только пробелы");

        int startIndex = 0;
        int sign = 1;

        if (s.Length > 0)
        {
            if (s[0] == '+')
            {
                startIndex = 1;
            }
            else if (s[0] == '-')
            {
                startIndex = 1;
                sign = -1;
            }
        }

        if (startIndex >= s.Length)
            throw new FormatException("Строка должна содержать цифры после знака");

        long result = 0;

        for (int i = startIndex; i < s.Length; i++)
        {
            char c = s[i];

            if (c < '0' || c > '9')
                throw new FormatException($"Недопустимый символ '{c}' в позиции {i}");

            int digit = c - '0';
            result = result * 10 + digit;

            if (sign == 1 && result > int.MaxValue)
                throw new OverflowException("Число превышает максимальное значение int");
            if (sign == -1 && result > -(long)int.MinValue)
                throw new OverflowException("Число меньше минимального значения int");
        }

        return (int)result * sign;
    
    }

    /// Разбирает строку в int. При неверном формате возвращает defaultValue
    public static int Parse(string s, int defaultValue)
    {
        try
        {
            return Parse(s);
        }
        catch (ArgumentNullException)
        {
            return defaultValue;
        }
        catch (FormatException)
        {
            return defaultValue;
        }
        catch (OverflowException)
        {
            return defaultValue;
        }
    }

    /// Разбирает строку с учётом стиля и культуры
    /// ВАЖНО: Эта перегрузка считается дополнительной (*) повышенной сложности (работа с культурами/стилями).
    public static int Parse(string s, NumberStyles style, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }
}