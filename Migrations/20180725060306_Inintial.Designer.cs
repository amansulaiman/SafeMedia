﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hateSpeach.Models;

namespace SafeMedia.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180725060306_Inintial")]
    partial class Inintial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("hateSpeach.Models.HateSpeechReport", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<DateTimeOffset?>("CreatedAt");

                    b.Property<string>("EvidanceLink");

                    b.Property<string>("HateText");

                    b.Property<int>("Language");

                    b.Property<string>("Source");

                    b.Property<string>("Target");

                    b.HasKey("Id");

                    b.ToTable("HateSpeechReports");
                });
#pragma warning restore 612, 618
        }
    }
}