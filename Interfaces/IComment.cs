using FINSHARK.Models;

namespace FINSHARK.Interfaces
{
    public interface IComment
    {
        Task<List<Comment>> GetAll();
    }
}
