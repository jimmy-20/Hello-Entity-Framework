using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("2b91a62d-8567-49ac-b881-a3e3c503d2c0"), "Tareas que estan en espera", "Actividades Pendientes", 5 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("2b91a62d-8567-49ac-b881-a3e3c503d2c1"), "Tareas que se estan realizando en el trascurso del tiempo", "Actividades en Curso", 8 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("2b91a62d-8567-49ac-b881-a3e3c503d2c2"), "Tareas cumplidas o tareas terminadas a tiempo", "Actividades Finalizadas", 22 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "FechaFinalizacion", "Prioridad", "Titulo" },
                values: new object[] { new Guid("f3bfb392-1eae-4ae4-a27b-83ab9f2777b7"), new Guid("2b91a62d-8567-49ac-b881-a3e3c503d2c1"), "Se investiga el uso de Entity Framework por Platzi", new DateTime(2022, 7, 21, 15, 58, 1, 467, DateTimeKind.Local).AddTicks(6249), new DateTime(2022, 7, 21, 15, 58, 1, 467, DateTimeKind.Local).AddTicks(6301), 2, "Estudiando el curso de Fundamentos Entity Framework" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "FechaFinalizacion", "Prioridad", "Titulo" },
                values: new object[] { new Guid("f3bfb392-1eae-4ae4-a27b-83ab9f2777b8"), new Guid("2b91a62d-8567-49ac-b881-a3e3c503d2c2"), null, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "I Semestre 2022" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2b91a62d-8567-49ac-b881-a3e3c503d2c0"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f3bfb392-1eae-4ae4-a27b-83ab9f2777b7"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f3bfb392-1eae-4ae4-a27b-83ab9f2777b8"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2b91a62d-8567-49ac-b881-a3e3c503d2c1"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2b91a62d-8567-49ac-b881-a3e3c503d2c2"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
