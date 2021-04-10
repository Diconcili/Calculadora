using System;

namespace Calculadora.ConsoleApp
{
    class Program
    {
        #region Requisitos
        /* 1) A calculadora deve somar dois números [OK]
         * 2) A calculadora deve ter a possibilidade de fazer várias somas [OK] 
         * 3) A calculadora deve ter a possibilidade de fazer várias operações de soma e subtração [OK]
         * 4) A calculadora deve ter a possibilidade de executar as quatro operações básicas da matemática [OK] 
         * 5) A calculadora deve validar a opção selecionada do menu [OK] 
         * 6) A calculadora deve permitir visualizar as operações já realizadas [OK]
         * 
         * Requisito não funcional: 
         * -Todas as funcionalidades implementadas.
         * -Melhorar o entendimento do código.
         */
        #endregion

        #region Critérios de Requisitos
        // Requisito 6, Critérios: 
        /* Critério 1 - A descrição da operação deve ser mostrada para o usuário, por exemplo: 
        /*                                                                                 2 + 2 = 4
        /* Critério 2- Caso neenhuma operação tenha sido realizada, avise o usuário sobre tal fato.                                                                                
         * 
         *
         */
        #endregion

        #region BUGS
        // A calculadora deve fazer as operações com "0" [RESOLVIDO]
        #endregion

