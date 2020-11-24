using FluentAssertions;
using GameOfLife;
using NUnit.Framework;
using System.Collections.Generic;


namespace Tests {
    public class Tests {
        [Test]
        public void return_false_when_only_one_cell_is_dead()
        {
            Board table = new Board(1,1);
            Cell cellFalse = new Cell(false);
            table.setCell(0, 0, cellFalse);


            Board tableResult = new Board(1, 1);
            tableResult.setCell(0, 0, cellFalse);

            var result = Game.GameInit(table);
            result.Should().BeEquivalentTo(tableResult);
        }

        [Test]
        public void return_false_when_only_one_cell_is_alive()
        {
            Board table = new Board(1, 1);
            Cell cellTrue = new Cell(true);
            table.setCell(0, 0, cellTrue);


            Board tableResult = new Board(1, 1);
            Cell cellFalse = new Cell(false);
            tableResult.setCell(0, 0, cellFalse);

            var result = Game.GameInit(table);
            result.Should().BeEquivalentTo(tableResult);
        }

        [Test]
        public void count_with_one_neighbour()
        {
            Board table = new Board(1, 2);
            Cell cellTrue = new Cell(true);
            
            table.setCell(0, 0, cellTrue);
            table.setCell(0, 1, cellTrue);

            var result = Game.CountNeighbours(table, 0, 1);
            result.Should().Be(1);
        }

        [Test]
        public void count_2x2_neighbours()
        {
            Board table = new Board(2, 2);
            Cell cellTrue = new Cell(true);
            Cell cellFalse = new Cell(false);
            table.setCell(0, 0, cellTrue);
            table.setCell(0, 1, cellFalse);
            table.setCell(1, 0, cellTrue);
            table.setCell(1, 1, cellTrue);

            var result = Game.CountNeighbours(table, 0, 1);
            result.Should().Be(3);
        }

        [Test]
        public void count_all_8_neighbours()
        {
            Board table = new Board(3, 3);
            Cell cellTrue = new Cell(true);
            Cell cellFalse = new Cell(false);
            table.setCell(0, 0, cellTrue);
            table.setCell(0, 1, cellTrue);
            table.setCell(0, 2, cellTrue);
            table.setCell(1, 0, cellTrue);
            table.setCell(1, 1, cellFalse);
            table.setCell(1, 2, cellTrue);
            table.setCell(2, 0, cellTrue);
            table.setCell(2, 1, cellTrue);
            table.setCell(2, 2, cellTrue);

            var result = Game.CountNeighbours(table, 1, 1);
            result.Should().Be(8);
        }

        [Test]
        public void board_2x2_one_alive_no_neighbours()
        {
            Board table = new Board(2, 2);
            Cell cellTrue = new Cell(true);
            Cell cellFalse = new Cell(false);
            table.setCell(0, 0, cellTrue);
            table.setCell(0, 1, cellFalse);
            table.setCell(1, 0, cellFalse);
            table.setCell(1, 1, cellFalse);

            Board tableResult = new Board(2, 2);
            tableResult.setCell(0, 0, cellFalse);
            tableResult.setCell(0, 1, cellFalse);
            tableResult.setCell(1, 0, cellFalse);
            tableResult.setCell(1, 1, cellFalse);

            var result = Game.GameInit(table);
            result.Should().BeEquivalentTo(tableResult);
        }

        [Test]
        public void board_2x2_3_neighbours_alive()
        {
            Board table = new Board(2, 2);
            Cell cellTrue = new Cell(true);
            Cell cellFalse = new Cell(false);
            table.setCell(0, 0, cellTrue);
            table.setCell(0, 1, cellFalse);
            table.setCell(1, 0, cellTrue);
            table.setCell(1, 1, cellTrue);

            Board tableResult = new Board(2, 2);
            tableResult.setCell(0, 0, cellTrue);
            tableResult.setCell(0, 1, cellTrue);
            tableResult.setCell(1, 0, cellTrue);
            tableResult.setCell(1, 1, cellTrue);

            var result = Game.GameInit(table);
            result.Should().BeEquivalentTo(tableResult);
        }

        [Test]
        public void board_2x3_4_neighbours_alive_two_dies()
        {
            Board table = new Board(2, 3);
            Cell cellTrue = new Cell(true);
            Cell cellFalse = new Cell(false);
            table.setCell(0, 0, cellTrue);
            table.setCell(0, 1, cellTrue);
            table.setCell(0, 2, cellTrue);
            table.setCell(1, 0, cellTrue);
            table.setCell(1, 1, cellFalse);
            table.setCell(1, 2, cellFalse);

            Board tableResult = new Board(2, 3);
            tableResult.setCell(0, 0, cellTrue);
            tableResult.setCell(0, 1, cellTrue);
            tableResult.setCell(0, 2, cellFalse);
            tableResult.setCell(1, 0, cellTrue);
            tableResult.setCell(1, 1, cellFalse);
            tableResult.setCell(1, 2, cellFalse);

            var result = Game.GameInit(table);
            result.Should().BeEquivalentTo(tableResult);
        }

        [Test]
        public void board_3x3_4_neighbours_alive_one_dies()
        {
            Board table = new Board(3, 3);
            Cell cellTrue = new Cell(true);
            Cell cellFalse = new Cell(false);
            table.setCell(0, 0, cellFalse);
            table.setCell(0, 1, cellTrue);
            table.setCell(0, 2, cellFalse);
            table.setCell(1, 0, cellTrue);
            table.setCell(1, 1, cellTrue);
            table.setCell(1, 2, cellTrue);
            table.setCell(2, 0, cellFalse);
            table.setCell(2, 1, cellTrue);
            table.setCell(2, 2, cellFalse);

            Board tableResult = new Board(3, 3);
            tableResult.setCell(0, 0, cellTrue);
            tableResult.setCell(0, 1, cellTrue);
            tableResult.setCell(0, 2, cellTrue);
            tableResult.setCell(1, 0, cellTrue);
            tableResult.setCell(1, 1, cellFalse);
            tableResult.setCell(1, 2, cellTrue);
            tableResult.setCell(2, 0, cellTrue);
            tableResult.setCell(2, 1, cellTrue);
            tableResult.setCell(2, 2, cellTrue);

            var result = Game.GameInit(table);
            result.Should().BeEquivalentTo(tableResult);
        }

    }
}