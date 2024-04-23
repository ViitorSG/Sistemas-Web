using Microsoft.EntityFrameworkCore;
using Trabalho_API.Data;
using Trabalho_API.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppCont>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbApi"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<CorreiosService>();

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
    pattern: "{controller=Tarefas}/{action=Index}/{id?}");

app.Run();
