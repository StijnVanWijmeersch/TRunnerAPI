using System.Reflection;
using TRunner.Common.Application;
using TRunner.Common.Presentation.Endpoints;
using TRunner.Modules.Groups.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Assembly[] moduleApplicationAssemblies = [
    TRunner.Modules.Groups.Application.AssemblyReference.Assembly];

builder.Services.AddApplication(moduleApplicationAssemblies);

builder.Services.AddGroupsModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndPoints();

app.Run();

