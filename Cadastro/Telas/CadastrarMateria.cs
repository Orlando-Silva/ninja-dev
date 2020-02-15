using Cadastro.Entidades;
using Cadastro.Repositório;
using Cadastro.Serviços;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cadastro.Telas
{
    public class CadastrarMateria
    {
        private static DateTime DataMaxima = DateTime.Now;

        private readonly MateriaService materiaService;

        public CadastrarMateria()
        {
            materiaService = new MateriaService(new RepositorioBase<Materia>(new Contexto()));

            Console.Clear();
            Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                    "\n---------------------------------------------------------\n" +
                    "Cadastro de Matéria" +
                    "\n---------------------------------------------------------");


            var materia = new Materia();

            var descricaoInvalida = true;

            while (descricaoInvalida)
            {
                Console.Write("Descrição: ");

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
                    descricaoInvalida = false;
                    materia.Descricao = descricao;
                }
                Console.Clear();
            }

            Console.Clear();
            Console.WriteLine("Espere um pouco...");

            var materiaExistente = materiaService.BuscarPorDescricao(materia.Descricao);
            Console.Clear();

            if (materiaExistente != null)
            {
                Console.Clear();
                Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                        "\n---------------------------------------------------------\n" +
                        "Cadastro de matéria" +
                        "\n---------------------------------------------------------\n" +
                        "Descricão: " + materiaExistente.Descricao + "\n" +
                        "Data de Cadastro: " + materiaExistente.DataDeCadastro.ToShortDateString() + "\n" +
                        "Situacão: " + materiaExistente.Situacao.ToString() + "\n" +
                        "\n---------------------------------------------------------\n" +
                        "01 - Voltar | 02 - Salvar | 03 - Ativar/Inativar" +
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
                                materiaService.AlterarStatus(materiaExistente);
                                Console.Clear();
                                Console.WriteLine("Status da materia alterado com sucesso.\n Aperte qualquer tecla para continuar.\n");
                                Console.ReadLine();
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
            else
            {


                var dataInvalida = true;

                while (dataInvalida)
                {
                    Console.Clear();
                    Console.Write("Data de Cadastro: ");

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

                        if (dataConvertida > DataMaxima)
                        {
                            Console.Clear();
                            Console.WriteLine("A data não pode ser maior que a data atual.\n Aperte qualquer tecla para continuar.\n");
                            Console.ReadLine();
                        }
                        else
                        {
                            materia.DataDeCadastro = dataConvertida;
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

                var situacaoInvalida = true;

                while (situacaoInvalida)
                {

                    Console.Clear();
                    Console.Write("Situação (Ativo/Inativo): ");
                    var situacao = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(situacao))
                    {
                        Console.Clear();
                        Console.WriteLine("Preencha a situação.\n Aperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                        continue;
                    }

                    if (situacao.Equals("ativo", StringComparison.InvariantCultureIgnoreCase))
                    {
                        materia.Situacao = Situacao.Ativo;
                        situacaoInvalida = false;
                    }
                    else if(situacao.Equals("inativo", StringComparison.InvariantCultureIgnoreCase))
                    {
                        materia.Situacao = Situacao.Inativo;
                        situacaoInvalida = false;
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Digite uma situação válida (Ativo/Inativo).\nAperte qualquer tecla para continuar.\n");
                        Console.ReadLine();
                    }

                }

                do
                {
                    Console.Clear();
                    Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                            "\n---------------------------------------------------------\n" +
                            "Cadastro de matéria" +
                            "\n---------------------------------------------------------\n" +
                            "Descricão: " + materia.Descricao + "\n" +
                            "Data de Cadastro: " + materia.DataDeCadastro.ToShortDateString() + "\n" +
                            "Situacão: " + materia.Situacao.ToString() + "\n" +
                            "\n---------------------------------------------------------\n" +
                            "01 - Voltar | 02 - Salvar | 03 - Excluir" +
                            "\n---------------------------------------------------------");

                    var opcao = Console.ReadLine();

                    if (int.TryParse(opcao, out var opcaoValida))
                    {
                        switch (opcaoValida)
                        {
                            case 1:
                                new MenuPrincipal();
                                break;
                            case 2:
                                materiaService.Cadastrar(materia);
                                Console.Clear();
                                Console.WriteLine("Matéria salva com sucesso!\nAperte qualquer tecla para continuar.");
                                Console.ReadLine();
                                new MenuPrincipal();
                                break;
                            case 3:
                                materiaService.Excluir(materia);
                                Console.Clear();
                                Console.WriteLine("Matéria excluida.\nAperte qualquer tecla para continuar.");
                                Console.ReadLine();
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
        }

        private static void OpcaoInvalida()
        {
            Console.Clear();
            Console.WriteLine("Digite uma opção válida.\nAperte qualquer tecla para continuar.");
            Console.ReadLine();
        }
    }
}
