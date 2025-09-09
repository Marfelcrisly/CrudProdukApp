using Microsoft.EntityFrameworkCore;
using CrudProdukApp.Models;

namespace CrudProdukApp.Data
{
    public class AplikasiDbContext : DbContext
    {
        public AplikasiDbContext(DbContextOptions<AplikasiDbContext> options) : base(options)
        {
        }

        public DbSet<Produk> Produk { get; set; }
    }
}