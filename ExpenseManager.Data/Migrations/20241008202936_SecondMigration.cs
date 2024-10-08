using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_EmployeeIdId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "EmployeeIdId",
                table: "Expenses",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_EmployeeIdId",
                table: "Expenses",
                newName: "IX_Expenses_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_EmployeeId",
                table: "Expenses",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_EmployeeId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Expenses",
                newName: "EmployeeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_EmployeeId",
                table: "Expenses",
                newName: "IX_Expenses_EmployeeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_EmployeeIdId",
                table: "Expenses",
                column: "EmployeeIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
