using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameOfLife;
using Microsoft.Extensions.Logging;
using System.Data;
using Newtonsoft.Json;
using GameOfLifeAPI.Respository;
using AutoMapper;

namespace GameOfLifeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameOfLifeController : ControllerBase
    {     

        private ISaveBoard _board;

        public GameOfLifeController(ISaveBoard board)
        {
            _board = board;
        }


        /// <summary> 
        /// Return the board saved in memory. 
        /// </summary>        
        [HttpGet("actualboard")]
        public ActionResult<string> Get()
        {
            var json = JsonConvert.SerializeObject(_board.getBoard());
            return Ok(json);
        }

        /// <summary> 
        /// Returns the next board in the game and save it in memory. 
        /// </summary>
        [HttpPost("nextboard")]
        public ActionResult<string> Post()
        {
            var json = JsonConvert.SerializeObject(_board.postNextBoard());
            return Ok(json);
        }

        /// <summary> 
        /// Saves a new board in memory that is written in the body. 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/GameOfLife/new
        ///     {
        ///        "rows": 3,
        ///        "columns": 3,
        ///        "board": [[{"status":true},{"status":true},{"status":true}],[{"status":true},{"status":true},{"status":true}],[{"status":true},{"status":true},{"status":true}]]
        ///     }
        ///
        /// </remarks>
        /// <response code="400">If the item is null</response> 
        [HttpPost("newboard")]
        [Consumes("text/plain")]
        public ActionResult<bool> PostNewBoard([FromBody] string newBoard)
        {
            _board.updateBoard(JsonConvert.DeserializeObject<Board>(newBoard));
            return Ok(true);
        }



    }
}
