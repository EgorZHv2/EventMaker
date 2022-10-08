
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventMaker.Data;
using EventMaker.Data.Entities;
using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;
using EventMaker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace EventMaker.Services
{
    public class JuryService:IJuryService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CityService> _logger;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public JuryService(
            ApplicationDbContext context
            , ILogger<CityService> logger
            , IMapper mapper
            , RoleManager<IdentityRole> roleManager
            ,UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<Result<JuriListViewModel>> GetAllJuryShortListAsync()
        {
            JuriListViewModel juriListViewModel = new JuriListViewModel();

            var juri = await _userManager.GetUsersInRoleAsync("Moderator");

            if (juri is null)
            {
                _logger.LogError($"Жюри не найдено");
                return Result<JuriListViewModel>.Failure("Жюри не найдено");
            }

            try
            {
                foreach (var item in juri)
                {
                    juriListViewModel.Juri.Add(_mapper.Map<JuriViewModel>(item));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Маппинг завершился с ошибкой: {ex}");
                return Result<JuriListViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }

            return Result<JuriListViewModel>.Success(juriListViewModel);

        }
    }
}
