using Cadastro.Entidades;
using Cadastro.Repositório;
using Cadastro.Serviços;
using System;
using System.Text.RegularExpressions;

namespace Cadastro.Telas
{
    class CadastrarNota
    {

        private readonly NotaService notaService;
        private readonly AlunoService alunoService;
        private readonly MateriaService materiaService;

        public CadastrarNota()
        {
            notaService = new NotaService(new RepositorioBase<Nota>(new Contexto()));
            alunoService = new AlunoService(new RepositorioBase<Aluno>(new Contexto()));
            materiaService = new MateriaService(new RepositorioBase<Materia>(new Contexto()));


            Console.Clear();
            Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                    "\n---------------------------------------------------------\n" +
                    "Cadastro de nota" +
                    "\n---------------------------------------------------------");


            var nota = new Nota();

            var alunoInvalido = true;
            var aluno = new Aluno();

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
                        nota.AlunoId = aluno.Id;
                    }
                }
                Console.Clear();
            }

            Console.Clear();
            Console.WriteLine("Espere um pouco...");

            var materiaInvalida = true;
            var materia = new Materia();
            while (materiaInvalida)
            {
                Console.Clear();

                Console.Write("Matéria (Digite a descrição): ");

                var descricao = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(descricao))
                {
                    Console.Clear();
                    Console.WriteLine("Preencha a descrição.\n Aperte qualquer tecla para continuar.\n");
                    Console.ReadLine();
                }

                if (!Regex.IsMatch(descricao, @"[\p{L} ]+$"))
                {
                    Console.Clear();
                    Console.WriteLine("A descrição deve conter apenas letras e espaços.\n Aperte qualquer tecla para continuar.\n");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Espere um pouco...");

                    materia = materiaService.BuscarPorDescricao(descricao);

                    if (materia == null)
                    {
                        Console.Clear();
                        Console.WriteLine("A materia inserida não existe.\n Aperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                    }
                    else
                    {
                        materiaInvalida = false;
                        nota.MateriaId = materia.Id;
                    }

                }
                Console.Clear();
            }

            Console.Clear();

            var notaInvalida = true;

            while (notaInvalida)
            {

                Console.Clear();
                Console.Write("Nota (De 0 a 100): ");
                var valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.Clear();
                    Console.WriteLine("Preencha a nota.\n Aperte qualquer tecla para continuar.\n");
                    Console.ReadLine();
                    continue;
                }

                if (decimal.TryParse(valor, out var notaConvertida))
                {
                    if(notaConvertida >= 0 || notaConvertida <= 100)
                    {
                        notaInvalida = false;
                        nota.Valor = notaConvertida;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Digite uma nota válida (número de 0 a 100).\nAperte qualquer tecla para continuar.\n");
                    Console.ReadLine();
                }
            }

            var opcao = "";

            do
            {
                Console.Clear();
                Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                        "\n---------------------------------------------------------\n" +
                        "Cadastro de nota" +
                        "\n---------------------------------------------------------\n" +
                        "Aluno: " + aluno.Nome + " " + aluno.Sobrenome + "\n" +
                        "Matéria: " + materia.Descricao + "\n" +
                        "Nota: " + nota.Valor.ToString("F2") + "\n" +
                        "\n---------------------------------------------------------\n" +
                        "01 - Voltar | 02 - Salvar | 03 - Excluir" +
                        "\n---------------------------------------------------------");

                opcao = Console.ReadLine();

                if (int.TryParse(opcao, out var opcaoValida))
                {
                    switch (opcaoValida)
                    {
                        case 1:
                            new MenuPrincipal();
                            opcao = "";
                            break;
                        case 2:
                            notaService.Cadastrar(nota);
                            Console.Clear();
                            Console.WriteLine("Nota salva com sucesso!\nAperte qualquer tecla para continuar.");
                            Console.ReadLine();
                            opcao = "";
                            new MenuPrincipal();
                            break;
                        case 3:
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
            while (string.IsNullOrWhiteSpace(opcao));

        }

        private static void OpcaoInvalida()
        {
            Console.Clear();
            Console.WriteLine("Digite uma opção válida.\nAperte qualquer tecla para continuar.");
            Console.ReadLine();
        }
    }
}
