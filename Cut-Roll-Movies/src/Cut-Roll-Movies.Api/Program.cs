using Cut_Roll_Movies.Api.Common.Extensions.ServiceCollection;
using Cut_Roll_Movies.Api.Common.ServiceCollection;
using Cut_Roll_Movies.Api.Common.WebApplication;
using Cut_Roll_Movies.Api.Common.WebApplicationBuilder;

var builder = WebApplication.CreateBuilder(args);

builder.SetupVariables();
builder.InitMessageBroker();

builder.Services.InitDbContext(builder.Configuration);
builder.Services.InitAuth(builder.Configuration);
builder.Services.InitSwagger();
builder.Services.InitCors();

builder.Services.RegisterDependencyInjection();

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UpdateDbContext();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();


app.Run();
