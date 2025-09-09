using Microsoft.EntityFrameworkCore;
using CrudProdukApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan layanan ke container.
builder.Services.AddControllersWithViews();

// Konfigurasi DbContext untuk menggunakan MySQL.
builder.Services.AddDbContext<AplikasiDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

// Konfigurasi pipeline permintaan HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Nilai default HSTS adalah 30 hari.
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