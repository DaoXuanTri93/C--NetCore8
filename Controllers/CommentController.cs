using FINSHARK.Dtos.Comment;
using FINSHARK.Interfaces;
using FINSHARK.Mappers;
using FINSHARK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FINSHARK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComment _repo;

        public CommentController(IComment repo) { 
            _repo = repo;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _repo.GetAll();
            var commentDTO = comments.Select(s => s.ToComment());

            return Ok(commentDTO);
        }
    }
}
