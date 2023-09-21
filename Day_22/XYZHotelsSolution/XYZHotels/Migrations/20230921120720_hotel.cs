using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XYZHotels.Migrations
{
    public partial class hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HotelName = table.Column<string>(type: "text", nullable: false),
                    Facility = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<byte[]>(type: "bytea", nullable: false),
                    Key = table.Column<byte[]>(type: "bytea", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    RoomId = table.Column<string>(type: "text", nullable: false),
                    BedType = table.Column<string>(type: "text", nullable: false),
                    Balcony = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_rooms_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "HotelId", "Facility", "HotelName" },
                values: new object[,]
                {
                    { 1, "Lake-Side", "PQR" },
                    { 2, "Main-Road", "STU" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "RoomId", "Balcony", "BedType", "HotelId", "Price" },
                values: new object[,]
                {
                    { "1", true, "Single", 1, 10000f },
                    { "2", false, "Double", 1, 8000.5f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_rooms_HotelId",
                table: "rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "hotels");
        }
    }
}
