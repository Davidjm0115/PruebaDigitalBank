using CapaDatos;
using CapaNegocios.Repositorios;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(new Conexion(builder.Configuration.GetConnectionString("conexion")));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    
    endpoints.MapControllers();

});
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
