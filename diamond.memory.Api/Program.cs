using diamond.memory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options => 
{
    options.UseSqlite("Data Source=../Registrar.sqlite", b => b.MigrationsAssembly("diamond.memory.Api"));
options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

