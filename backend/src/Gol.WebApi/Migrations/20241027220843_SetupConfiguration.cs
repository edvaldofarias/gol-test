using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gol.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SetupConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Car_CarId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Truck_TruckId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_CarId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_TruckId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                table: "Vehicle",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicle",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Vehicle",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Revision",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Truck_VehicleId",
                table: "Truck",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revision_VehicleId",
                table: "Revision",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_VehicleId",
                table: "Car",
                column: "VehicleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Vehicle_VehicleId",
                table: "Car",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revision_Vehicle_VehicleId",
                table: "Revision",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Truck_Vehicle_VehicleId",
                table: "Truck",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Vehicle_VehicleId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Revision_Vehicle_VehicleId",
                table: "Revision");

            migrationBuilder.DropForeignKey(
                name: "FK_Truck_Vehicle_VehicleId",
                table: "Truck");

            migrationBuilder.DropIndex(
                name: "IX_Truck_VehicleId",
                table: "Truck");

            migrationBuilder.DropIndex(
                name: "IX_Revision_VehicleId",
                table: "Revision");

            migrationBuilder.DropIndex(
                name: "IX_Car_VehicleId",
                table: "Car");

            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Revision",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CarId",
                table: "Vehicle",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TruckId",
                table: "Vehicle",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Car_CarId",
                table: "Vehicle",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Truck_TruckId",
                table: "Vehicle",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id");
        }
    }
}
