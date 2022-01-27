using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.CheckingAccount.Repository.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateOfModify = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateOfExclusion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateOfCreation = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateOfModify = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateOfExclusion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Debits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateOfCreation = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateOfModify = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateOfExclusion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debits_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_ClientId",
                table: "Credits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Debits_ClientId",
                table: "Debits",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Debits");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
