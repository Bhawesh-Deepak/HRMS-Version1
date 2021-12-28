using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS.Core.Entities.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Payroll");

            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.CreateTable(
                name: "Attandence",
                schema: "Payroll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateYear = table.Column<int>(type: "int", nullable: false),
                    DateMonth = table.Column<int>(type: "int", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    LOPDays = table.Column<int>(type: "int", nullable: false),
                    PresentDays = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attandence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2021, 11, 6, 8, 55, 56, 544, DateTimeKind.Local).AddTicks(1563)),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeNonCTCComponent",
                schema: "Payroll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateMonth = table.Column<int>(type: "int", nullable: false),
                    DateYear = table.Column<int>(type: "int", nullable: false),
                    EmpCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatuaryBonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PerformanceIncentive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JoiningBonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoticePay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverTimePay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NPSEarning = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PerformaceLinkedPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PerformanceLinkedPayB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BooksAndPeriodicalTaxable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarMaintainenceTaxable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GratuityPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeaveEncashment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoldSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ParentalMediclaim = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherRecovery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MiscleneousDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LabourWelfare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanOther = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MobileDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoticeRecovery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryAdvanceDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodCouponDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssetsRecovery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TravelDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EPFRecovery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NPS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ARRVPF_Deduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeNonCTCComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryHeads",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDependOnDay = table.Column<bool>(type: "bit", nullable: false),
                    HeadType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisplayOnPaySlip = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinancialYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryHeads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attandence",
                schema: "Payroll");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Designation",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "EmployeeNonCTCComponent",
                schema: "Payroll");

            migrationBuilder.DropTable(
                name: "SalaryHeads",
                schema: "Master");
        }
    }
}
