using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.PostAgg.Contracts;
using App.Domin.Service.AppServices.AuthorAgg;
using App.Domin.Service.AppServices.CategoryAgg;
using App.Domin.Service.AppServices.CommentAgg;
using App.Domin.Service.AppServices.PostAgg;
using App.Domin.Service.Services.AuthorAgg;
using App.Domin.Service.Services.CategoryAgg;
using App.Domin.Service.Services.CommentAgg;
using App.Domin.Service.Services.PostAgg;
using App.Infrastructures.EfCore.Persistence;



using App.Infrastructures.EfCore.Repositories.AuthorAgg;
using App.Infrastructures.EfCore.Repositories.CategoryAgg;
using App.Infrastructures.EfCore.Repositories.CommentAgg;
using App.Infrastructures.EfCore.Repositories.PostAgg;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer
    (@"Server=Localhost;Database=Blog;Integrated Security=true  ;TrustServerCertificate=true;"));
builder.Services.AddScoped<IAuthorAppService, AuthorAppService>();
builder.Services.AddScoped<IPostAppService, PostAppService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
