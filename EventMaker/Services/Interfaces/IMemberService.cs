using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;

namespace EventMaker.Services.Interfaces
{
    public interface IMemberService
    {
        Task<Result<MemberListViewModel>> GetAllMembersAsync();
    }
}
