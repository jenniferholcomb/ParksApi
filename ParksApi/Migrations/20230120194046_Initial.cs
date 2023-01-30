using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParksApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Terrain = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Features = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Features", "Location", "Name", "State", "Terrain", "Type" },
                values: new object[,]
                {
                    { 1, "beach, hiking, lookouts, camping", "Tillamook County", "Cape Lookout State Park", "Oregon", "coastal, old-growth forest, high cliffs, rugged", "coast" },
                    { 2, "hiking, springtime wildflowers, wheelchair access loops", "Portland", "Tyron Creek State Natural Area", "Oregon", "woodsy ravine, creek", "city" },
                    { 3, "hiking, wheelchair access loops, viewpoints", "Gifford Pinchot National Forest", "Mt St Helens National Volcanic Monument", "Washington", "volcanic, old-growth forest, lakes, waterfalls in canyon", "mountain" },
                    { 4, "overlooks of Columbia River, spring wildflowers, wheelchair accessible loop", "Columbia Gorge", "Beacon Rock State Park", "Washington", "rocky near clifftops, forest, river", "gorge" },
                    { 5, "rock climbing, camping, hiking", "Terrebone", "Smith Rock State Park", "Oregon", "steep cliffs, river", "high desert" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
