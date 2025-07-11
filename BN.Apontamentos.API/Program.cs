using BN.Apontamentos.API;
using BN.Apontamentos.Application;
using BN.Apontamentos.Application.Common.Filters;
using BN.Apontamentos.Infrastructure;
using BN.Apontamentos.Service;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers((options =>
{
    options.Filters.Add<ResponseActionFilter>();
}));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();
builder.Services.AddApplicationValidators();
builder.Services.AddApplicationMapster();
builder.Services.AddInfrastructure();
builder.Services.AddServices();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();