using FootballServerCapstone.Core.Interfaces.DAL;
using FootballServerCapstone.DAL.Repositories;
using FootballServerCapstone.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:2000",
            ValidAudience = "http://localhost:2000",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"))
        };

    });
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyHeader();
            policy.WithOrigins("*", "http://localhost:3000");
            policy.AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IClubRepository>(r => new ClubRepository(new DbFactory(new ConfigProvider().Config)));
builder.Services.AddTransient<IReportRepository>(r => new ReportRepository(new DbFactory(new ConfigProvider().Config)));
//builder.Services.AddTransient<ISeasonRepository SeasonRepository>();
//builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
//builder.Services.AddTransient<IMatchRepository, MatchRepository>();
//builder.Services.AddTransient<IPerformanceRepository, PerformanceRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();