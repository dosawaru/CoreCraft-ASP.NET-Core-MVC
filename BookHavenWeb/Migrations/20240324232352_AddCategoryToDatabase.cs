using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHavenWeb.Migrations
{
    public partial class AddCategoryToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create table "Categories"
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Auto-incrementing primary key
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false), // Name of the category, required field
                    DisplayOrder = table.Column<int>(type: "int", nullable: false), // Display order of the category
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false) // Date and time when the category was created
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id); // Primary key constraint
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop table "Categories"
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
