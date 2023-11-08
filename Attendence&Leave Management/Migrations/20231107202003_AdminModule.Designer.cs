﻿// <auto-generated />
using System;
using Attendence_Leave_Management.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Attendence_Leave_Management.Migrations
{
    [DbContext(typeof(Attendance_Leave_Context))]
    [Migration("20231107202003_AdminModule")]
    partial class AdminModule
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Attendence_Leave_Management.Model.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Attendence_Leave_Management.Model.Attendance", b =>
                {
                    b.Property<int>("AttendenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendenceId"));

                    b.Property<string>("ApprovalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employeename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PresenceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectCode")
                        .HasColumnType("int");

                    b.HasKey("AttendenceId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectCode");

                    b.ToTable("AttendenceData");
                });

            modelBuilder.Entity("Attendence_Leave_Management.Model.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeUname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectCode")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ProjectCode");

                    b.ToTable("EmployeeData");
                });

            modelBuilder.Entity("Attendence_Leave_Management.Model.Leaves", b =>
                {
                    b.Property<int>("LeaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveId"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeaveDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeaveStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LeaveId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectCode");

                    b.ToTable("LeaveData");
                });

            modelBuilder.Entity("Attendence_Leave_Management.Model.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagerId"));

                    b.Property<string>("ManagerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerUname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectCode")
                        .HasColumnType("int");

                    b.HasKey("ManagerId");

                    b.HasIndex("ProjectCode");

                    b.ToTable("ManagerData");
                });

            modelBuilder.Entity("Attendence_Leave_Management.Model.Project", b =>
                {
                    b.Property<int>("ProjectCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectCode"));

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectTechnology")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectCode");

                    b.ToTable("ProjectData");
                });

            modelBuilder.Entity("Attendence_Leave_Management.Model.Attendance", b =>
                {
                    b.HasOne("Attendence_Leave_Management.Model.Employees", "employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendence_Leave_Management.Model.Project", "project")
                        .WithMany()
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("Attendence_Leave_Management.Model.Employees", b =>
                {
                    b.HasOne("Attendence_Leave_Management.Model.Manager", "manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("Attendence_Leave_Management.Model.Project", "project")
                        .WithMany()
                        .HasForeignKey("ProjectCode");

                    b.Navigation("manager");

                    b.Navigation("project");
                });

            modelBuilder.Entity("Attendence_Leave_Management.Model.Leaves", b =>
                {
                    b.HasOne("Attendence_Leave_Management.Model.Employees", "employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Attendence_Leave_Management.Model.Project", "project")
                        .WithMany()
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("Attendence_Leave_Management.Model.Manager", b =>
                {
                    b.HasOne("Attendence_Leave_Management.Model.Project", "project")
                        .WithMany()
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("project");
                });
#pragma warning restore 612, 618
        }
    }
}