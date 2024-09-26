using FINSHARK.Dtos.Comment;
using FINSHARK.Models;

namespace FINSHARK.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO ToComment(this Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId,
                Title = comment.Title,
            };
        }
    }
}
