﻿// <auto-generated />
using System;
using CommanderTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CommanderTracker.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241118165012_Added Role To Pilot")]
    partial class AddedRoleToPilot
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CommanderTracker.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CommanderTracker.Models.Deck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("ColorIdentity")
                        .HasColumnType("integer")
                        .HasColumnName("color_identity");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("UpdatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("updated_by_id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("decks");
                });

            modelBuilder.Entity("CommanderTracker.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("notes");

                    b.Property<Guid>("PlayGroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("play_group_id");

                    b.Property<int>("Turns")
                        .HasColumnType("integer")
                        .HasColumnName("turns");

                    b.Property<string>("UpdatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("updated_by_id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PlayGroupId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("games");
                });

            modelBuilder.Entity("CommanderTracker.Models.Pilot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text")
                        .HasColumnName("app_user_id");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("PlayGroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("play_group_id");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<string>("UpdatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("updated_by_id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PlayGroupId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("pilots");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("UpdatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("updated_by_id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("play_groups");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayGroupAppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("app_user_id");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<Guid>("PlayGroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("play_group_id");

                    b.Property<string>("Test")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("updated_by_id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PlayGroupId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("play_group_app_users");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayGroupDeck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<Guid>("DeckId")
                        .HasColumnType("uuid")
                        .HasColumnName("deck_id");

                    b.Property<Guid?>("PilotId")
                        .HasColumnType("uuid")
                        .HasColumnName("pilot_id");

                    b.Property<Guid>("PlayGroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("play_group_id");

                    b.Property<string>("UpdatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("updated_by_id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeckId");

                    b.HasIndex("PilotId");

                    b.HasIndex("PlayGroupId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("play_group_decks");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("EndPosition")
                        .HasColumnType("integer")
                        .HasColumnName("end_position");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uuid")
                        .HasColumnName("game_id");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("notes");

                    b.Property<Guid>("PilotId")
                        .HasColumnType("uuid")
                        .HasColumnName("pilot_id");

                    b.Property<Guid>("PlayGroupDeckId")
                        .HasColumnType("uuid")
                        .HasColumnName("play_group_deck_id");

                    b.Property<int>("TurnOrder")
                        .HasColumnType("integer")
                        .HasColumnName("turn_order");

                    b.Property<string>("UpdatedById")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("updated_by_id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GameId");

                    b.HasIndex("PilotId");

                    b.HasIndex("PlayGroupDeckId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("play_instances");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CommanderTracker.Models.Deck", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("CommanderTracker.Models.Game", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.PlayGroup", "PlayGroup")
                        .WithMany("Games")
                        .HasForeignKey("PlayGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("PlayGroup");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("CommanderTracker.Models.Pilot", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", "AppUser")
                        .WithMany("Pilots")
                        .HasForeignKey("AppUserId");

                    b.HasOne("CommanderTracker.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.PlayGroup", "PlayGroup")
                        .WithMany("Pilots")
                        .HasForeignKey("PlayGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("CreatedBy");

                    b.Navigation("PlayGroup");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayGroup", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayGroupAppUser", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.PlayGroup", "PlayGroup")
                        .WithMany()
                        .HasForeignKey("PlayGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("CreatedBy");

                    b.Navigation("PlayGroup");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayGroupDeck", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.Deck", "Deck")
                        .WithMany("PlayGroupDecks")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.Pilot", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId");

                    b.HasOne("CommanderTracker.Models.PlayGroup", "PlayGroup")
                        .WithMany("PlayGroupDecks")
                        .HasForeignKey("PlayGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Deck");

                    b.Navigation("Pilot");

                    b.Navigation("PlayGroup");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayInstance", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.Game", "Game")
                        .WithMany("PlayInstances")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.Pilot", "Pilot")
                        .WithMany("PlayInstances")
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.PlayGroupDeck", "PlayGroupDeck")
                        .WithMany("PlayInstances")
                        .HasForeignKey("PlayGroupDeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.AppUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Game");

                    b.Navigation("Pilot");

                    b.Navigation("PlayGroupDeck");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderTracker.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CommanderTracker.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CommanderTracker.Models.AppUser", b =>
                {
                    b.Navigation("Pilots");
                });

            modelBuilder.Entity("CommanderTracker.Models.Deck", b =>
                {
                    b.Navigation("PlayGroupDecks");
                });

            modelBuilder.Entity("CommanderTracker.Models.Game", b =>
                {
                    b.Navigation("PlayInstances");
                });

            modelBuilder.Entity("CommanderTracker.Models.Pilot", b =>
                {
                    b.Navigation("PlayInstances");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayGroup", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Pilots");

                    b.Navigation("PlayGroupDecks");
                });

            modelBuilder.Entity("CommanderTracker.Models.PlayGroupDeck", b =>
                {
                    b.Navigation("PlayInstances");
                });
#pragma warning restore 612, 618
        }
    }
}
