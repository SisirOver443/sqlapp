using Microsoft.FeatureManagement;
using sqlapp.Pages.Services;



var builder = WebApplication.CreateBuilder(args);

var connectionString = "Endpoint=https://prac-learn-14-appconfigs.azconfig.io;Id=yF5P;Secret=2wi12rwXGS9I199KCXcBKLKLUua+uZQt2T9TKZhAw9E=";

builder.Host.ConfigureAppConfiguration(builder =>
{
    builder.AddAzureAppConfiguration(options=>
        options.Connect(connectionString).UseFeatureFlags());
});

builder.Services.AddTransient<IProductService, ProductService>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
