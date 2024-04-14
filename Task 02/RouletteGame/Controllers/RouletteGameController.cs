using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouletteGameAPI.DTOs.Bet;
using RouletteGameAPI.DTOs.Roulette;
using RouletteGameAPI.Interfaces;
using RouletteGameAPI.Interfaces.Repositories;
using RouletteGameAPI.Mappers;
using RouletteGameAPI.Models;

namespace RouletteGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteGameController(IRouletteRepository rouletteRepository, IBetRepository betRepository) : ControllerBase
    {
        private readonly IRouletteRepository _rouletteRepository = rouletteRepository;
        private readonly IBetRepository _betRepository = betRepository;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var roullette = await _rouletteRepository.GetByIdAsync(id);

            if (roullette == null) return NotFound($"Could not find roullete game with id: {id}");

            return Ok(roullette.ToRoulleteDTO());
        }

        [HttpPost("create-game")]
        public async Task<IActionResult> CreateRoulleteGame()
        {
            var rouletteGameModel = await _rouletteRepository.CreateAsync();

            return CreatedAtAction(nameof(GetById), new { id = rouletteGameModel.Id }, rouletteGameModel.ToRoulleteDTO());
        }

        [HttpPost("bet")]
        public async Task<IActionResult> PlaceBet([FromBody] CreateBetRequestDTO source)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var betModel = source.ToBetFromCreateDTO();
            var bet = await _betRepository.CreateAsync(betModel);

            if (bet == null) return NotFound($"Could not find roulette game of id: {source.RouletteId}");

            return CreatedAtAction(nameof(GetById), new { id = betModel.BetId }, betModel.ToBetDTO());
        }

        [HttpPut("spin")]
        public async Task<IActionResult> Spin([FromBody] UpdateRouletteGameRequestDTO source)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var rouletteModel = await _rouletteRepository.UpdateAsync(source);

            if (rouletteModel == null) return NotFound($"No game found to start for id: {source.Id}");

            return Ok(rouletteModel.ToRoulleteDTO());
        }

        [HttpPost("payout")]
        public async Task<IActionResult> Payout([FromBody] UpdateBetRequestDTO source)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var payouts = await _betRepository.PayoutBetsAsync(source);
            if (payouts == null) return NotFound($"No bets found to for roullete game id: {source.RouletteId}");

            var betsModel = payouts.Select(p => p.ToBetDTO());

            return Ok(betsModel);
        }

        [HttpGet("spin-history")]
        public async Task<IActionResult> GetAllPreviousGames()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var roullettes = await _rouletteRepository.GetAllAsync();

            if (roullettes.Count == 0) return NotFound("No roulette games exists.");

            var playersModel = roullettes.Select(c => c.ToRoulleteDTO());

            return Ok(playersModel);
        }
    }
}
