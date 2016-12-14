using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DienstenCheques.Data;

namespace DienstenCheques.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161117220237_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DienstenCheques.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DienstenCheques.Models.Domain.Bestelling", b =>
                {
                    b.Property<int>("BestellingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AantalAangekochteCheques");

                    b.Property<DateTime>("CreatieDatum");

                    b.Property<DateTime>("DebiteerDatum");

                    b.Property<bool>("Elektronisch");

                    b.Property<int?>("GebruikersNummer")
                        .IsRequired();

                    b.HasKey("BestellingId");

                    b.HasIndex("GebruikersNummer");

                    b.ToTable("Bestelling");
                });

            modelBuilder.Entity("DienstenCheques.Models.Domain.DienstenCheque", b =>
                {
                    b.Property<int>("DienstenChequeNummer")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatieDatum");

                    b.Property<bool>("Elektronisch");

                    b.Property<int?>("GebruikersNummer")
                        .IsRequired();

                    b.Property<DateTime?>("GebruiksDatum");

                    b.Property<int?>("PrestatieId");

                    b.HasKey("DienstenChequeNummer");

                    b.HasIndex("GebruikersNummer");

                    b.HasIndex("PrestatieId");

                    b.ToTable("DienstenCheque");
                });

            modelBuilder.Entity("DienstenCheques.Models.Domain.Gebruiker", b =>
                {
                    b.Property<int>("GebruikersNummer")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("GebruikersNummer");

                    b.ToTable("Gebruiker");
                });

            modelBuilder.Entity("DienstenCheques.Models.Domain.Onderneming", b =>
                {
                    b.Property<int>("OndernemingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("OndernemingId");

                    b.ToTable("Ondernemingen");
                });

            modelBuilder.Entity("DienstenCheques.Models.Domain.Prestatie", b =>
                {
                    b.Property<int>("PrestatieId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AantalUren");

                    b.Property<bool>("Betaald");

                    b.Property<DateTime>("DatumPrestatie");

                    b.Property<int?>("GebruikersNummer")
                        .IsRequired();

                    b.Property<int?>("OndernemingId")
                        .IsRequired();

                    b.Property<int>("PrestatieType");

                    b.HasKey("PrestatieId");

                    b.HasIndex("GebruikersNummer");

                    b.HasIndex("OndernemingId");

                    b.ToTable("Prestatie");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DienstenCheques.Models.Domain.Bestelling", b =>
                {
                    b.HasOne("DienstenCheques.Models.Domain.Gebruiker")
                        .WithMany("Bestellingen")
                        .HasForeignKey("GebruikersNummer");
                });

            modelBuilder.Entity("DienstenCheques.Models.Domain.DienstenCheque", b =>
                {
                    b.HasOne("DienstenCheques.Models.Domain.Gebruiker")
                        .WithMany("Portefeuille")
                        .HasForeignKey("GebruikersNummer");

                    b.HasOne("DienstenCheques.Models.Domain.Prestatie", "Prestatie")
                        .WithMany()
                        .HasForeignKey("PrestatieId");
                });

            modelBuilder.Entity("DienstenCheques.Models.Domain.Prestatie", b =>
                {
                    b.HasOne("DienstenCheques.Models.Domain.Gebruiker")
                        .WithMany("Prestaties")
                        .HasForeignKey("GebruikersNummer");

                    b.HasOne("DienstenCheques.Models.Domain.Onderneming", "Onderneming")
                        .WithMany()
                        .HasForeignKey("OndernemingId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DienstenCheques.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DienstenCheques.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DienstenCheques.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
