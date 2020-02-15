using Cadastro.Entidades;
using Cadastro.Repositório;
using Cadastro.Serviços;
using System;
using System.Text.RegularExpressions;

namespace Cadastro.Telas
{
    public class CadastrarAluno
    {
        private static DateTime DataMinima = new DateTime(2002, 1, 1);

        private readonly AlunoService alunoService;

        public CadastrarAluno()
        {
            alunoService = new AlunoService(new RepositorioBase<Aluno>(new Contexto()));

            Console.Clear();
            Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                    "\n---------------------------------------------------------\n" +
                    "Cadastro de Aluno" +
                    "\n---------------------------------------------------------");


            var aluno = new Aluno();

            var nomeInvalido = true;

            while (nomeInvalido)
            {
                Console.Write("Nome: ");

                var nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.Clear();
                    Console.WriteLine("Preencha o nome.\n Aperte qualquer tecla para continuar.\n");
                    Console.ReadLine();
                }

                if (!Regex.IsMatch(nome, @"[\p{L}]+$"))
                {
                    Console.Clear();
                    Console.WriteLine("O nome deve conter apenas letras.\n Aperte qualquer tecla para continuar.\n");
                    Console.ReadLine();
                }
                else
                {
                    nomeInvalido = false;
                    aluno.Nome = nome;
                }
                Console.Clear();
            }


            var sobrenomeInvalido = true;

            while (sobrenomeInvalido)
            {
                Console.Clear();
                Console.Write("Sobrenome: ");

                var sobrenome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(sobrenome))
                {
                    Console.Clear();
                    Console.WriteLine("Preencha o sobrenome.\n Aperte qualquer tecla para continuar.\n");
                    Console.ReadLine();
                }
                else
                {
                    sobrenomeInvalido = false;
                    aluno.Sobrenome = sobrenome;
                }

            }

            Console.Clear();
            Console.WriteLine("Espere um pouco...");

            var alunoExistente = alunoService.BuscarPorNomeSobrenome(aluno.Nome, aluno.Sobrenome);
            Console.Clear();

            if (alunoExistente != null)
            {
                Console.Clear();
                Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                        "\n---------------------------------------------------------\n" +
                        "Cadastro de Aluno" +
                        "\n---------------------------------------------------------\n" +
                        "Nome: " + alunoExistente.Nome + "\n" +
                        "Sobrenome: " + alunoExistente.Sobrenome + "\n" +
                        "Data de Nascimento: " + alunoExistente.DataDeNascimento.ToShortDateString() + "\n" +
                        "CPF: " + alunoExistente.Cpf + "\n" +
                        "Curso: " + alunoExistente.Curso + "\n" +
                        "\n---------------------------------------------------------\n" +
                        "01 - Voltar | 02 - Salvar | 03 - Excluir" +
                        "\n---------------------------------------------------------");

                do
                {
                    var opcao = Console.ReadLine();

                    if (int.TryParse(opcao, out var opcaoValida))
                    {
                        switch (opcaoValida)
                        {
                            case 1:
                                new MenuPrincipal();
                                break;
                            case 2:
                                new MenuPrincipal();
                                break;
                            case 3:
                                alunoService.Excluir(alunoExistente);
                                Console.Clear();
                                Console.WriteLine("Aluno excluido com sucesso.\n Aperte qualquer tecla para continuar.\n");
                                Console.ReadLine();
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
            else
            {


                var dataInvalida = true;

                while (dataInvalida)
                {
                    Console.Clear();
                    Console.Write("Data de Nascimento: ");

                    var data = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(data))
                    {
                        Console.Clear();
                        Console.WriteLine("Preencha a data.\n Aperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                        continue;
                    }

                    if (DateTime.TryParse(data, out var dataConvertida))
                    {
                        if (dataConvertida < DateTime.MinValue || dataConvertida > DateTime.MaxValue)
                        {
                            Console.Clear();
                            Console.WriteLine("A data esta fora do alcance permitido. Digite uma data válida.\n Aperte qualquer tecla para continuar.\n");
                            Console.ReadLine();
                        }

                        if (dataConvertida > DataMinima)
                        {
                            Console.Clear();
                            Console.WriteLine("A data não pode ser maior que 01/01/2002.\n Aperte qualquer tecla para continuar.\n");
                            Console.ReadLine();
                        }
                        else
                        {
                            aluno.DataDeNascimento = dataConvertida;
                            dataInvalida = false;
                        }


                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Formado de data inválido. Digite no formato dia/mês/ano.\nAperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                    }

                }

                var cpfInvalido = true;

                while (cpfInvalido)
                {

                    Console.Clear();
                    Console.Write("CPF: ");
                    var cpf = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(cpf))
                    {
                        Console.Clear();
                        Console.WriteLine("Preencha o CPF.\n Aperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                        continue;
                    }

                    if (alunoService.BuscarPorCpf(cpf) != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Um aluno já foi cadastrado com esse CPF.\n Aperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                        continue;
                    }

                    if (int.TryParse(cpf, out var cpfConvertido))
                    {

                        aluno.Cpf = cpf;
                        cpfInvalido = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("O CPF deve conter apenas números.\nAperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                    }

                }

                var cursoInvalido = true;

                while (cursoInvalido)
                {

                    Console.Clear();
                    Console.Write("Curso: ");
                    var curso = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(curso))
                    {
                        Console.Clear();
                        Console.WriteLine("Preencha o curso.\n Aperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                    }
                    else
                    {
                        aluno.Curso = curso;
                        cursoInvalido = false;

                    }
                }

                var opcao = "";

                do
                {
                    Console.Clear();
                    Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                            "\n---------------------------------------------------------\n" +
                            "Cadastro de Aluno" +
                            "\n---------------------------------------------------------\n" +
                            "Nome: " + aluno.Nome + "\n" +
                            "Sobrenome: " + aluno.Sobrenome + "\n" +
                            "Data de Nascimento: " + aluno.DataDeNascimento.ToShortDateString() + "\n" +
                            "CPF: " + aluno.Cpf + "\n" +
                            "Curso: " + aluno.Curso + "\n" +
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
                                break;
                            case 2:
                                alunoService.Cadastrar(aluno);
                                Console.Clear();
                                Console.WriteLine("Aluno salvo com sucesso!\nAperte qualquer tecla para continuar.");
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
        }

        private static void OpcaoInvalida()
        {
            Console.Clear();
            Console.WriteLine("Digite uma opção válida.\nAperte qualquer tecla para continuar.");
            Console.ReadLine();
        }
    }
}
