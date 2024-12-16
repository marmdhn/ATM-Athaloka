using ATMBank_.Context;
using ATMBank_.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ATMService>();
builder.Services.AddScoped<CasetteService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<NasabahService>();
builder.Services.AddScoped<AdminService>();

// Load .env variables
try
{
    // Load .env file
    DotNetEnv.Env.Load();

    // Integrate environment variables into Configuration
    foreach (var envVar in Environment.GetEnvironmentVariables().Keys)
    {
        var key = envVar.ToString();
        var value = Environment.GetEnvironmentVariable(key);

        // Key normalization for hierarchical configuration
        key = key.Replace("__", ":");
        builder.Configuration[key] = value;
    }

    Console.WriteLine($"Loaded Connection String: {builder.Configuration.GetConnectionString("DefaultConnection")}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error loading .env file: {ex.Message}");
}


//Connection to Database
// builder.Services.AddDbContext<ApplicationDbContext>(item=>item.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") 
                      ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// Build the application
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
