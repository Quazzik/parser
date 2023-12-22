using Microsoft.EntityFrameworkCore;
using parser.Services;
using parser.Services.Parsers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<HTTPService>();
var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DBService>(options => options.UseSqlite(connection));
builder.Services.AddTransient<FixenParserService>();
builder.Services.AddTransient<NeptunParserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();