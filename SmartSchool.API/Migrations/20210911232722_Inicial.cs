using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplina_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplina_Disciplina_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplina_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoCurso",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    DisciplinaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoCurso", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunoCurso_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoCurso_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplina",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplina", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, false, null, new DateTime(2021, 9, 11, 20, 27, 21, 810, DateTimeKind.Local).AddTicks(8842), new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, false, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(535), new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, false, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(598), new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, false, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(604), new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, false, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(608), new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, false, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(616), new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, false, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(621), new DateTime(2015, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 1, true, null, new DateTime(2021, 9, 11, 20, 27, 21, 806, DateTimeKind.Local).AddTicks(5830), "Lauro", 1, "Oliveira", null });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 2, true, null, new DateTime(2021, 9, 11, 20, 27, 21, 807, DateTimeKind.Local).AddTicks(6757), "Roberto", 2, "Soares", null });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 3, true, null, new DateTime(2021, 9, 11, 20, 27, 21, 807, DateTimeKind.Local).AddTicks(6811), "Ronaldo", 3, "Marconi", null });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 4, true, null, new DateTime(2021, 9, 11, 20, 27, 21, 807, DateTimeKind.Local).AddTicks(6815), "Rodrigo", 4, "Carvalho", null });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 5, true, null, new DateTime(2021, 9, 11, 20, 27, 21, 807, DateTimeKind.Local).AddTicks(6817), "Alexandre", 5, "Montanha", null });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 3, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 1, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2476), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 5, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2491), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 5, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2482), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 5, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2474), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 4, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2506), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 4, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2501), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 5, 4, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2492), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 4, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2490), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 4, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2440), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 3, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2505), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 5, 5, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2494), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 3, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2498), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 2, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2504), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 2, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2497), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 2, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2484), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 2, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2477), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 2, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(1925), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 1, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2502), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 1, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2495), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 1, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2488), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 1, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2483), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 3, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2486), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 5, null, new DateTime(2021, 9, 11, 20, 27, 21, 811, DateTimeKind.Local).AddTicks(2508), null });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCurso_DisciplinaId",
                table: "AlunoCurso",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplina_DisciplinaId",
                table: "AlunoDisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_CursoId",
                table: "Disciplina",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_PrerequisitoId",
                table: "Disciplina",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoCurso");

            migrationBuilder.DropTable(
                name: "AlunoDisciplina");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
