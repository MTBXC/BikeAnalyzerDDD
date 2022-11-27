using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BikeAnalyzerDDD.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    YearOfProduction = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    HeadTubeAngle = table.Column<double>(type: "float", maxLength: 20, nullable: false),
                    SeatTubeEffectiveAngle = table.Column<double>(type: "float", maxLength: 20, nullable: false),
                    TravelFrontWheel = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    TravelBackWheel = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    InnerRimWidth = table.Column<double>(type: "float", maxLength: 20, nullable: false),
                    TireWidth = table.Column<double>(type: "float", maxLength: 20, nullable: false),
                    Weigth = table.Column<double>(type: "float", maxLength: 20, nullable: false),
                    GeneralBikeRate = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Brand", "GeneralBikeRate", "HeadTubeAngle", "InnerRimWidth", "Model", "SeatTubeEffectiveAngle", "TireWidth", "TravelBackWheel", "TravelFrontWheel", "Weigth", "YearOfProduction" },
                values: new object[,]
                {
                    { 1, "Scott", null, 67.299999999999997, 30.0, "Spark RC World Cup Evo", 74.0, 2.3999999999999999, 120, 120, 10.300000000000001, 2022 },
                    { 2, "Scott", null, 67.299999999999997, 30.0, "Spark RC World Cup", 74.0, 2.3999999999999999, 120, 120, 10.699999999999999, 2022 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");
        }
    }
}
