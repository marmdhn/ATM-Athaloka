using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMBank_.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "atms",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false),
                    atm_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_atms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false),
                    username = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "casettes",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false),
                    atm_id = table.Column<int>(type: "integer", nullable: false),
                    nominal = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casettes", x => x.id);
                    table.ForeignKey(
                        name: "fk_casettes_atms_atm_id",
                        column: x => x.atm_id,
                        principalTable: "atms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    admin_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    admin_username = table.Column<string>(type: "text", nullable: true),
                    admin_password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admins", x => x.id);
                    table.ForeignKey(
                        name: "fk_admins_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    customer_name  = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    account_number  = table.Column<int>(type: "integer", nullable: false),
                    atm_card_number  = table.Column<int>(type: "integer", nullable: false),
                    atm_pin  = table.Column<int>(type: "integer", nullable: false),
                    balance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                    table.ForeignKey(
                        name: "fk_customers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_admins_user_id",
                table: "admins",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_casettes_atm_id",
                table: "casettes",
                column: "atm_id");

            migrationBuilder.CreateIndex(
                name: "ix_customers_user_id",
                table: "customers",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "casettes");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "atms");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
