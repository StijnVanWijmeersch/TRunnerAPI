using System.Reflection;
using Serilog;
using TRunner.API.Extensions;
using TRunner.API.Middleware;
using TRunner.Common.Application;
using TRunner.Common.Infrastructure;
using TRunner.Common.Presentation.Endpoints;
using TRunner.Modules.Groups.Infrastructure;
using TRunner.Modules.Users.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggingConfiguration) => loggingConfiguration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();

Assembly[] moduleApplicationAssemblies = [
    TRunner.Modules.Groups.Application.AssemblyReference.Assembly,
    TRunner.Modules.Users.Application.AssemblyReference.Assembly];

builder.Services.AddApplication(moduleApplicationAssemblies);

builder.Services.AddInfrastructure();

builder.Configuration.AddModulesConfiguration(["groups", "users"]);

builder.Services.AddGroupsModule(builder.Configuration);
builder.Services.AddUsersModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndPoints();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.Run();

