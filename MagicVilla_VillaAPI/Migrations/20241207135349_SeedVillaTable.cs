using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6519), "Dummy Details", "https://placehold.co/100x100", "Royal Villa", 5, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Fireplace, Garden", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6580), "Charming cottage surrounded by nature.", "https://placehold.co/100x100", "Cozy Cottage", 4, 150.0, 450, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Beach Access, BBQ Area", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6589), "A villa with stunning ocean views.", "https://placehold.co/100x100", "Beachfront Bungalow", 6, 300.0, 600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Hiking Trails, Fireplace", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6597), "Peaceful retreat with breathtaking mountain views.", "https://placehold.co/100x100", "Mountain Retreat", 5, 250.0, 520, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Rooftop Terrace, High-Speed Wi-Fi", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6604), "Modern villa located in the heart of the city.", "https://placehold.co/100x100", "Cityscape Loft", 3, 180.0, 400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Kayak Rental, Fishing Dock", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6612), "Relaxing villa by the lake.", "https://placehold.co/100x100", "Lakeside Lodge", 7, 280.0, 700, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Pool, Outdoor Lounge", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6619), "Exotic villa in a desert landscape.", "https://placehold.co/100x100", "Desert Oasis", 5, 220.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Library, Wine Cellar", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6626), "Elegant villa with historic charm.", "https://placehold.co/100x100", "Historic Manor", 8, 350.0, 800, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Outdoor Shower, Hammock", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6633), "Secluded villa surrounded by lush jungle.", "https://placehold.co/100x100", "Jungle Hideaway", 4, 170.0, 480, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Ski-in/Ski-out, Hot Tub", new DateTime(2024, 12, 7, 13, 53, 48, 96, DateTimeKind.Local).AddTicks(6640), "Cozy villa with stunning snowy views.", "https://placehold.co/100x100", "Snowy Chalet", 6, 310.0, 650, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
