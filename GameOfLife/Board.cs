using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public Cell[,] board { get; }

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            board = new Cell[rows, columns];
        }

        public Cell getCell(int row, int col)
        {
            return board[row, col];
        }

        public void setCell(int row, int col, Cell celd)
        {
            board[row, col] = celd;
        }

        public string toString()
        {
            string descripcion = "";
            descripcion += DateTime.Now + "\n";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    descripcion += board[i, j].status + ", ";
                }
            }
            return descripcion;
        }

    }
}
