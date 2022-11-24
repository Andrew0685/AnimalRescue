using AnimalRescue.Services.DBServices;
using AnimalRescue.Services.DBServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IAnimalRescueDbContext, AnimalRescueDbContext>();

builder.Services.AddAuthentication("Cookie")
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Admin/Login";
        config.AccessDeniedPath = "/Home/AccessDenied";
    });

builder.Services.AddAuthorization(
//    options => 
//{
//    options.AddPolicy("Admin", builder => 
//    {
//        builder.RequireClaim(ClaimTypes.Role, "Admin");
//    });

//    options.AddPolicy("User", builder =>
//    {
//        builder.RequireClaim(ClaimTypes.Role, "User");
//    });
//}
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
