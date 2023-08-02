﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using noteCodeAPI.Tools;

#nullable disable

namespace noteCodeAPI.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20230802100257_renaming_joint_table")]
    partial class renamingjointtable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodetagNote", b =>
                {
                    b.Property<int>("CodetagsId")
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    b.Property<int>("NotesId")
                        .HasColumnType("int")
                        .HasColumnName("note_id");

                    b.HasKey("CodetagsId", "NotesId");

                    b.HasIndex("NotesId");

                    b.ToTable("notes_tags", (string)null);
                });

            modelBuilder.Entity("noteCodeAPI.Models.CodeSnippet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("language");

                    b.Property<int>("NoteId")
                        .HasColumnType("int")
                        .HasColumnName("note_id");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("code_snippet");
                });

            modelBuilder.Entity("noteCodeAPI.Models.Codetag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("codetag");
                });

            modelBuilder.Entity("noteCodeAPI.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("note");
                });

            modelBuilder.Entity("noteCodeAPI.Models.TagAlias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodetagId")
                        .HasColumnType("int")
                        .HasColumnName("codetag_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CodetagId");

                    b.ToTable("codetag_alias");
                });

            modelBuilder.Entity("noteCodeAPI.Models.UnusedActiveToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("expiration_date");

                    b.Property<string>("JwtToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("token");

                    b.HasKey("Id");

                    b.ToTable("unused_active_token");
                });

            modelBuilder.Entity("noteCodeAPI.Models.UserApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHashed")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password_hashed");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password_salt");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("noteCodeAPI.Models.WaitingUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHashed")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password_hashed");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password_salt");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("waiting_users");
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

            modelBuilder.Entity("noteCodeAPI.Models.TagAlias", b =>
                {
                    b.HasOne("noteCodeAPI.Models.Codetag", "Codetag")
                        .WithMany("Aliases")
                        .HasForeignKey("CodetagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Codetag");
                });

            modelBuilder.Entity("noteCodeAPI.Models.Codetag", b =>
                {
                    b.Navigation("Aliases");
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
