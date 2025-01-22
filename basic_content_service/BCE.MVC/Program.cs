using BCS.Api.Services; // Assuming IPostService and PostService are here
using BCS.Api.Data; // Assuming YourDbContext is here
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using BCE.MVC.Global;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllersWithViews();
StreamReader sr = new StreamReader("../../../aws-resources/localhost-mac-dotnet.txt");
if(StaticVariables.connection_string==null){
    StaticVariables.connection_string = sr.ReadToEnd();
}
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<YourDbContext>(options =>
        // options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    options.UseMySQL(StaticVariables.connection_string));
builder.Services.AddScoped<IPostService, PostService>();

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
