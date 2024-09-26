using FINSHARK.Data;
using FINSHARK.Interfaces;
using FINSHARK.Models;
using Microsoft.EntityFrameworkCore;

namespace FINSHARK.Repository
{
    public class CommentRepository : IComment
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context) { 
            _context = context;
        }
        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
