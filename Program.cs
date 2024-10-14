using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiOptions>(
    builder.Configuration.GetSection(nameof(ApiOptions)));

var app = builder.Build();

IOptions<ApiOptions> options = app.Services.GetRequiredService<IOptions<ApiOptions>>();

var api = app.MapGroup(options.Value.ApiPrefix); 

api.MapGet("/", () => "Hello World!");

app.Run();
