using EventMaker.Data;
using EventMaker.Data.Entities;
using EventMaker.Infrastructure.Mappers;
using EventMaker.Services;
using EventMaker.Services.Interfaces;
using M6T.Core.TupleModelBinder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options =>
{
    options.ModelBinderProviders.Insert(0, new TupleModelBinderProvider());
});

builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService,CountryService>();
builder.Services.AddScoped<IDirectionService, DirectionService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IJuryService, JuryService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

var app = builder.Build();

using (var servicescope = app.Services.CreateScope())
{
    var serviceprovider = servicescope.ServiceProvider;


    try
    {
        var context = serviceprovider.GetRequiredService<ApplicationDbContext>();
        var userManager = serviceprovider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceprovider.GetRequiredService<RoleManager<IdentityRole>>();
        
        DbInitializer.Initialize(context);
        IdentityData.AddRoles(roleManager);
        IdentityData.AddOrganizer(userManager);
        IdentityData.AddModerators(userManager);
    }
    catch (Exception e)
    {
        var loggerfactory = LoggerFactory.Create(builder =>
        builder.AddConsole());
        ILogger<Program> logger = loggerfactory.CreateLogger<Program>();
        logger.LogError(e.Message);
    }

}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{Id?}");

    endpoints.MapAreaControllerRoute(
        name: "account_area",
        areaName: "account",
        pattern: "{area=account}/{controller=auth}/{action=login}/{id?}");
    

});
app.Run();
