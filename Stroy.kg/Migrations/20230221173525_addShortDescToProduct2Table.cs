using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stroy.kg.Migrations
{
    /// <inheritdoc />
    public partial class addShortDescToProduct2Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDesc",
                table: "Product2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDesc",
                table: "Product2");
        }
    }
}
