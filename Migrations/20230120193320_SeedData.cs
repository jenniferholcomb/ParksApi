using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParksApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 5);
        }
    }
}
