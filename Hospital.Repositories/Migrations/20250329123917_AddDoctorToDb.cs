using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HospitalInfos_hospitalInfoId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_hospitalInfoId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "hospitalInfoId",
                table: "Rooms");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "HospitalInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDoctor",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HospitalId",
                table: "Rooms",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HospitalInfos_HospitalId",
                table: "Rooms",
                column: "HospitalId",
                principalTable: "HospitalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HospitalInfos_HospitalId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HospitalId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsDoctor",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "hospitalInfoId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "HospitalInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_hospitalInfoId",
                table: "Rooms",
                column: "hospitalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HospitalInfos_hospitalInfoId",
                table: "Rooms",
                column: "hospitalInfoId",
                principalTable: "HospitalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
