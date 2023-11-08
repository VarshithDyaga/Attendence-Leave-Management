using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendence_Leave_Management.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectData",
                columns: table => new
                {
                    ProjectCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTechnology = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectData", x => x.ProjectCode);
                });

            migrationBuilder.CreateTable(
                name: "ManagerData",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerUname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerData", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_ManagerData_ProjectData_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "ProjectData",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeData",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeUname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeData", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeeData_ManagerData_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "ManagerData",
                        principalColumn: "ManagerId");
                    table.ForeignKey(
                        name: "FK_EmployeeData_ProjectData_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "ProjectData",
                        principalColumn: "ProjectCode");
                });

            migrationBuilder.CreateTable(
                name: "AttendenceData",
                columns: table => new
                {
                    AttendenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectCode = table.Column<int>(type: "int", nullable: false),
                    Employeename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresenceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendenceData", x => x.AttendenceId);
                    table.ForeignKey(
                        name: "FK_AttendenceData_EmployeeData_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeData",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendenceData_ProjectData_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "ProjectData",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveData",
                columns: table => new
                {
                    LeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ProjectCode = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveData", x => x.LeaveId);
                    table.ForeignKey(
                        name: "FK_LeaveData_EmployeeData_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeData",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_LeaveData_ProjectData_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "ProjectData",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendenceData_EmployeeId",
                table: "AttendenceData",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendenceData_ProjectCode",
                table: "AttendenceData",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeData_ManagerId",
                table: "EmployeeData",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeData_ProjectCode",
                table: "EmployeeData",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveData_EmployeeId",
                table: "LeaveData",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveData_ProjectCode",
                table: "LeaveData",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerData_ProjectCode",
                table: "ManagerData",
                column: "ProjectCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AttendenceData");

            migrationBuilder.DropTable(
                name: "LeaveData");

            migrationBuilder.DropTable(
                name: "EmployeeData");

            migrationBuilder.DropTable(
                name: "ManagerData");

            migrationBuilder.DropTable(
                name: "ProjectData");
        }
    }
}
