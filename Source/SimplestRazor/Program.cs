using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Server.IISIntegration;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate(); //ver archivo: ".vs\SimplestRazor\config\applicationhost.config" "<windowsAuthentication enabled="true">"
//builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme).AddNegotiate();


builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});


// Add services to the container.
var razorPagesOptions = builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    // Add Controllers
    if (1 == 1) options.Conventions.AddPageRoute("/Values", "Values/4");
});

// Add additional folders for views
razorPagesOptions.AddRazorOptions(o =>
{
    o.PageViewLocationFormats.Add("/Pages/Users/{0}.cshtml");
    o.PageViewLocationFormats.Add("/Pages/Examples/DynamicGrid/Data/{0}.cshtml");
    o.PageViewLocationFormats.Add("/Pages/Examples/DynamicGrid/{0}.cshtml");
    o.PageViewLocationFormats.Add("/Pages/Examples/Bootstrap/{0}.cshtml");
    o.PageViewLocationFormats.Add("/Pages/Examples/JQueryUI/{0}.cshtml");
    o.PageViewLocationFormats.Add("/Pages/Examples/Upload/{0}.cshtml");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment()) // Configure the HTTP request pipeline.
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers(); // Required when adding API controllers
});

app.MapRazorPages();

app.Run();
