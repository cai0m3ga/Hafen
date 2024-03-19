using Hafen.Api;
using Hafen.Application;
using Hafen.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services
        .AddApplication()
        .AddPresentation()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

}

var app = builder.Build();
{

    if (app.Environment.IsDevelopment())
    {

        app.UseSwagger();
        app.UseSwaggerUI();

    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCors("corsapp");
    app.Run();

}