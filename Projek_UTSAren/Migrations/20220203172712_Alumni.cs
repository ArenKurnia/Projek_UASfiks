using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projek_UTSAren.Migrations
{
    public partial class Alumni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Tahun",
                columns: table => new
                {
                    Id_angkatan = table.Column<string>(type: "varchar(767)", nullable: false),
                    Tahun_angkatan = table.Column<string>(type: "text", nullable: false),
                    Nama_angkatan = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Tahun", x => x.Id_angkatan);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Alumni",
                columns: table => new
                {
                    NIM = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama_alumni = table.Column<string>(type: "text", nullable: false),
                    Tahun_angkatan = table.Column<int>(type: "int", nullable: false),
                    Jenis_kelamin = table.Column<string>(type: "text", nullable: false),
                    Tempat_lahir = table.Column<string>(type: "text", nullable: false),
                    Tanggal_lahir = table.Column<DateTime>(type: "datetime", nullable: false),
                    Pekerjaan = table.Column<string>(type: "text", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    Telp = table.Column<string>(type: "text", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false),
                    RolesId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Alumni", x => x.NIM);
                    table.ForeignKey(
                        name: "FK_Tb_Alumni_Tb_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Tb_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_User",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(767)", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Nama_Lengkap = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    RolesId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_User", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Tb_User_Tb_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Tb_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Event",
                columns: table => new
                {
                    Id_event = table.Column<string>(type: "varchar(767)", nullable: false),
                    Id_angkatan = table.Column<string>(type: "varchar(767)", nullable: true),
                    Nama_event = table.Column<string>(type: "text", nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tempat = table.Column<string>(type: "text", nullable: false),
                    Waktu = table.Column<string>(type: "text", nullable: false),
                    Batas_daftar = table.Column<DateTime>(type: "datetime", nullable: false),
                    Keterangan = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Event", x => x.Id_event);
                    table.ForeignKey(
                        name: "FK_Tb_Event_Tb_Tahun_Id_angkatan",
                        column: x => x.Id_angkatan,
                        principalTable: "Tb_Tahun",
                        principalColumn: "Id_angkatan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Alumni_RolesId",
                table: "Tb_Alumni",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Event_Id_angkatan",
                table: "Tb_Event",
                column: "Id_angkatan");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_User_RolesId",
                table: "Tb_User",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Alumni");

            migrationBuilder.DropTable(
                name: "Tb_Event");

            migrationBuilder.DropTable(
                name: "Tb_User");

            migrationBuilder.DropTable(
                name: "Tb_Tahun");

            migrationBuilder.DropTable(
                name: "Tb_Roles");
        }
    }
}
