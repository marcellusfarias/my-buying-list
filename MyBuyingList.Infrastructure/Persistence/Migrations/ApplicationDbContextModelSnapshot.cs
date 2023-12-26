﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBuyingList.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBuyingList.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyBuyingList.Domain.Entities.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_policies");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_policies_name");

                    b.ToTable("policies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "UserCreate"
                        },
                        new
                        {
                            Id = 2,
                            Name = "UserUpdate"
                        },
                        new
                        {
                            Id = 3,
                            Name = "UserDelete"
                        },
                        new
                        {
                            Id = 4,
                            Name = "UserGetAll"
                        },
                        new
                        {
                            Id = 5,
                            Name = "UserGet"
                        });
                });

            modelBuilder.Entity("MyBuyingList.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK_roles_id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_roles_name");

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Name = "RegularUser"
                        });
                });

            modelBuilder.Entity("MyBuyingList.Domain.Entities.RolePolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("PolicyId")
                        .HasColumnType("integer")
                        .HasColumnName("policy_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_role_policies");

                    b.HasAlternateKey("RoleId", "PolicyId")
                        .HasName("ak_role_policies_role_id_policy_id");

                    b.HasIndex("PolicyId")
                        .HasDatabaseName("ix_role_policies_policy_id");

                    b.ToTable("role_policies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PolicyId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            PolicyId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            PolicyId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            PolicyId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 5,
                            PolicyId = 5,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("MyBuyingList.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("active")
                        .HasDefaultValueSql("FALSE");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(72)
                        .HasColumnType("character varying(72)")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("PK_users_id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasDatabaseName("ix_users_user_name");

                    b.ToTable("users", null, t =>
                        {
                            t.HasCheckConstraint("CHK_Username_MinLength", "(length(user_name) >= 3)");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "marcelluscfarias@gmail.com",
                            Password = "$2a$16$CZ18qbFWtcoAY6SnsqNYnO1H.D3It5TTD6uuhTFyjge5I/n5SRLKe",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("MyBuyingList.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_roles");

                    b.HasAlternateKey("RoleId", "UserId")
                        .HasName("ak_user_roles_role_id_user_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_roles_user_id");

                    b.ToTable("user_roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MyBuyingList.Domain.Entities.RolePolicy", b =>
                {
                    b.HasOne("MyBuyingList.Domain.Entities.Policy", "Policy")
                        .WithMany("RolePolicies")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_role_policies_policies_policy_id");

                    b.HasOne("MyBuyingList.Domain.Entities.Role", "Role")
                        .WithMany("RolePolicies")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_role_policies_roles_role_id");

                    b.Navigation("Policy");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MyBuyingList.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("MyBuyingList.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_roles_role_id");

                    b.HasOne("MyBuyingList.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_users_user_id");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBuyingList.Domain.Entities.Policy", b =>
                {
                    b.Navigation("RolePolicies");
                });

            modelBuilder.Entity("MyBuyingList.Domain.Entities.Role", b =>
                {
                    b.Navigation("RolePolicies");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MyBuyingList.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
