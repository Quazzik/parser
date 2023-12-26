using Microsoft.EntityFrameworkCore;
using parser.Services;
using parser.Services.Parsers;
using ParserMVC.Services;
using UI.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<MyApplicationContext>(o => o.UseSqlite(connectionString));

builder.Services.AddTransient<ParserLoggerService>();
builder.Services.AddTransient<HTTPService>();

builder.Services.AddTransient<FixenParserService>();
builder.Services.AddTransient<NeptunParserService>();
builder.Services.AddTransient<SupportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
