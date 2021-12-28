using HRMS.Core.Entities.LeadManagement;
using HRMS.Core.Entities.Master;
using HRMS.Core.Entities.Payroll;
using HRMS.Core.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace HRMS.Core.Entities.Common
{
    /// <summary>
    /// This is the context class which is used to connect to database
    /// </summary>
    public class HRMSContext: DbContext
    {
        private readonly string _connectionString;

        public HRMSContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public HRMSContext(IConfiguration configuration,string dbName)
        {
            _connectionString = configuration.GetSection($"ConnectionStrings:{dbName}").Value;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connectionString for the DataBase Migration
            //server=122.160.49.247,1433; Database=Payroll_Devlopment;User Id=SqlAdmin;Password=SqlAdmin@123
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().Property("CreatedDate").HasDefaultValue(DateTime.Now);
        }

        #region Master

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<SalaryHeads> SalaryHeads { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
        public virtual DbSet<EmployeeNonCTC> EmployeeNonCTCs { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; }
        public virtual DbSet<CustomerLeadDetail> CustomerLeadDetails { get; set; }
        public virtual DbSet<RoleMaster> RoleMasters { get; set; }
        public virtual DbSet<ModuleMaster> ModuleMasters { get; set; }
        public virtual DbSet<SubModuleMaster> SubModuleMasters { get; set; }
        public virtual DbSet<RoleAccess> RoleAccesses { get; set; }
        public virtual DbSet<AuthenticateUser> AuthenticateUsers { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }
        public virtual DbSet<LeadType> LeadTypes { get; set; }
        public virtual DbSet<CustomerSecondryDetail> CustomerSecondryDetails { get; set; }
        public virtual DbSet<CustomerLead> CustomerLeads { get; set; }
        public virtual DbSet<CustomerCallingDetails> CustomerCallingDetails { get; set; }
        public virtual DbSet<CustomerLeadCloserForm> CustomerLeadCloserForms { get; set; }

        #endregion
    }
}
