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
        private readonly IComment _repoComment;
        private readonly IStock _repoStock;
        public CommentController(IComment repoComment, IStock repoStock)
        {
            _repoComment = repoComment;
            _repoStock = repoStock;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _repoComment.GetAll();
            var commentDTO = comments.Select(s => s.ToComment());

            return Ok(commentDTO);
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> CreateComment(int stockId, CommentCreateDTO commentCreateDTO)
        {
            // check stockId tồn tại không
            if (!await _repoStock.CheckExists(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            // chuyển DTO -> Model
            var commentModel = commentCreateDTO.ToCommentFromCreate(stockId);
            await _repoComment.CommentCreate(commentModel);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, CommentUpdateDTO commentUpdateDTO)
        {
            var comment = await _repoComment.CommentUpdate(id, commentUpdateDTO.ToCommentFromUpdate());
            if (comment == null)
            {
                return BadRequest("Comment does not exist");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _repoComment.CommentDelete(id);
            if (comment == -1)
            {
                return BadRequest("Comment does not exist");
            }
            return Ok();
        }
    }
}
