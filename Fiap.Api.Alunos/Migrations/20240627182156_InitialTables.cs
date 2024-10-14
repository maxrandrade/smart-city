using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Alunos.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaVerde",
                columns: table => new
                {
                    AreaVerdeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tamanho = table.Column<decimal>(type: "NUMBER(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaVerde", x => x.AreaVerdeId);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.SensorId);
                });

            migrationBuilder.CreateTable(
                name: "IrrigacaoInteligente",
                columns: table => new
                {
                    IrrigacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Horario = table.Column<DateTime>(type: "date", nullable: false),
                    AreaVerdeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigacaoInteligente", x => x.IrrigacaoId);
                    table.ForeignKey(
                        name: "FK_IrrigacaoInteligente_AreaVerde_AreaVerdeId",
                        column: x => x.AreaVerdeId,
                        principalTable: "AreaVerde",
                        principalColumn: "AreaVerdeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeituraSensor",
                columns: table => new
                {
                    LeituraSensorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Valor = table.Column<decimal>(type: "NUMBER(9,2)", nullable: false),
                    Horario = table.Column<DateTime>(type: "date", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeituraSensor", x => x.LeituraSensorId);
                    table.ForeignKey(
                        name: "FK_LeituraSensor_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensor",
                        principalColumn: "SensorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IrrigacaoInteligente_AreaVerdeId",
                table: "IrrigacaoInteligente",
                column: "AreaVerdeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeituraSensor_SensorId",
                table: "LeituraSensor",
                column: "SensorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IrrigacaoInteligente");

            migrationBuilder.DropTable(
                name: "LeituraSensor");

            migrationBuilder.DropTable(
                name: "AreaVerde");

            migrationBuilder.DropTable(
                name: "Sensor");
        }
    }
}
