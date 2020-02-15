using Cadastro.Entidades;
using Cadastro.Repositório;
using Cadastro.Serviços;
using System;


namespace Cadastro.Telas
{
    public class VisualizarNota
    {
        private readonly NotaService notaService;
        private readonly AlunoService alunoService;

        public VisualizarNota()
        {
            notaService = new NotaService(new RepositorioBase<Nota>(new Contexto()));
            alunoService = new AlunoService(new RepositorioBase<Aluno>(new Contexto()));


            Console.Clear();
            Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                    "\n---------------------------------------------------------\n" +
                    "Visualização de notas" +
                    "\n---------------------------------------------------------");

            var alunoInvalido = true;

            Aluno aluno = new Aluno();

            while (alunoInvalido)
            {
                Console.Write("Aluno (Digite o CPF): ");

                var cpf = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(cpf))
                {
                    Console.Clear();
                    Console.WriteLine("Preencha o CPF do aluno.\n Aperte qualquer tecla para continuar.\n");
                    Console.ReadLine();
                }

                if (!int.TryParse(cpf, out _))
                {
                    Console.Clear();
                    Console.WriteLine("O CPF deve conter apenas números.\n Aperte qualquer tecla para continuar.\n");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Espere um pouco...");
                    aluno = alunoService.BuscarPorCpf(cpf);

                    if (aluno == null)
                    {
                        Console.Clear();
                        Console.WriteLine("O aluno inserido não existe.\n Aperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                    }
                    else
                    {
                        alunoInvalido = false;
                    }
                }
                Console.Clear();
            }

            Console.WriteLine("Espere um pouco...");
            var notas = notaService.BuscarPorAluno(aluno.Id);

            Console.Clear();
            Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                    "\n---------------------------------------------------------\n" +
                    "Visualização de notas\n" +
                    "---------------------------------------------------------\n" +
                    "\nAluno: " + aluno.Nome + " " + aluno.Sobrenome +
                    "\n---------------------------------------------------------\n");

            foreach (var nota in notas)
            {
                Console.WriteLine(
                    "\n------------------------------" + nota.Materia.Descricao + "---------------------------\n" +
                    "Nota: " + nota.Valor.ToString("F2") + "\n\n" +
                    "-----------------------------------------------------------------------------------------\n\n");

            }

            do
            {
                Console.WriteLine("01 - Voltar" +
                        "\n---------------------------------------------------------");

                var opcao = Console.ReadLine();

                if (int.TryParse(opcao, out var opcaoValida))
                {
                    switch (opcaoValida)
                    {
                        case 1:
                            new MenuPrincipal();
                            break;
                        default:
                            OpcaoInvalida();
                            break;
                    }
                }
                else
                {
                    OpcaoInvalida();
                }
            }
            while (true);
        }
        private static void OpcaoInvalida()
        {
            Console.Clear();
            Console.WriteLine("Digite uma opção válida.\nAperte qualquer tecla para continuar.");
            Console.ReadLine();
        }


    }
}
