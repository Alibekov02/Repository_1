using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stroy.kg.Migrations
{
    /// <inheritdoc />
    public partial class addApplicationTypeToProduct2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Product2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product2_ApplicationId",
                table: "Product2",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product2_ApplicationType_ApplicationId",
                table: "Product2",
                column: "ApplicationId",
                principalTable: "ApplicationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product2_ApplicationType_ApplicationId",
                table: "Product2");

            migrationBuilder.DropIndex(
                name: "IX_Product2_ApplicationId",
                table: "Product2");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Product2");
        }
    }
}
