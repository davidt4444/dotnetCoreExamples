using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace BCS.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    uniqueId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    content = table.Column<string>(type: "varchar(10000)", maxLength: 10000, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    author = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    likesCount = table.Column<int>(type: "int", nullable: false),
                    authorId = table.Column<int>(type: "int", nullable: true),
                    isPublished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
