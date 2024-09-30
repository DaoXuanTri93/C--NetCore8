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

        public static Comment ToCommentFromCreate(this CommentCreateDTO commentCreateDTO, int stockId)
        {
            return new Comment
            {
                Content = commentCreateDTO.Content,
                Title = commentCreateDTO.Title,
                StockId = stockId,

            };
        }

        public static Comment ToCommentFromUpdate(this CommentUpdateDTO commentUpdateDTO)
        {
            return new Comment
            {
                Content = commentUpdateDTO.Content,
                Title = commentUpdateDTO.Title
            };
        }
    }
}
