var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddScoped<IOpenSimService, OpenSimService>();
builder.Services.AddScoped<IRESTfulAPIGeneralService, RESTfulAPIGeneralService>();
builder.Services.AddScoped<IRESTfulAPIRobustService, RESTfulAPIRobustService>();
builder.Services.AddScoped<IRESTfulAPISimulatorService, RESTfulAPISimulatorService>();

var app = builder.Build();
app.MapControllers();
app.Run();