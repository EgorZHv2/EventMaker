using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;

namespace EventMaker.Services.Interfaces
{
    public interface IJuryService
    {
        Task<Result<JuriListViewModel>> GetAllJuryShortListAsync();
        Task<Result<JuriListViewModel>> GetAllJuryAsync();
    }
}
