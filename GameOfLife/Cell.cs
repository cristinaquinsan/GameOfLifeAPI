using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Cell
    {
        public bool status { get; set; }
        public Cell(bool status)
        {
            this.status = status;
        }
    }
}
