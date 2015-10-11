using System.Threading.Tasks;
using LyncStatusChecker.SL.Model.Repository.Dto;

namespace LyncStatusChecker.SL.Model.Repository
{
    public interface IPresenceRepository
    {
        Task<PresenceResult> Get(string sipUri);
    }
}