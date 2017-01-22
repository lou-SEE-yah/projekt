using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace ZavicajnoDrustvo.Database
{
    public partial class ZavDruDBContext : DbContext
    {
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public ZavDruDBContext(DbContextOptions<ZavDruDBContext> options)
        : base(options)
        { }

        /*public ZavDruDBContext(string connectionString) : base(connectionString)
        {
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=tcp:drustvo0.database.windows.net,1433;Initial Catalog=DrustvoDB;Persist Security Info=False;User ID={asian};Password={Dwight42!};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Kategorija>()
                .HasMany(e => e.PripadnostKorisnikKategorija);*/
            /*.WithRequired(e => e.Kategorija)
            .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<Kategorija>()
                .HasMany(e => e.Tema);
            /*.WithRequired(e => e.Kategorija)
            .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<Komentar>()
                .Property(e => e.sadržaj);
            /*.IsUnicode(false);*/

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.avatar);
            /*.IsUnicode(false);*/

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.spol);
            /*.IsFixedLength()
            .IsUnicode(false);*/

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.email);
            /*.IsUnicode(false);*/

            modelBuilder.Entity<Mjesto>()
                .HasMany(e => e.Korisnik);
            /*.WithRequired(e => e.Mjesto)
            .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<Objava>()
                .Property(e => e.sadrzaj);
            /*.IsUnicode(false);*/

            modelBuilder.Entity<Objava>()
                .HasMany(e => e.Komentar);
            /*.WithRequired(e => e.Objava)
            .WillCascadeOnDelete(false);*/

            /*modelBuilder.Entity<Objava>()
                .HasMany(e => e.Tema1);*/
            /*.WithMany(e => e.Objava1)
            .Map(m => m.ToTable("PripadnostObjavaTema").MapLeftKey("objavaID").MapRightKey("temaID"));
            */
            modelBuilder.Entity<Status>()
                .HasMany(e => e.Korisnik);
            /*.WithRequired(e => e.Status)
            .WillCascadeOnDelete(false);
            */
            modelBuilder.Entity<Status>()
                .HasMany(e => e.Službe);
            /*.WithRequired(e => e.Status)
            .WillCascadeOnDelete(false);
*/
            modelBuilder.Entity<Tema>()
                .Property(e => e.backgroundPicture);
            /*.IsUnicode(false);*/

            modelBuilder.Entity<Tema>()
            .HasMany(e => e.Objava);
            /*.WithRequired(e => e.Tema)
            .HasForeignKey(e => e.temaID)
            .WillCascadeOnDelete(false);*/
        }
    }
}

