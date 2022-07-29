using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerASPNET.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagersId",
                table: "Projects",
                column: "ProjectManagersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_ProjectManagersId",
                table: "Projects",
                column: "ProjectManagersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_ProjectManagersId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectManagersId",
                table: "Projects");
        }
    }
}
