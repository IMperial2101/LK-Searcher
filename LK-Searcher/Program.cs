using LK_Searcher;
using LK_Searcher.EntityModels;


using (var context = new MyContext())
{

}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

//@"host=localhost;port=5432;database = EntityFramework;username = postgres;password = 137731"
//dotnet ef dbcontext scaffold "Host = localhost;Database=EntityFramework;Username=postgres;Password=137731;" Npgsql.EntityFrameworkCore.PostgresSQL -o EntityModels


