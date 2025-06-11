using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onpmysql.Migrations
{
    /// <inheritdoc />
    public partial class ZomatoMigrqtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_zomato_restaurants",
                table: "zomato_restaurants");

            migrationBuilder.RenameTable(
                name: "zomato_restaurants",
                newName: "zomatorestaurants");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "twitter",
                newName: "user");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "twitter",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Sentiment",
                table: "twitter",
                newName: "sentiment");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "twitter",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Geo",
                table: "twitter",
                newName: "geo");

            migrationBuilder.RenameColumn(
                name: "Entities",
                table: "twitter",
                newName: "entities");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "twitter",
                newName: "country");

            migrationBuilder.AlterColumn<long>(
                name: "votes",
                table: "zomatorestaurants",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "country_code",
                table: "zomatorestaurants",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "average_cost_for_two",
                table: "zomatorestaurants",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "restaurant_id",
                table: "zomatorestaurants",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_zomatorestaurants",
                table: "zomatorestaurants",
                column: "restaurant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_zomatorestaurants",
                table: "zomatorestaurants");

            migrationBuilder.RenameTable(
                name: "zomatorestaurants",
                newName: "zomato_restaurants");

            migrationBuilder.RenameColumn(
                name: "user",
                table: "twitter",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "twitter",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "sentiment",
                table: "twitter",
                newName: "Sentiment");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "twitter",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "geo",
                table: "twitter",
                newName: "Geo");

            migrationBuilder.RenameColumn(
                name: "entities",
                table: "twitter",
                newName: "Entities");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "twitter",
                newName: "Country");

            migrationBuilder.AlterColumn<int>(
                name: "votes",
                table: "zomato_restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "country_code",
                table: "zomato_restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "average_cost_for_two",
                table: "zomato_restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "restaurant_id",
                table: "zomato_restaurants",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_zomato_restaurants",
                table: "zomato_restaurants",
                column: "restaurant_id");
        }
    }
}
