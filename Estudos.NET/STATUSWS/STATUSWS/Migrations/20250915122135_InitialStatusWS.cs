using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StatusWS.Migrations
{
    /// <inheritdoc />
    public partial class InitialStatusWS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusTypes",
                columns: table => new
                {
                    StatusTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypes", x => x.StatusTypeId);
                });

            migrationBuilder.InsertData(
                table: "StatusTypes",
                columns: new[] { "StatusTypeId", "Description", "IconUrl" },
                values: new object[,]
                {
                    { 1, "Sem status definido", "https://cdn-icons-png.flaticon.com/512/4785/4785876.png" },
                    { 2, "Codando", "https://cdn-icons-png.flaticon.com/512/4785/4785876.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusTypes");
        }
    }
}
