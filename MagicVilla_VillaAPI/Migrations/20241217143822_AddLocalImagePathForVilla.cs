using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalImagePathForVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLocalPath",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8031), null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8117), null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8129), null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8139), null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8149), null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8158), null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8168), null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8178), null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8188), null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageLocalPath" },
                values: new object[] { new DateTime(2024, 12, 17, 14, 38, 20, 834, DateTimeKind.Local).AddTicks(8198), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLocalPath",
                table: "Villas");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 436, DateTimeKind.Local).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 436, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 436, DateTimeKind.Local).AddTicks(9898));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 436, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 436, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 436, DateTimeKind.Local).AddTicks(9921));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 437, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 437, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 437, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 17, 35, 14, 437, DateTimeKind.Local).AddTicks(90));
        }
    }
}
