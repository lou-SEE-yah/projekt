using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

using Microsoft.EntityFrameworkCore.Metadata;

namespace ZavicajnoDrustvo.Database
{
    public class ZavDruDBContext : DbContext
    {
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<Komentar> Komentar { get; set; }
        public virtual DbSet<Mjesto> Mjesto { get; set; }
        public virtual DbSet<Objava> Objava { get; set; }
        public virtual DbSet<PripadnostKorisnikKategorija> PripadnostKorisnikKategorija { get; set; }
        public virtual DbSet<RodbinskiOdnosi> RodbinskiOdnosi { get; set; }
        public virtual DbSet<Službe> Službe { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }
        /*public ZavDruDBContext(DbContextOptions<ZavDruDBContext> options)
        : base(options)
        { }*/

        public ZavDruDBContext(DbContextOptions<ZavDruDBContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=tcp:drustvo0.database.windows.net,1433;Initial Catalog=DrustvoDB;Persist Security Info=False;User ID=asian;Password=Dwight42!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Komentar>().HasKey(s => s.komentarID);
            modelBuilder.Entity<Kategorija>().HasKey(s => s.kategorijaID);
            modelBuilder.Entity<Korisnik>().HasKey(s => s.OIB);
            modelBuilder.Entity<Mjesto>().HasKey(s => s.poštanskiBroj);
            modelBuilder.Entity<Objava>().HasKey(s => s.objavaID);
            modelBuilder.Entity<PripadnostKorisnikKategorija>().HasKey(s => new { s.kategorijaID, s.korisnikID});
            modelBuilder.Entity<RodbinskiOdnosi>().HasKey(s => new { s.korisnik1ID, s.korisnik2ID });
            modelBuilder.Entity<Službe>().HasKey(s => new { s.statusID, s.korisnikID, s.datumPocetak });
            modelBuilder.Entity<Status>().HasKey(s => s.statusID);
            modelBuilder.Entity<Tema>().HasKey(s => s.temaID);
            modelBuilder.Entity<RodbinskiOdnosi>().Property(s => s.odnos).IsRequired();
            modelBuilder.Entity<Status>().Property(s => s.nazivStatus).IsRequired();
            modelBuilder.Entity<Tema>().Property(s => s.nazivTema).IsRequired();
            modelBuilder.Entity<Objava>().Property(s => s.naslov).IsRequired();
            modelBuilder.Entity<Objava>().Property(s =>  s.sadrzaj).IsRequired();
            modelBuilder.Entity<Objava>().Property(s => s.autor).IsRequired();
            modelBuilder.Entity<Mjesto>().Property(s => s.imeMjesta).IsRequired();
            modelBuilder.Entity<Komentar>().Property(s => s.sadržaj).IsRequired();
            modelBuilder.Entity<Komentar>().Property(s => s.korisničkoIme ).IsRequired();
            modelBuilder.Entity<Kategorija>().Property(s => s.voditeljID).IsRequired();
            modelBuilder.Entity<Kategorija>().Property(s => s.nazivKategorija ).IsRequired();
            modelBuilder.Entity<Korisnik>().Property(s => s.korisnikID).IsRequired();
            modelBuilder.Entity<Korisnik>().Property(s => s.lozinka).IsRequired();
            modelBuilder.Entity<Korisnik>().Property(s => s.ime).IsRequired();
            modelBuilder.Entity<Korisnik>().Property(s =>  s.prezime).IsRequired();
            modelBuilder.Entity<Korisnik>().Property(s =>  s.spol).IsRequired();
            modelBuilder.Entity<Korisnik>().Property(s => s.email).IsRequired();
            modelBuilder.Entity<Korisnik>().Property(s => s.adresa).IsRequired();

            modelBuilder.Entity<Komentar>().HasOne(s => s.Objava).WithMany(b => b.Komentar);
            modelBuilder.Entity<Tema>().HasOne(s => s.Kategorija).WithMany(b => b.Tema);
            modelBuilder.Entity<Objava>().HasOne(s => s.Tema).WithMany(b => b.Objava);
            //modelBuilder.Entity<Mjesto>().HasOne(s => s.Korisnik).WithOne(b=>b.Mj);
            modelBuilder.Entity<PripadnostKorisnikKategorija>().HasOne(s => s.Kategorija).WithMany(b => b.PripadnostKorisnikKategorija);
            
            //modelBuilder.Entity<RodbinskiOdnosi>().HasOne(s => s.Objava).WithMany(b => b.Komentar);
            /*modelBuilder.Entity(typeof(Objava))
            .HasOne(typeof(Tema))
            .WithMany()
            .HasForeignKey()
            .OnDelete(DeleteBehavior.Restrict); // no ON DELETE

            modelbuilder.Entity(typeof(Match))
                .HasOne(typeof(Team), "HomeTeam")
                .WithMany()
                .HasForeignKey("GuestTeamId")
                .OnDelete(DeleteBehavior.Cascade); // set ON DELETE CASCADE

            modelBuilder.Entity<Kategorija>()
                .HasMany(e => e.PripadnostKorisnikKategorija);
            .WithRequired(e => e.Kategorija)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategorija>()
                .HasMany(e => e.Tema);
            .WithRequired(e => e.Kategorija)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Komentar>()
                .Property(e => e.sadržaj);
            .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.avatar);
           .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.spol);
            .IsFixedLength()
            .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.email);
            .IsUnicode(false);

            modelBuilder.Entity<Mjesto>()
                .HasMany(e => e.Korisnik);
            .WithRequired(e => e.Mjesto)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Objava>()
                .Property(e => e.sadrzaj);
            .IsUnicode(false);

            modelBuilder.Entity<Objava>()
                .HasMany(e => e.Komentar);
            .WithRequired(e => e.Objava)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Objava>()
                .HasMany(e => e.Tema1);
            .WithMany(e => e.Objava1)
            .Map(m => m.ToTable("PripadnostObjavaTema").MapLeftKey("objavaID").MapRightKey("temaID"));
            
            modelBuilder.Entity<Status>()
                .HasMany(e => e.Korisnik);
            .WithRequired(e => e.Status)
            .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Status>()
                .HasMany(e => e.Službe);
            .WithRequired(e => e.Status)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tema>()
                .Property(e => e.backgroundPicture);
            .IsUnicode(false);

            modelBuilder.Entity<Tema>()
           .HasForeignKey(e => e.temaID)
            .WillCascadeOnDelete(false);*/
        }
    }
}

