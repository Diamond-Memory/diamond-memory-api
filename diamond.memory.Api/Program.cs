using diamond.memory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using diamond.memory.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

string authority = builder.Configuration["Auth0:Authority"] ??
throw new ArgumentNullException("Auth0:Authority");

string audience = builder.Configuration["Auth0:Audience"] ??
throw new ArgumentNullException("Auth0:Audience");

builder.Services.AddControllers();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(Options => {
    Options.Authority = authority;
    Options.Audience = audience;
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("delete:catalog", policy =>
        policy.RequireAuthenticatedUser().RequireClaim("scope", "delete:catalog"));
});


builder.Services.AddDbContext<StoreContext>(options => 
    options.UseSqlite("Data Source=../Registrar.sqlite", 
    b => b.MigrationsAssembly("diamond.memory.Api"))
);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

