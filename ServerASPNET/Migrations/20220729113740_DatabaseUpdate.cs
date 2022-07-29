using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerASPNET.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProjectToEmployees_EmployeesId",
                table: "ProjectToEmployees",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectToEmployees_ProjectId",
                table: "ProjectToEmployees",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyCustomersId",
                table: "Projects",
                column: "CompanyCustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PerformingCompanyId",
                table: "Projects",
                column: "PerformingCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_CompanyCustomers_CompanyCustomersId",
                table: "Projects",
                column: "CompanyCustomersId",
                principalTable: "CompanyCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_PerformingCompany_PerformingCompanyId",
                table: "Projects",
                column: "PerformingCompanyId",
                principalTable: "PerformingCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectToEmployees_Employees_EmployeesId",
                table: "ProjectToEmployees",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectToEmployees_Projects_ProjectId",
                table: "ProjectToEmployees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CompanyCustomers_CompanyCustomersId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_PerformingCompany_PerformingCompanyId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectToEmployees_Employees_EmployeesId",
                table: "ProjectToEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectToEmployees_Projects_ProjectId",
                table: "ProjectToEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProjectToEmployees_EmployeesId",
                table: "ProjectToEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProjectToEmployees_ProjectId",
                table: "ProjectToEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CompanyCustomersId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PerformingCompanyId",
                table: "Projects");
        }
    }
}