        static void Main(string[] args)
        {
            string[] operaçõesRealizadas = new string[100];

            string opção = "";

            int contadorOperaçõesRealizadas = 0;

            while (true)
            {
                MostrarMenu();

                opção = Console.ReadLine();

                if (ValidaçãoOpção(opção))
                {
                    ApresentarMensagem("Opção Inválida, tente novamente!");

                    continue;
                }

                VerificarOpçãoLetra(opção);

                if (OpçãoVisualização(opção))
                {
                    if (contadorOperaçõesRealizadas == 0)
                    {
                        ApresentarMensagem("Nenhuma operação realizada");
                    }
                    else
                        MostrarOperações(operaçõesRealizadas);

                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (OpçãoDeSaída(opção))
                {
                    break;
                }

                string strprimeiroNumero = " ";
                string strsegundoNumero = " ";
                SolicitarNumero(out strprimeiroNumero, out strsegundoNumero);
                double primeiroNumero = Convert.ToDouble(strprimeiroNumero);
                double segundoNumero = Convert.ToDouble(strsegundoNumero);
                

                if (opção == "4" && segundoNumero == 0)
                {
                    ApresentarMensagem("Operação indefinida.");
                    continue;
                }

                string símboloOperação = " ";
                double resultado = 0;

                resultado = ObtemResultado(opção, primeiroNumero, segundoNumero, resultado);

                símboloOperação = ObtemOperação(opção, símboloOperação);

                string operaçãoRealizada = $"{primeiroNumero} {símboloOperação} {segundoNumero} = {resultado}";


                operaçõesRealizadas[contadorOperaçõesRealizadas] = operaçãoRealizada;

                contadorOperaçõesRealizadas++;                

                Console.WriteLine(operaçãoRealizada);

                Console.WriteLine();

                Console.ReadLine();

                Console.Clear();
            }
        }

        private static void VerificarOpçãoLetra(string opção)
        {
            if (opção.Equals("A", StringComparison.OrdinalIgnoreCase) || opção.Equals("B", StringComparison.OrdinalIgnoreCase) || opção.Equals("C", StringComparison.OrdinalIgnoreCase) || opção.Equals("D", StringComparison.OrdinalIgnoreCase) || opção.Equals("E", StringComparison.OrdinalIgnoreCase) || opção.Equals("F", StringComparison.OrdinalIgnoreCase) || opção.Equals("G", StringComparison.OrdinalIgnoreCase) || opção.Equals("H", StringComparison.OrdinalIgnoreCase) || opção.Equals("I", StringComparison.OrdinalIgnoreCase) || opção.Equals("J", StringComparison.OrdinalIgnoreCase) || opção.Equals("K", StringComparison.OrdinalIgnoreCase) || opção.Equals("L", StringComparison.OrdinalIgnoreCase) || opção.Equals("M", StringComparison.OrdinalIgnoreCase) || opção.Equals("N", StringComparison.OrdinalIgnoreCase) || opção.Equals("O", StringComparison.OrdinalIgnoreCase) || opção.Equals("P", StringComparison.OrdinalIgnoreCase) || opção.Equals("Q", StringComparison.OrdinalIgnoreCase) || opção.Equals("R", StringComparison.OrdinalIgnoreCase)  || opção.Equals("T", StringComparison.OrdinalIgnoreCase) || opção.Equals("U", StringComparison.OrdinalIgnoreCase) || opção.Equals("V", StringComparison.OrdinalIgnoreCase) || opção.Equals("W", StringComparison.OrdinalIgnoreCase) || opção.Equals("X", StringComparison.OrdinalIgnoreCase) || opção.Equals("Y", StringComparison.OrdinalIgnoreCase) || opção.Equals("Z", StringComparison.OrdinalIgnoreCase))
            {
                ApresentarMensagem("Opção Inválida, tente novamente!");
            }
        }

        private static string ObtemOperação(string opção, string símboloOperação)
        {
            switch (opção)
            {
                case "1": símboloOperação = "+"; break;
                case "2": símboloOperação = "-"; break;
                case "3": símboloOperação = "*"; break;
                case "4": símboloOperação = "/"; break;
                default: break;
            }

            return símboloOperação;
        }

        private static double ObtemResultado(string opção, double primeiroNumero, double segundoNumero, double resultado)
        {

            switch (opção)
            {
                case "1": resultado = primeiroNumero + segundoNumero; break;
                case "2": resultado = primeiroNumero - segundoNumero; break;
                case "3": resultado = primeiroNumero * segundoNumero; break;
                case "4": resultado = primeiroNumero / segundoNumero; break;
                default: break;
            }

            return resultado;
        }

        private static void SolicitarNumero(out string strprimeiroNumero, out string strsegundoNumero)
        {
            Console.Write("Digite o primeiro número: ");
            strprimeiroNumero = Console.ReadLine();

            if (VerificaPrimeiroNumero(strprimeiroNumero.ToString()) == false)
            { ApresentarMensagem("Número inválido, tente novamente"); }  
          
            Console.Write("Digite o segundo número: ");
            strsegundoNumero = Console.ReadLine();

            if (VerificaPrimeiroNumero(strsegundoNumero.ToString()) == false)
            { ApresentarMensagem("Número inválido, tente novamente"); }

            double primeiroNumero = Convert.ToDouble(strprimeiroNumero);

            double segundoNumero = Convert.ToDouble(strsegundoNumero);                  
        }

        private static bool OpçãoDeSaída(string opção)
        {
            return opção.Equals("S", StringComparison.OrdinalIgnoreCase);
        }

        private static void MostrarOperações(string[] operaçõesRealizadas)
        {
            for (int i = 0; i < operaçõesRealizadas.Length; i++)
            {
                if (operaçõesRealizadas[i] != null)
                {
                    Console.WriteLine(operaçõesRealizadas[i]);
                }
            }
        }

        private static bool OpçãoVisualização(string opção)
        {
            return opção == "5";
        }

        private static void ApresentarMensagem(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();

            Console.ReadLine();
            Console.Clear();
        }

        private static bool ValidaçãoOpção(string opção)
        {
            return opção != "1" && opção != "2" && opção != "3" && opção != "4" && opção != "5" && opção != "s" && opção != "S";
        }

        private static void MostrarMenu()
        {
            System.Console.WriteLine("Calculadora 1.7.4");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para somar");
            Console.WriteLine("Digite 2 para subtrair");
            Console.WriteLine("Digite 3 para multiplicar");
            Console.WriteLine("Digite 4 para dividir");
            Console.WriteLine("Digite 5 para visualizar as operações");
            Console.WriteLine();
            Console.WriteLine("Digite S para sair");
        }

        public static bool VerificaPrimeiroNumero(string primeiroNumero)
        {
            double verificação;
            return double.TryParse(primeiroNumero, out verificação);
        }

        public static bool VerificaSegundoNumero(string segundoNumero)
        {
            double verificação;
            return double.TryParse(segundoNumero, out verificação);
        }
    }
}