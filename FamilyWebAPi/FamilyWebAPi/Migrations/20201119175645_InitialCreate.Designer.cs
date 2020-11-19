﻿// <auto-generated />
using System;
using FamilyWebAPi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyWebAPi.Migrations
{
    [DbContext(typeof(FamilyDBContext))]
    [Migration("20201119175645_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DNPAssigment1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<int>("SecurityLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Adult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Adult");
                });

            modelBuilder.Entity("Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EyeColor")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("Models.ChildInterest", b =>
                {
                    b.Property<string>("InterestId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChildId")
                        .HasColumnType("INTEGER");

                    b.HasKey("InterestId", "ChildId");

                    b.HasIndex("ChildId");

                    b.ToTable("ChildInterest");
                });

            modelBuilder.Entity("Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Models.Interest", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Type");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("Models.Adult", b =>
                {
                    b.HasOne("Models.Family", null)
                        .WithMany("Adults")
                        .HasForeignKey("FamilyId");
                });

            modelBuilder.Entity("Models.Child", b =>
                {
                    b.HasOne("Models.Family", null)
                        .WithMany("Children")
                        .HasForeignKey("FamilyId");
                });

            modelBuilder.Entity("Models.ChildInterest", b =>
                {
                    b.HasOne("Models.Child", "Child")
                        .WithMany("ChildInterests")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Interest", "Interest")
                        .WithMany("ChildInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Interest");
                });

            modelBuilder.Entity("Models.Pet", b =>
                {
                    b.HasOne("Models.Child", null)
                        .WithMany("Pets")
                        .HasForeignKey("ChildId");

                    b.HasOne("Models.Family", null)
                        .WithMany("Pets")
                        .HasForeignKey("FamilyId");
                });

            modelBuilder.Entity("Models.Child", b =>
                {
                    b.Navigation("ChildInterests");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Models.Family", b =>
                {
                    b.Navigation("Adults");

                    b.Navigation("Children");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Models.Interest", b =>
                {
                    b.Navigation("ChildInterests");
                });
#pragma warning restore 612, 618
        }
    }
}
