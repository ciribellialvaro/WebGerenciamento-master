using Microsoft.EntityFrameworkCore;
using WebGerenciamento.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Colocando o conection string
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Contexto>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=postgres;User Id=postgres;Password=123456;"));//Melhor mudar para o Appsetting

//builder.Services.AddDbContext<Contexto>
//    (options =>
//    options.UseSqlServer("Data Source=192.168.0.101,1433;Initial Catalog=TESTE_GERENCIAMENTO_NEW;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));

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
