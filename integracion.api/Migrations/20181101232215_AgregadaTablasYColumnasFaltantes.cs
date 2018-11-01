using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace integracion.api.Migrations
{
    public partial class AgregadaTablasYColumnasFaltantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "EntryTypes",
                newName: "Disabled");

            migrationBuilder.RenameColumn(
                name: "RosterId",
                table: "Employees",
                newName: "RosterTypeId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "DeductionTypes",
                newName: "Disabled");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "EntryTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "DeductionTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RosterType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RosterType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RosterTypeId",
                table: "Employees",
                column: "RosterTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_RosterType_RosterTypeId",
                table: "Employees",
                column: "RosterTypeId",
                principalTable: "RosterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_RosterType_RosterTypeId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "RosterType");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RosterTypeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "EntryTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "DeductionTypes");

            migrationBuilder.RenameColumn(
                name: "Disabled",
                table: "EntryTypes",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "RosterTypeId",
                table: "Employees",
                newName: "RosterId");

            migrationBuilder.RenameColumn(
                name: "Disabled",
                table: "DeductionTypes",
                newName: "Status");
        }
    }
}
