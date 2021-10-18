using System;
using System.Collections.Generic;
namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();
        static List<Conta> listPix = new List<Conta>();

        static void Main(string[] args)
        {
                String opcaoUsuario = ObterOpcaoUsuario();         

                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarContas();
                            break;
                        case "2":
                            InserirConta();
                            break;
                        case "3":
                            Transferir();
                            break;    
                        case "4":
                            Sacar();
                            break;
                        case "5":
                            Depositar();
                            break;
                        //case "6":
                            //Pix();
                            //break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    opcaoUsuario = ObterOpcaoUsuario();
            
                }

        //String opcaoPix = ObterOpcaoPix();
            //while (opcaoPix.ToUpper() != "X")
            //{
                    //switch (opcaoPix)
                    //{
                        //case "1":
                            //ListarPix();
                            //break;
                        //case "C":
                            //Console.Clear();
                            //break;
                        //default:
                              //throw new ArgumentOutOfRangeException();
                    //}

                    //opcaoUsuario = ObterOpcaoPix();
            
            //}

                Console.WriteLine("Obrigado por utilizar nossos serviços.");
                Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de Destino: ");
            int indiceContaDestino= int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }
         //private static void Pix()
        //{
            //Console.Write("Digite o número da conta de origem: ");
            //int indiceContaOrigem = int.Parse(Console.ReadLine());

            //Console.Write("Digite o número do Pix ");
            //int indiceValorPix= int.Parse(Console.ReadLine());

            //Console.Write("Digite o valor a ser transferido: ");
            //double valorPix = double.Parse(Console.ReadLine());

            //listContas[indiceContaOrigem].Pix(valorPix, listContas[indiceValorPix]);

        //}
        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque= double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito= double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }
        

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Fisíca ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listContas.Count == 0) 
            {
                Console.WriteLine("Nenhuma conta Cadastrada.");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
              
            } 
        }

        //private static void ListarPix()
        //{
            //Console.WriteLine("Listar Pix");

            //if (listPix.Count == 0) 
            //{
                //Console.WriteLine("Pix inválido");
                //return;
            //}
            //for (int i = 0; i < listPix.Count; i++)
            //{
                //Conta pix = listPix[i];
                //Console.Write("#{0} - ", i);
                //Console.WriteLine(pix);
                
            //}   
            
        //}
        private static string ObterOpcaoUsuario()

        {
            Console.WriteLine();
            Console.WriteLine("Rocha Bank a seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            //Console.WriteLine("6 - Transferencia PIX");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;          
        }

        //private static string ObterOpcaoPix()
        //{
            //Console.WriteLine();
            //Console.WriteLine("1 - CPF");
            //Console.WriteLine("2 - Chave Aleatória");
            //Console.WriteLine("3 - E-mail");
            //Console.WriteLine("X - Sair");
            //Console.WriteLine();

            //string opcaoPix = Console.ReadLine().ToUpper();
            //Console.WriteLine();
            //return opcaoPix;          
        //}
        
    }
}
