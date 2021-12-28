using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS.Core.Entities.Migrations
{
    public partial class HRMS1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Master",
                table: "Department",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 6, 23, 49, 27, 938, DateTimeKind.Local).AddTicks(2658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 6, 8, 55, 56, 544, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.CreateTable(
                name: "EmployeeDetail",
                schema: "Payroll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployementStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAndLHeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperVisorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PanCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AadharCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExprience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationalQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecruitmentSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruitmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BiometricCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIPStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIPEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsAppNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoticePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfMairrage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmergencyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyRelationWithEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UANNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESICNew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveSupervisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IJPLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftTiming = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAndFBankAccountNumberx = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESICPreviousNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Induction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VISANumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VISADate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaxFileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupernationAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoutingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternateMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchOfficeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HolidayGroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsESICEligible = table.Column<bool>(type: "bit", nullable: false),
                    LandLineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveApprover1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveApprover2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EmployeeDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalaryDetail",
                schema: "Payroll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConvenanceAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EducationAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodCouponAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HouseRentAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LTARiembursement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicalAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecialAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TelephoneAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UniformReimburesement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookAndPriodical = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarRunningAndMaintainence = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PACover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MediClaimAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PFDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ESIDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PTStateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPFEligible = table.Column<bool>(type: "bit", nullable: false),
                    LWFDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PLP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeSalaryDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetail",
                schema: "Payroll");

            migrationBuilder.DropTable(
                name: "EmployeeSalaryDetail",
                schema: "Payroll");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Master",
                table: "Department",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 6, 8, 55, 56, 544, DateTimeKind.Local).AddTicks(1563),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 6, 23, 49, 27, 938, DateTimeKind.Local).AddTicks(2658));
        }
    }
}
