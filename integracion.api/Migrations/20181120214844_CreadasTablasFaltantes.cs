using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace integracion.api.Migrations
{
    public partial class CreadasTablasFaltantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_RosterType_RosterTypeId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RosterType",
                table: "RosterType");

            migrationBuilder.RenameTable(
                name: "RosterType",
                newName: "RosterTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RosterTypes",
                table: "RosterTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GeneralLedgers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    MovementType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralLedgers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    DeductionTypeId = table.Column<int>(nullable: true),
                    EntryTypeId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    EmployeeId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_DeductionTypes_DeductionTypeId",
                        column: x => x.DeductionTypeId,
                        principalTable: "DeductionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_EntryTypes_EntryTypeId",
                        column: x => x.EntryTypeId,
                        principalTable: "EntryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgers_EmployeeId",
                table: "GeneralLedgers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DeductionTypeId",
                table: "Transactions",
                column: "DeductionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeId1",
                table: "Transactions",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EntryTypeId",
                table: "Transactions",
                column: "EntryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_RosterTypes_RosterTypeId",
                table: "Employees",
                column: "RosterTypeId",
                principalTable: "RosterTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_RosterTypes_RosterTypeId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "GeneralLedgers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RosterTypes",
                table: "RosterTypes");

            migrationBuilder.RenameTable(
                name: "RosterTypes",
                newName: "RosterType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RosterType",
                table: "RosterType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_RosterType_RosterTypeId",
                table: "Employees",
                column: "RosterTypeId",
                principalTable: "RosterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
