using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Timing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timings_AspNetUsers_DoctorId1",
                table: "Timings");

            migrationBuilder.DropIndex(
                name: "IX_Timings_DoctorId1",
                table: "Timings");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Timings");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Timings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Timings_DoctorId",
                table: "Timings",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_AspNetUsers_DoctorId",
                table: "Timings",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timings_AspNetUsers_DoctorId",
                table: "Timings");

            migrationBuilder.DropIndex(
                name: "IX_Timings_DoctorId",
                table: "Timings");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Timings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "Timings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timings_DoctorId1",
                table: "Timings",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Timings_AspNetUsers_DoctorId1",
                table: "Timings",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
