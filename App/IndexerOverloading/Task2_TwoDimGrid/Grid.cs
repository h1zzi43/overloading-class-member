using System;

namespace App.IndexerOverloading.Task2_TwoDimGrid
{
    // Если в требованиях указано Cell, создаем структуру Cell
    public struct Cell
    {
        public int Row { get; }
        public int Column { get; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }

    public class Grid<T>
    {
        private readonly T[,] _grid;
        private readonly int _rows;
        private readonly int _cols;

        public Grid(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Grid dimensions must be positive");

            _rows = rows;
            _cols = cols;
            _grid = new T[rows, cols];
        }

        // Индексатор по двум координатам: [int row, int col]
        public T this[int row, int col]
        {
            get
            {
                ValidateCoordinates(row, col);
                return _grid[row, col];
            }
            set
            {
                ValidateCoordinates(row, col);
                _grid[row, col] = value;
            }
        }

        // Индексатор по структуре Cell: [Cell cell]
        public T this[Cell cell]
        {
            get
            {
                ValidateCoordinates(cell.Row, cell.Column);
                return _grid[cell.Row, cell.Column];
            }
            set
            {
                ValidateCoordinates(cell.Row, cell.Column);
                _grid[cell.Row, cell.Column] = value;
            }
        }

        // Индексатор по одномерному индексу: [int index]
        public T this[int index]
        {
            get
            {
                var (row, col) = ConvertIndexToCoordinates(index);
                ValidateCoordinates(row, col);
                return _grid[row, col];
            }
            set
            {
                var (row, col) = ConvertIndexToCoordinates(index);
                ValidateCoordinates(row, col);
                _grid[row, col] = value;
            }
        }

        // Преобразование одномерного индекса в координаты
        private (int row, int col) ConvertIndexToCoordinates(int index)
        {
            if (index < 0 || index >= _rows * _cols)
                throw new IndexOutOfRangeException($"Index {index} is out of range for grid size {_rows}x{_cols}");

            int row = index / _cols;
            int col = index % _cols;
            return (row, col);
        }

        // Проверка границ
        private void ValidateCoordinates(int row, int col)
        {
            if (row < 0 || row >= _rows || col < 0 || col >= _cols)
                throw new IndexOutOfRangeException($"Coordinates ({row}, {col}) are out of range for grid size {_rows}x{_cols}");
        }

        public int Rows => _rows;
        public int Cols => _cols;
        public int TotalSize => _rows * _cols;
    }
}