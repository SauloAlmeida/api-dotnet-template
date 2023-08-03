using Api.Setups;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabasesSetup(builder.Configuration)
    .AddAplicationSetup()
    .AddControllersSetup();

builder.Host.AddLoggerSetup();

var app = builder.Build();
app.UseDocumentation();
app.UseLoggerForRequests();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
