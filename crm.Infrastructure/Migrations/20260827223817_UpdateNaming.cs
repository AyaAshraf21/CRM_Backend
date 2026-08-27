using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Governates_GovernorateId",
                table: "Areas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Governates",
                table: "Governates");

            migrationBuilder.RenameTable(
                name: "Governates",
                newName: "Governorates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Governorates",
                table: "Governorates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Governorates_GovernorateId",
                table: "Areas",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Governorates_GovernorateId",
                table: "Areas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Governorates",
                table: "Governorates");

            migrationBuilder.RenameTable(
                name: "Governorates",
                newName: "Governates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Governates",
                table: "Governates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Governates_GovernorateId",
                table: "Areas",
                column: "GovernorateId",
                principalTable: "Governates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
