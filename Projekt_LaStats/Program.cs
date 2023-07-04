using Microsoft.EntityFrameworkCore;
using Projekt_LaStats.Context;
using Projekt_LaStats.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITeamService,TeamService>();
builder.Services.AddScoped<ILeagueService,LeagueService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IMatchesService, MatchesService>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server = (localdb)\\mysql; Database = LaxStat; Trusted_Connection = True; MultipleActiveResultSets = true"));

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
