using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GL.CompanyCatalog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Exchange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("a1c4e7b2-42b3-4e5d-b799-3f40b10f6a23"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Technology" },
                    { new Guid("b2d5f8c3-53c4-4f6e-a89a-4e51c21f7b34"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Aviation" },
                    { new Guid("c3e6d9d4-64d5-407f-b9ab-5f62d32f8c45"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Beverages" },
                    { new Guid("d4f7e1e5-75e6-4180-cabc-6a73e43f9d56"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Electronics" },
                    { new Guid("e5f8e2f6-86f7-4291-dbcd-7b84f54f0e67"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Automotive" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CategoryId", "CreatedBy", "CreatedDate", "Exchange", "ImageUrl", "Isin", "LastModifiedBy", "LastModifiedDate", "Name", "Ticker", "Website" },
                values: new object[,]
                {
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new Guid("b2d5f8c3-53c4-4f6e-a89a-4e51c21f7b34"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pink sheets", "https://logo.clearbit.com/britishairways.com", "US1104193065", null, null, "British Airways Plc", "BAIRY", "https://www.britishairways.com" },
                    { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), new Guid("d4f7e1e5-75e6-4180-cabc-6a73e43f9d56"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokyo Stock Exchange", "https://logo.clearbit.com/panasonic.com", "JP3866800000", null, null, "Panasonic Corp", "6752", "http://www.panasonic.co.jp" },
                    { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), new Guid("e5f8e2f6-86f7-4291-dbcd-7b84f54f0e67"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deutsche Börse", "https://logo.clearbit.com/porsche.com", "DE000PAH0038", null, null, "Porsche Automobil", "PAH3", "https://www.porsche.com/" },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), new Guid("c3e6d9d4-64d5-407f-b9ab-5f62d32f8c45"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euronext Amsterdam", "https://logo.clearbit.com/theheinekencompany.com", "NL0000009165", null, null, "Heineken NV", "HEIA", "https://www.theheinekencompany.com" },
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), new Guid("a1c4e7b2-42b3-4e5d-b799-3f40b10f6a23"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NASDAQ", "https://logo.clearbit.com/apple.com", "US0378331005", null, null, "Apple Inc.", "AAPL", "http://www.apple.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CategoryId",
                table: "Companies",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
