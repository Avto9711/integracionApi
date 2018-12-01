using Microsoft.EntityFrameworkCore.Migrations;

namespace integracion.api.Migrations
{
    public partial class DeletedEmployeeIdInGeneralLedger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralLedgers_Employees_EmployeeId",
                table: "GeneralLedgers");

            migrationBuilder.DropIndex(
                name: "IX_GeneralLedgers_EmployeeId",
                table: "GeneralLedgers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "GeneralLedgers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "GeneralLedgers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgers_EmployeeId",
                table: "GeneralLedgers",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralLedgers_Employees_EmployeeId",
                table: "GeneralLedgers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
