using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfLife;

namespace GameOfLifeAPI.Respository
{
    public interface ISaveBoard
    {
        public Board getBoard();
        public Board postNextBoard();
        public void updateBoard(Board newBoard);
    }
}
