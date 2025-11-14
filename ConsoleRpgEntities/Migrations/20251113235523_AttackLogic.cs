using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpgEntities.Migrations
{
    public partial class AttackLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Monsters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: true),
                    Damage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    ArmorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipable_Item_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Item",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipable_Item_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemPlayer",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPlayer", x => new { x.CharactersId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ItemPlayer_Item_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPlayer_Players_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_EquipmentId",
                table: "Players",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_EquipmentId",
                table: "Monsters",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipable_ArmorId",
                table: "Equipable",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipable_WeaponId",
                table: "Equipable",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlayer_ItemsId",
                table: "ItemPlayer",
                column: "ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Equipable_EquipmentId",
                table: "Monsters",
                column: "EquipmentId",
                principalTable: "Equipable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Equipable_EquipmentId",
                table: "Players",
                column: "EquipmentId",
                principalTable: "Equipable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Equipable_EquipmentId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Equipable_EquipmentId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Equipable");

            migrationBuilder.DropTable(
                name: "ItemPlayer");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Players_EquipmentId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_EquipmentId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Monsters");
        }
    }
}
