using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onpmysql.Migrations
{
    /// <inheritdoc />
    public partial class AzureMigrationOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "twitter",
                columns: table => new
                {
                    C0 = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Geo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sentiment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_twitter", x => x.C0);
                });

            migrationBuilder.CreateTable(
                name: "zomato_restaurants",
                columns: table => new
                {
                    restaurant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurant_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    country_code = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locality = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    locality_verbose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longitude = table.Column<double>(type: "double", nullable: true),
                    latitude = table.Column<double>(type: "double", nullable: true),
                    cuisines = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    average_cost_for_two = table.Column<int>(type: "int", nullable: true),
                    currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    has_table_booking = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    has_online_delivery = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    is_delivering_now = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    switch_to_order_menu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    price_range = table.Column<int>(type: "int", nullable: true),
                    aggregate_rating = table.Column<double>(type: "float", nullable: true),
                    rating_color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rating_text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    votes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zomato_restaurants", x => x.restaurant_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "twitter");

            migrationBuilder.DropTable(
                name: "zomato_restaurants");
        }
    }
}
