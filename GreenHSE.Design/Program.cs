using GreenBNTU.Design;
using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<Seed>();
builder.Services.AddTransient<IAllProjects, ProjectRepository>();
builder.Services.AddTransient<IAllObjects, RecObjectRepository>();
builder.Services.AddTransient<IAllLocations, LocationRepository>();
builder.Services.AddTransient<IAllAdmins, AdminRepository>();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddScoped<IAllProjects, ProjectRepository>();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

//if (args.Length == 1 && args[0].ToLower() == "seeddata")
//{
//    SeedData(app);
//}



void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedContext();
    }
}

IWebHostEnvironment env = app.Environment;

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();

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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Projecthtml}/{action=ProjectList}");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "loginwindow", pattern: "{controller=LoginWindow}/{action=LoginWindow}");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "map", pattern: "{controller=GoogleMaps}/{action=GoogleMap}");
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
