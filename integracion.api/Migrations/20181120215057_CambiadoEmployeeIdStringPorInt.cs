using Microsoft.EntityFrameworkCore.Migrations;

namespace integracion.api.Migrations
{
    public partial class CambiadoEmployeeIdStringPorInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Employees_EmployeeId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_EmployeeId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeId",
                table: "Transactions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Employees_EmployeeId",
                table: "Transactions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Employees_EmployeeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_EmployeeId",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "Transactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeId1",
                table: "Transactions",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Employees_EmployeeId1",
                table: "Transactions",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
