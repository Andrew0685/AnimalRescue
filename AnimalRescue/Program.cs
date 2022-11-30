using AnimalRescue.Middlewares;
using AnimalRescue.Services.AnimalServices;
using AnimalRescue.Services.AnimalServices.Interfaces;
using AnimalRescue.Services.DBServices;
using AnimalRescue.Services.DBServices.Interfaces;
using AnimalRescue.Services.FavoriteServices;
using AnimalRescue.Services.FavoriteServices.Interfaces;
using AnimalRescue.Services.FileServices;
using AnimalRescue.Services.FileServices.Interfaces;
using AnimalRescue.Services.FileUploadServices;
using AnimalRescue.Services.FileUploadServices.Interfaces;
using AnimalRescue.Services.PostServices;
using AnimalRescue.Services.PostServices.Interfaces;
using AnimalRescue.Services.ShelterServices;
using AnimalRescue.Services.ShelterServices.Interfaces;
using AnimalRescue.Services.UserSevices;
using AnimalRescue.Services.UserSevices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IAnimalRescueDbContext, AnimalRescueDbContext>();

builder.Services.AddScoped<IFileUpload, FileUploadService>();
builder.Services.AddScoped<IFileDelete, FileDeleteService>();

builder.Services.AddScoped<IGetAllPosts, GetAllPostsService>();
builder.Services.AddScoped<IGetUserPosts, GetUserPostsService>();

builder.Services.AddScoped<IGetUserByEmail, GetUserByEmailService>();
builder.Services.AddScoped<IAddUser, AddUserService>();
builder.Services.AddScoped<IEditUser, EditUserService>();
builder.Services.AddScoped<IGetAllUsers, GetAllUsersService>();
builder.Services.AddScoped<IDeleteUser, DeleteUserService>();

builder.Services.AddScoped<IAddPost, AddPostService>();
builder.Services.AddScoped<IDeletePost, DeletePostService>();

builder.Services.AddScoped<IAddShelter, AddShelterService>();
builder.Services.AddScoped<IGetAllShelters, GetAllSheltersServiceI>();
builder.Services.AddScoped<IDeleteShelter, DeleteShelterService>();
builder.Services.AddScoped<IEditShelter, EditShelterService>();
builder.Services.AddScoped<IGetShelterById, GetShelterByIdService>();

builder.Services.AddScoped<IGetShelterAnimals, GetShelterAnimalsService>();
builder.Services.AddScoped<IAddAnimal, AddAnimalService>();
builder.Services.AddScoped<IDeleteAnimal, DeleteAnimalService>();

builder.Services.AddScoped<IAddFavorite, AddFavoriteService>();
builder.Services.AddScoped<IGetUserFavorites, GetFavoritesService>();
builder.Services.AddScoped<IGetFavoritesModels, GetFavoriteModelService>();
builder.Services.AddScoped<IDeleteFavorite, DeleteFavoriteService>();

builder.Services.AddAuthentication("Cookie")
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Auth/Login";
        config.AccessDeniedPath = "/Home/AccessDenied";
    });

builder.Services.AddAuthorization();

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

app.UseMiddleware<ExistUserMiddleware>();
app.UseMiddleware<FileUploadMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
