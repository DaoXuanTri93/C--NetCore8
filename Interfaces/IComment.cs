using FINSHARK.Dtos.Comment;
using FINSHARK.Models;

namespace FINSHARK.Interfaces
{
    public interface IComment
    {
        Task<List<Comment>> GetAll();
        Task<Comment> CommentCreate(Comment comment);
        Task<Comment> CommentUpdate(int id, Comment comment);
        Task<int> CommentDelete(int id);
    }
}
