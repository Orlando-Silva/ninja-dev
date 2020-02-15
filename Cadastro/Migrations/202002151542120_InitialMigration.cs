namespace Cadastro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        DataDeNascimento = c.DateTime(nullable: false),
                        Cpf = c.String(),
                        Curso = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        DataDeCadastro = c.DateTime(nullable: false),
                        Situacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Aluno_Id = c.Int(),
                        Materia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alunoes", t => t.Aluno_Id)
                .ForeignKey("dbo.Materias", t => t.Materia_Id)
                .Index(t => t.Aluno_Id)
                .Index(t => t.Materia_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notas", "Materia_Id", "dbo.Materias");
            DropForeignKey("dbo.Notas", "Aluno_Id", "dbo.Alunoes");
            DropIndex("dbo.Notas", new[] { "Materia_Id" });
            DropIndex("dbo.Notas", new[] { "Aluno_Id" });
            DropTable("dbo.Notas");
            DropTable("dbo.Materias");
            DropTable("dbo.Alunoes");
        }
    }
}
