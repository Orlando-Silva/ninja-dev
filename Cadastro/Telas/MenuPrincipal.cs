using System;

namespace Cadastro.Telas
{
    public class MenuPrincipal
    {

        public MenuPrincipal()
        {
            var sair = false;

            do
            {

                Console.Clear();
                Console.WriteLine("Universidade Ecológica do Sitio do Caqui" +
                    "\n---------------------------------------------------------\n" +
                    "Digite a opção:\n\n" +
                    "1 - Cadastro de aluno.\n" +
                    "2 - Cadastro de matéria.\n" +
                    "3 - Cadastro de nota.\n" +
                    "4 - Visualização de notas por aluno.\n" +
                    "5 - Sair.\n");

                var opcao = Console.ReadLine();

                if (int.TryParse(opcao, out var opcaoValida))
                {
                    switch (opcaoValida)
                    {
                        case 1:
                            new CadastrarAluno();
                            break;
                        case 2:
                            new CadastrarMateria();
                            break;
                        case 3:
                            new CadastrarNota();
                            break;
                        case 4:
                            new VisualizarNota();
                            break;
                        case 5:
                            sair = true;
                            break;
                        default:
                            OpcaoInvalida();
                            break;
                    }

                    if(sair)
                    {
                        Console.Clear();
                        Console.WriteLine("Programa finalizando...\nAperte qualquer tecla para continuar.");
                        Console.ReadLine();
                        break;
                    }
                }
                else
                {
                    OpcaoInvalida();
                }
            }
            while (!sair);

        }

        private static void OpcaoInvalida()
        {
            Console.Clear();
            Console.WriteLine("Digite uma opção válida.\nAperte qualquer tecla para continuar.");
            Console.ReadLine();
        }
    }
}
