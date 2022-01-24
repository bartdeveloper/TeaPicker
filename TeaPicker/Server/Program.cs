using Microsoft.EntityFrameworkCore;
using TeaPicker.DataAccess.Data;
using TeaPicker.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAnyOrigin",
                      builder =>
                      {
                          builder.AllowAnyOrigin();
                      });
});

builder.Services.AddDbContext<TeaPickerDbContext>(options =>
            options.UseInMemoryDatabase(databaseName: builder.Configuration.GetValue<string>("DB:Name")));

builder.Services.AddScoped<ITeaService, TeaService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAnyOrigin");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var serviceScope = serviceScopeFactory.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<TeaPickerDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
