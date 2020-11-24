using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GameOfLife {

    /*public class Cell
    {
        public bool status { get; set; }
        public Cell(bool status)
        {
            this.status = status;
        }
    }*/

    /*public class Board
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

        public void setCell(int row,int col, Cell celd)
        {
            board[row, col] = celd;
        }
    }*/
    
    public class Game {
        
        public static Board GameInit(Board startPoint)
        {
            Board nextBoard = new Board(startPoint.rows, startPoint.columns);
            nextBoard = NextBoard(startPoint, nextBoard);
            return nextBoard;
        }

        private static Board NextBoard(Board startPoint, Board nextBoard)
        {
            for (int i = 0; i < startPoint.rows; i++)
            {
                for (int j = 0; j < startPoint.columns; j++)
                {
                    int neighbours = CountNeighbours(startPoint, i, j);
                    UpdateCell(i, j, startPoint, nextBoard, neighbours);
                }
            }

            return nextBoard;
        }

        public static int CountNeighbours(Board board, int i, int j)
        {
            int count = 0;

            count += DoesNeighbourExist(board, i - 1, j - 1);
            count += DoesNeighbourExist(board, i - 1, j);
            count += DoesNeighbourExist(board, i - 1, j + 1);
            count += DoesNeighbourExist(board, i, j - 1);
            count += DoesNeighbourExist(board, i, j + 1);
            count += DoesNeighbourExist(board, i + 1, j - 1);
            count += DoesNeighbourExist(board, i + 1, j);
            count += DoesNeighbourExist(board, i + 1, j + 1);
            
            return count;
        }

        public static int DoesNeighbourExist(Board board, int i, int j)
        {
            try
            {
                if (board.getCell(i, j).status == true) return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            return 0;
        }

        public static void UpdateCell(int i, int j,Board startPoint, Board nextBoard, int neighbours)
        {
            Cell cellTrue = new Cell(true);
            Cell cellFalse = new Cell(false);

            if (neighbours == 3 && startPoint.getCell(i, j).status == false)
            {
                nextBoard.setCell(i, j, cellTrue);
            }
            else if ((neighbours == 2 || neighbours == 3) && startPoint.getCell(i, j).status == true)
            {
                nextBoard.setCell(i, j, cellTrue);
            }
            else
            {
                nextBoard.setCell(i, j, cellFalse);
            }
        }

        

    }
}
