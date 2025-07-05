using BN.Apontamentos.API;
using BN.Apontamentos.Application;
using BN.Apontamentos.Infrastructure;
using BN.Apontamentos.Service;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();
builder.Services.AddApplicationValidators();
builder.Services.AddApplicationMapster();
builder.Services.AddInfrastructure();
builder.Services.AddServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();