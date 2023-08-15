﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using noteCodeAPI.Tools;

#nullable disable

namespace noteCodeAPI.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20230815010445_init_postgres_db")]
    partial class initpostgresdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CodetagNote", b =>
                {
                    b.Property<int>("CodetagsId")
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    b.Property<Guid>("NotesId")
                        .HasColumnType("uuid")
                        .HasColumnName("note_id");

                    b.HasKey("CodetagsId", "NotesId");

                    b.HasIndex("NotesId");

                    b.ToTable("notes_tags", (string)null);
                });

            modelBuilder.Entity("noteCodeAPI.Models.CodeSnippet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("language");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uuid")
                        .HasColumnName("note_id");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("code_snippets");
                });

            modelBuilder.Entity("noteCodeAPI.Models.Codetag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("codetags");
                });

            modelBuilder.Entity("noteCodeAPI.Models.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("notes");
                });

            modelBuilder.Entity("noteCodeAPI.Models.UnusedActiveToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("expiration_date");

                    b.Property<string>("JwtToken")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.HasKey("Id");

                    b.ToTable("unused_active_tokens");
                });

            modelBuilder.Entity("noteCodeAPI.Models.UserApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("IsValid")
                        .HasColumnType("boolean")
                        .HasColumnName("is_valid");

                    b.Property<string>("PasswordHashed")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hashed");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_salt");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("CodetagNote", b =>
                {
                    b.HasOne("noteCodeAPI.Models.Codetag", null)
                        .WithMany()
                        .HasForeignKey("CodetagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("noteCodeAPI.Models.Note", null)
                        .WithMany()
                        .HasForeignKey("NotesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("noteCodeAPI.Models.CodeSnippet", b =>
                {
                    b.HasOne("noteCodeAPI.Models.Note", "Note")
                        .WithMany("Codes")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");
                });

            modelBuilder.Entity("noteCodeAPI.Models.Note", b =>
                {
                    b.HasOne("noteCodeAPI.Models.UserApp", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("noteCodeAPI.Models.Note", b =>
                {
                    b.Navigation("Codes");
                });

            modelBuilder.Entity("noteCodeAPI.Models.UserApp", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}