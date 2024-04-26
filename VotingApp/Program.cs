using VotingApp.Core.Interfaces.Repositories;
using VotingApp.Core.Interfaces.Services;
using VotingApp.DataAccess.Repositories;
using VotingApp.Service.Voting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IVotingService, VotingService>();
builder.Services.AddSingleton<IVotingRepository, VotingRepository>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
