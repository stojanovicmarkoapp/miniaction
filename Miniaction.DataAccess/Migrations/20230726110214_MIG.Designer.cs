﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Miniaction.DataAccess;

namespace Miniaction.DataAccess.Migrations
{
    [DbContext(typeof(MiniactionContext))]
    [Migration("20230726110214_MIG")]
    partial class MIG
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Miniaction.Domain.Entities.Avatar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Avatars");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Format", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Formats");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Grant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("UseCaseID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasAlternateKey("RoleID", "UseCaseID");

                    b.ToTable("Grants");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Network", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Option", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("FormatID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SerialID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasAlternateKey("SerialID", "FormatID");

                    b.HasIndex("FormatID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OptionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PaidAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OptionID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.PG", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PGs");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OptionID")
                        .HasColumnType("int");

                    b.Property<int>("StarID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasAlternateKey("OptionID", "UserID");

                    b.HasIndex("StarID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Serial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<int>("NetworkID")
                        .HasColumnType("int");

                    b.Property<int>("PGID")
                        .HasColumnType("int");

                    b.Property<int>("Released")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TrailerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GenreID");

                    b.HasIndex("NetworkID");

                    b.HasIndex("PGID");

                    b.HasIndex("Title");

                    b.HasIndex("TrailerID")
                        .IsUnique()
                        .HasFilter("[TrailerID] IS NOT NULL");

                    b.ToTable("Serials");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Star", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Score")
                        .IsUnique();

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.TrackEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActorID")
                        .HasColumnType("int");

                    b.Property<string>("ActorUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UseCaseData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UseCaseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TrackEntries");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Trailer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SerialID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SerialID")
                        .IsUnique();

                    b.ToTable("Trailers");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AvatarID")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("AvatarID")
                        .IsUnique()
                        .HasFilter("[AvatarID] IS NOT NULL");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.HasIndex("RoleID");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Grant", b =>
                {
                    b.HasOne("Miniaction.Domain.Entities.Role", "Role")
                        .WithMany("Grants")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Option", b =>
                {
                    b.HasOne("Miniaction.Domain.Entities.Format", "Format")
                        .WithMany("Options")
                        .HasForeignKey("FormatID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Miniaction.Domain.Entities.Serial", "Serial")
                        .WithMany("Options")
                        .HasForeignKey("SerialID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Format");

                    b.Navigation("Serial");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Order", b =>
                {
                    b.HasOne("Miniaction.Domain.Entities.Option", "Option")
                        .WithMany("Orders")
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Miniaction.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Review", b =>
                {
                    b.HasOne("Miniaction.Domain.Entities.Option", "Option")
                        .WithMany("Reviews")
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Miniaction.Domain.Entities.Star", "Star")
                        .WithMany("Reviews")
                        .HasForeignKey("StarID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Miniaction.Domain.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("Star");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Serial", b =>
                {
                    b.HasOne("Miniaction.Domain.Entities.Genre", "Genre")
                        .WithMany("Serials")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Miniaction.Domain.Entities.Network", "Network")
                        .WithMany("Serials")
                        .HasForeignKey("NetworkID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Miniaction.Domain.Entities.PG", "PG")
                        .WithMany("Serials")
                        .HasForeignKey("PGID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Network");

                    b.Navigation("PG");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Trailer", b =>
                {
                    b.HasOne("Miniaction.Domain.Entities.Serial", "Serial")
                        .WithOne("Trailer")
                        .HasForeignKey("Miniaction.Domain.Entities.Trailer", "SerialID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Serial");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.User", b =>
                {
                    b.HasOne("Miniaction.Domain.Entities.Avatar", "Avatar")
                        .WithOne("User")
                        .HasForeignKey("Miniaction.Domain.Entities.User", "AvatarID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Miniaction.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Avatar");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Avatar", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Format", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Genre", b =>
                {
                    b.Navigation("Serials");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Network", b =>
                {
                    b.Navigation("Serials");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Option", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.PG", b =>
                {
                    b.Navigation("Serials");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Role", b =>
                {
                    b.Navigation("Grants");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Serial", b =>
                {
                    b.Navigation("Options");

                    b.Navigation("Trailer");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.Star", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Miniaction.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
