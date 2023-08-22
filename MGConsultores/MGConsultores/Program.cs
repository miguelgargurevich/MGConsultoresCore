using MGConsultores.Interfaces;
using MGConsultores.Models;
using MGConsultores.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<EmailSenderOptions>(configuration.GetSection("EmailSenderOptions"));

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

