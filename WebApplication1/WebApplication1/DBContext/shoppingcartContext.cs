using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

#nullable disable

namespace WebApplication1.DBContext
{
    public partial class shoppingcartContext : DbContext
    {
        public shoppingcartContext()
        {
        }

        public shoppingcartContext(DbContextOptions<shoppingcartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
