using System.Reflection;
using IntegrationAnalitics.Application.Handlers.FAQ;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddHttpClient();

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

//BuildWebHost(args).Run();
//public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup < startup > ().Build();  
 