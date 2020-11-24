using GameOfLife;
using GameOfLifeAPI.Respository;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeAPI.Respository
{
    public class BoardMemory : ISaveBoard
    {
        private Board currentBoard;
        
        public BoardMemory()
        {
            currentBoard = new Board(2, 2);
            currentBoard.setCell(0, 0, new Cell(true));
            currentBoard.setCell(0, 1, new Cell(true));
            currentBoard.setCell(1, 0, new Cell(false));
            currentBoard.setCell(1, 1, new Cell(true));
        }
        public Board getBoard()
        {
            return currentBoard;
        }

        public Board postNextBoard()
        {
            Board nextBoard = Game.GameInit(currentBoard);
            currentBoard = nextBoard;
            StreamWriter sw = new StreamWriter("C:\\Users\\cquintana\\source\\repos\\GameOfLifeAPI\\healthlogs.txt",true);
            sw.WriteLine(currentBoard.toString());
            sw.Close();
            return currentBoard;
        }

        public void updateBoard(Board newBoard)
        {
            currentBoard = newBoard;
            
        }
    }
}
