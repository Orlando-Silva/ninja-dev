namespace Cadastro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notas", "Aluno_Id", "dbo.Alunoes");
            DropForeignKey("dbo.Notas", "Materia_Id", "dbo.Materias");
            DropIndex("dbo.Notas", new[] { "Aluno_Id" });
            DropIndex("dbo.Notas", new[] { "Materia_Id" });
            RenameColumn(table: "dbo.Notas", name: "Aluno_Id", newName: "AlunoId");
            RenameColumn(table: "dbo.Notas", name: "Materia_Id", newName: "MateriaId");
            AlterColumn("dbo.Notas", "AlunoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Notas", "MateriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notas", "MateriaId");
            CreateIndex("dbo.Notas", "AlunoId");
            AddForeignKey("dbo.Notas", "AlunoId", "dbo.Alunoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Notas", "MateriaId", "dbo.Materias", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notas", "MateriaId", "dbo.Materias");
            DropForeignKey("dbo.Notas", "AlunoId", "dbo.Alunoes");
            DropIndex("dbo.Notas", new[] { "AlunoId" });
            DropIndex("dbo.Notas", new[] { "MateriaId" });
            AlterColumn("dbo.Notas", "MateriaId", c => c.Int());
            AlterColumn("dbo.Notas", "AlunoId", c => c.Int());
            RenameColumn(table: "dbo.Notas", name: "MateriaId", newName: "Materia_Id");
            RenameColumn(table: "dbo.Notas", name: "AlunoId", newName: "Aluno_Id");
            CreateIndex("dbo.Notas", "Materia_Id");
            CreateIndex("dbo.Notas", "Aluno_Id");
            AddForeignKey("dbo.Notas", "Materia_Id", "dbo.Materias", "Id");
            AddForeignKey("dbo.Notas", "Aluno_Id", "dbo.Alunoes", "Id");
        }
    }
}
