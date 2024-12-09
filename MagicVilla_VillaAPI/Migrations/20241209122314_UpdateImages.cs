using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9016), "http://dotnetmastery.com/bluevillaimages/villa1.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9105), "http://dotnetmastery.com/bluevillaimages/villa2.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9116), "http://dotnetmastery.com/bluevillaimages/villa3.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9127), "http://dotnetmastery.com/bluevillaimages/villa4.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9138), "http://dotnetmastery.com/bluevillaimages/villa4.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9327), "http://dotnetmastery.com/bluevillaimages/villa5.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9340), "http://dotnetmastery.com/bluevillaimages/villa6.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9350), "http://dotnetmastery.com/bluevillaimages/villa7.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9361), "http://dotnetmastery.com/bluevillaimages/villa3.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 12, 23, 12, 674, DateTimeKind.Local).AddTicks(9371), "http://dotnetmastery.com/bluevillaimages/villa4.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(656), "https://placehold.co/100x100" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(726), "https://placehold.co/100x100" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(735), "https://placehold.co/100x100" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(743), "https://placehold.co/100x100" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(751), "https://placehold.co/100x100" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(760), "https://placehold.co/100x100" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(768), "https://placehold.co/100x100" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(775), "https://placehold.co/100x100" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(783), "https://placehold.co/100x100" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 9, 9, 13, 11, 90, DateTimeKind.Local).AddTicks(791), "https://placehold.co/100x100" });
        }
    }
}
