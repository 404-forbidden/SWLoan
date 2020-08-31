using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SWLoan.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    AccountNo = table.Column<int>(nullable: false),
                    Bank = table.Column<string>(nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    RepaymentDate = table.Column<DateTime>(nullable: false),
                    UserNo = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.No);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
