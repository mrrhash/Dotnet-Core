using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudWithjQueryAjax.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Mobile = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
