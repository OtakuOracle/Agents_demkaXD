using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Agents.Migrations
{
    /// <inheritdoc />
    public partial class InitialCrete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "agenty");

            migrationBuilder.CreateTable(
                name: "agenttype",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    image = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("agenttype_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "materialtype",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    defectedpercent = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("materialtype_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producttype",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    defectedpercent = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("producttype_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    inn = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    startdate = table.Column<DateOnly>(type: "date", nullable: false),
                    qualityrating = table.Column<int>(type: "integer", nullable: true),
                    suppliertype = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("supplier_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    agenttypeid = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    inn = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    kpp = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    directorname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    logo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("agent_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_agent_agenttype",
                        column: x => x.agenttypeid,
                        principalSchema: "agenty",
                        principalTable: "agenttype",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "material",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    countinpack = table.Column<int>(type: "integer", nullable: false),
                    unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    countinstock = table.Column<double>(type: "double precision", nullable: true),
                    mincount = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    cost = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    image = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    materialtypeid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("material_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_material_materialtype",
                        column: x => x.materialtypeid,
                        principalSchema: "agenty",
                        principalTable: "materialtype",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    producttypeid = table.Column<int>(type: "integer", nullable: true),
                    articlenumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    productionpersoncount = table.Column<int>(type: "integer", nullable: true),
                    mincostforagent = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    productionworksshopnumber = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_producttype",
                        column: x => x.producttypeid,
                        principalSchema: "agenty",
                        principalTable: "producttype",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "agentpriorityhistory",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agentid = table.Column<int>(type: "integer", nullable: false),
                    changedate = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false),
                    priorityvalue = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("agentpriorityhistory_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_agentpriorityhistory_agent",
                        column: x => x.agentid,
                        principalSchema: "agenty",
                        principalTable: "agent",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "shop",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    agentid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("shop_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_shop_agent",
                        column: x => x.agentid,
                        principalSchema: "agenty",
                        principalTable: "agent",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "materialcounthistory",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    materialid = table.Column<int>(type: "integer", nullable: false),
                    changedate = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false),
                    countvalue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("materialcounthistory_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_materialcounthistory_material",
                        column: x => x.materialid,
                        principalSchema: "agenty",
                        principalTable: "material",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "materialsupplier",
                schema: "agenty",
                columns: table => new
                {
                    materialid = table.Column<int>(type: "integer", nullable: false),
                    supplierid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("materialsupplier_pkey", x => new { x.materialid, x.supplierid });
                    table.ForeignKey(
                        name: "fk_materialsupplier_material",
                        column: x => x.materialid,
                        principalSchema: "agenty",
                        principalTable: "material",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_materialsupplier_supplier",
                        column: x => x.supplierid,
                        principalSchema: "agenty",
                        principalTable: "supplier",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "productcosthistory",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    changedate = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false),
                    costvalue = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productcosthistory_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_productcosthistory_product",
                        column: x => x.productid,
                        principalSchema: "agenty",
                        principalTable: "product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "productmaterial",
                schema: "agenty",
                columns: table => new
                {
                    productid = table.Column<int>(type: "integer", nullable: false),
                    materialid = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productmaterial_pkey", x => new { x.productid, x.materialid });
                    table.ForeignKey(
                        name: "fk_productmaterial_material",
                        column: x => x.materialid,
                        principalSchema: "agenty",
                        principalTable: "material",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_productmaterial_product",
                        column: x => x.productid,
                        principalSchema: "agenty",
                        principalTable: "product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "productsale",
                schema: "agenty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    agentid = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    saledate = table.Column<DateOnly>(type: "date", nullable: false),
                    productcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productsale_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_productsale_agent",
                        column: x => x.agentid,
                        principalSchema: "agenty",
                        principalTable: "agent",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_productsale_product",
                        column: x => x.productid,
                        principalSchema: "agenty",
                        principalTable: "product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_agent_agenttypeid",
                schema: "agenty",
                table: "agent",
                column: "agenttypeid");

            migrationBuilder.CreateIndex(
                name: "IX_agentpriorityhistory_agentid",
                schema: "agenty",
                table: "agentpriorityhistory",
                column: "agentid");

            migrationBuilder.CreateIndex(
                name: "IX_material_materialtypeid",
                schema: "agenty",
                table: "material",
                column: "materialtypeid");

            migrationBuilder.CreateIndex(
                name: "IX_materialcounthistory_materialid",
                schema: "agenty",
                table: "materialcounthistory",
                column: "materialid");

            migrationBuilder.CreateIndex(
                name: "IX_materialsupplier_supplierid",
                schema: "agenty",
                table: "materialsupplier",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "IX_product_producttypeid",
                schema: "agenty",
                table: "product",
                column: "producttypeid");

            migrationBuilder.CreateIndex(
                name: "IX_productcosthistory_productid",
                schema: "agenty",
                table: "productcosthistory",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_productmaterial_materialid",
                schema: "agenty",
                table: "productmaterial",
                column: "materialid");

            migrationBuilder.CreateIndex(
                name: "IX_productsale_agentid",
                schema: "agenty",
                table: "productsale",
                column: "agentid");

            migrationBuilder.CreateIndex(
                name: "IX_productsale_productid",
                schema: "agenty",
                table: "productsale",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_shop_agentid",
                schema: "agenty",
                table: "shop",
                column: "agentid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agentpriorityhistory",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "materialcounthistory",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "materialsupplier",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "productcosthistory",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "productmaterial",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "productsale",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "shop",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "supplier",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "material",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "product",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "agent",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "materialtype",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "producttype",
                schema: "agenty");

            migrationBuilder.DropTable(
                name: "agenttype",
                schema: "agenty");
        }
    }
}
