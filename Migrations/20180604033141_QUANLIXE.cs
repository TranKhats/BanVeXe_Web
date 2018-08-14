using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Migrations
{
    public partial class QUANLIXE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    ID_CUS = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    ADDRESS = table.Column<string>(maxLength: 100, nullable: true),
                    DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    NAME = table.Column<string>(maxLength: 30, nullable: true),
                    PHONE = table.Column<string>(unicode: false, maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.ID_CUS)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "DRIVER",
                columns: table => new
                {
                    ID_DRIVER = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    FULLNAME = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER", x => x.ID_DRIVER)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PLACE",
                columns: table => new
                {
                    ID_PLACE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PLACENAME = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLACE", x => x.ID_PLACE)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE",
                columns: table => new
                {
                    ID_SERVICE = table.Column<string>(type: "char(5)", nullable: false),
                    EXPLANATION = table.Column<string>(maxLength: 300, nullable: true),
                    PRICE = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    SERVICENAME = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE", x => x.ID_SERVICE)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "TYPE_BUS",
                columns: table => new
                {
                    ID_TYPE = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    TYPENAME = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TYPE_BUS", x => x.ID_TYPE)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "TICKET",
                columns: table => new
                {
                    ID_TICKET = table.Column<string>(maxLength: 10, nullable: false),
                    ID_CUS = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TICKET", x => x.ID_TICKET)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_TICKET_TICKET_CU_CUSTOMER",
                        column: x => x.ID_CUS,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID_CUS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROUTE",
                columns: table => new
                {
                    ID_ROUTE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_DEPACTURE = table.Column<int>(nullable: true),
                    ID_DESTINATION = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROUTE", x => x.ID_ROUTE)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ROUTE_ROUTE_PLA_PLACE",
                        column: x => x.ID_DEPACTURE,
                        principalTable: "PLACE",
                        principalColumn: "ID_PLACE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ROUTE_PK_ROUTE__PLACE",
                        column: x => x.ID_DESTINATION,
                        principalTable: "PLACE",
                        principalColumn: "ID_PLACE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BUS",
                columns: table => new
                {
                    ID_BUS = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    ID_TYPE = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUS", x => x.ID_BUS)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_BUS_BUS_TYPEO_TYPE_BUS",
                        column: x => x.ID_TYPE,
                        principalTable: "TYPE_BUS",
                        principalColumn: "ID_TYPE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BUY_SERVICE",
                columns: table => new
                {
                    ID_TICKET = table.Column<string>(maxLength: 10, nullable: false),
                    ID_SERVICE = table.Column<string>(type: "char(5)", nullable: false),
                    AMOUNT = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUY_SERVICE", x => new { x.ID_TICKET, x.ID_SERVICE });
                    table.ForeignKey(
                        name: "FK_BUY_SERV_BUY_SERVI_SERVICE",
                        column: x => x.ID_SERVICE,
                        principalTable: "SERVICE",
                        principalColumn: "ID_SERVICE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BUY_SERV_BUY_SERVI_TICKET",
                        column: x => x.ID_TICKET,
                        principalTable: "TICKET",
                        principalColumn: "ID_TICKET",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SHEDULE",
                columns: table => new
                {
                    ID_SHDULE = table.Column<string>(maxLength: 11, nullable: false),
                    END = table.Column<DateTime>(type: "datetime", nullable: true),
                    ID_BUS = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    ID_DRIVER = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    ID_ROUTE = table.Column<int>(nullable: true),
                    ID_TICKET = table.Column<string>(maxLength: 10, nullable: true),
                    START = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHEDULE", x => x.ID_SHDULE)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_SHEDULE_SHEDULE_B_BUS",
                        column: x => x.ID_BUS,
                        principalTable: "BUS",
                        principalColumn: "ID_BUS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SHEDULE_SHEDULE_D_DRIVER",
                        column: x => x.ID_DRIVER,
                        principalTable: "DRIVER",
                        principalColumn: "ID_DRIVER",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SHEDULE_SHEDULE_R_ROUTE",
                        column: x => x.ID_ROUTE,
                        principalTable: "ROUTE",
                        principalColumn: "ID_ROUTE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SHEDULE_SHEDULE_T_TICKET",
                        column: x => x.ID_TICKET,
                        principalTable: "TICKET",
                        principalColumn: "ID_TICKET",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VARIABLE_SEAT",
                columns: table => new
                {
                    ID_SEAT = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    ID_BUS = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VARIABLE_SEAT", x => x.ID_SEAT)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_VARIABLE_SEAT_BUS_BUS",
                        column: x => x.ID_BUS,
                        principalTable: "BUS",
                        principalColumn: "ID_BUS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "BUS_TYPEOFBUS_FK",
                table: "BUS",
                column: "ID_TYPE");

            migrationBuilder.CreateIndex(
                name: "BUY_SERVICE2_FK",
                table: "BUY_SERVICE",
                column: "ID_SERVICE");

            migrationBuilder.CreateIndex(
                name: "BUY_SERVICE_FK",
                table: "BUY_SERVICE",
                column: "ID_TICKET");

            migrationBuilder.CreateIndex(
                name: "ROUTE_PLACE_FK",
                table: "ROUTE",
                column: "ID_DEPACTURE");

            migrationBuilder.CreateIndex(
                name: "PK_ROUTE_PLACE_FK",
                table: "ROUTE",
                column: "ID_DESTINATION");

            migrationBuilder.CreateIndex(
                name: "SHEDULE_BUS_FK",
                table: "SHEDULE",
                column: "ID_BUS");

            migrationBuilder.CreateIndex(
                name: "SHEDULE_DRIVER_FK",
                table: "SHEDULE",
                column: "ID_DRIVER");

            migrationBuilder.CreateIndex(
                name: "SHEDULE_ROUTE_FK",
                table: "SHEDULE",
                column: "ID_ROUTE");

            migrationBuilder.CreateIndex(
                name: "SHEDULE_TICKET_FK",
                table: "SHEDULE",
                column: "ID_TICKET");

            migrationBuilder.CreateIndex(
                name: "TICKET_CUSTOMER_FK",
                table: "TICKET",
                column: "ID_CUS");

            migrationBuilder.CreateIndex(
                name: "SEAT_BUS_FK",
                table: "VARIABLE_SEAT",
                column: "ID_BUS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BUY_SERVICE");

            migrationBuilder.DropTable(
                name: "SHEDULE");

            migrationBuilder.DropTable(
                name: "VARIABLE_SEAT");

            migrationBuilder.DropTable(
                name: "SERVICE");

            migrationBuilder.DropTable(
                name: "DRIVER");

            migrationBuilder.DropTable(
                name: "ROUTE");

            migrationBuilder.DropTable(
                name: "TICKET");

            migrationBuilder.DropTable(
                name: "BUS");

            migrationBuilder.DropTable(
                name: "PLACE");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "TYPE_BUS");
        }
    }
}
