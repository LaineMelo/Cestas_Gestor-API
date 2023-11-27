using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestor_cestas_api.Migrations
{
    /// <inheritdoc />
    public partial class M02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependentes_Beneficiarios_IdBeneficiario",
                table: "Dependentes");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaNecessidades_Beneficiarios_IdBeneficiario",
                table: "ListaNecessidades");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroCesta_Beneficiarios_IdBeneficiario",
                table: "RegistroCesta");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroCesta_Voluntarios_IdVoluntario",
                table: "RegistroCesta");

            migrationBuilder.DropIndex(
                name: "IX_RegistroCesta_IdBeneficiario",
                table: "RegistroCesta");

            migrationBuilder.DropIndex(
                name: "IX_RegistroCesta_IdVoluntario",
                table: "RegistroCesta");

            migrationBuilder.DropIndex(
                name: "IX_ListaNecessidades_IdBeneficiario",
                table: "ListaNecessidades");

            migrationBuilder.DropIndex(
                name: "IX_Dependentes_IdBeneficiario",
                table: "Dependentes");

            migrationBuilder.AddColumn<int>(
                name: "VoluntarioId",
                table: "LinkDto",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LinkDto_VoluntarioId",
                table: "LinkDto",
                column: "VoluntarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkDto_Voluntarios_VoluntarioId",
                table: "LinkDto",
                column: "VoluntarioId",
                principalTable: "Voluntarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkDto_Voluntarios_VoluntarioId",
                table: "LinkDto");

            migrationBuilder.DropIndex(
                name: "IX_LinkDto_VoluntarioId",
                table: "LinkDto");

            migrationBuilder.DropColumn(
                name: "VoluntarioId",
                table: "LinkDto");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroCesta_IdBeneficiario",
                table: "RegistroCesta",
                column: "IdBeneficiario");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroCesta_IdVoluntario",
                table: "RegistroCesta",
                column: "IdVoluntario");

            migrationBuilder.CreateIndex(
                name: "IX_ListaNecessidades_IdBeneficiario",
                table: "ListaNecessidades",
                column: "IdBeneficiario");

            migrationBuilder.CreateIndex(
                name: "IX_Dependentes_IdBeneficiario",
                table: "Dependentes",
                column: "IdBeneficiario");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependentes_Beneficiarios_IdBeneficiario",
                table: "Dependentes",
                column: "IdBeneficiario",
                principalTable: "Beneficiarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaNecessidades_Beneficiarios_IdBeneficiario",
                table: "ListaNecessidades",
                column: "IdBeneficiario",
                principalTable: "Beneficiarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroCesta_Beneficiarios_IdBeneficiario",
                table: "RegistroCesta",
                column: "IdBeneficiario",
                principalTable: "Beneficiarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroCesta_Voluntarios_IdVoluntario",
                table: "RegistroCesta",
                column: "IdVoluntario",
                principalTable: "Voluntarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
