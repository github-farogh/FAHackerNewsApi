using FA_Hacker_News_API.Implementation;
using FA_Hacker_News_API.Interface;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IHackerNewsService, HackerNewsService>();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddCors(option =>
{
    option.AddPolicy("apicorspolicy", policy => { policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
