using AutoMapper;
using EventMaker.Data.Entities;
using EventMaker.Data;
using EventMaker.Infrastructure;
using EventMaker.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using EventMaker.Services.Interfaces;

namespace EventMaker.Services
{
    public class MemberService:IMemberService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CityService> _logger;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public MemberService(
            ApplicationDbContext context
            , ILogger<CityService> logger
            , IMapper mapper
            , RoleManager<IdentityRole> roleManager
            , UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<Result<MemberListViewModel>> GetAllMembersAsync()
        {
            MemberListViewModel memberListView = new MemberListViewModel();

            var members = await _userManager.GetUsersInRoleAsync("Member");

            if (members is null)
            {
                _logger.LogError($"Жюри не найдено");
                return Result<MemberListViewModel>.Failure("Жюри не найдено");
            }

            try
            {
                foreach (var item in members)
                {
                    memberListView.memberViews.Add(_mapper.Map<MemberViewModel>(item));

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Маппинг завершился с ошибкой: {ex}");
                return Result<MemberListViewModel>.Failure("Произошла внутренняя ошибка сервера", 500);
            }

            return Result<MemberListViewModel>.Success(memberListView);

        }
    }
}
