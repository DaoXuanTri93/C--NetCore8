using FINSHARK.Data;
using FINSHARK.Dtos.Comment;
using FINSHARK.Interfaces;
using FINSHARK.Models;
using Microsoft.EntityFrameworkCore;

namespace FINSHARK.Repository
{
    public class CommentRepository : IComment
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CommentCreate(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;

        }

        public async Task<int> CommentDelete(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Remove(comment);
                await _context.SaveChangesAsync();
                return 0;
            }
            return -1;
        }

        public async Task<Comment> CommentUpdate(int id, Comment commentModel)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            comment.Title = commentModel.Title;
            comment.Content = commentModel.Content;
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
