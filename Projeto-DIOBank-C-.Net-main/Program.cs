using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();


        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    /* Para a implementação de um método para excluir contas posteriormente, 
                    pode-se usar o método ListarContas e pedir ao usuário o número da conta 
                    que se deseja excluir*/
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
                    case "6":
                        Remover();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Por favor, digite uma das opções acima");
                        break;
                }


                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            if (int.TryParse(Console.ReadLine(), out int indiceContaOrigem))
            {
                if((indiceContaOrigem >= 0) && (indiceContaOrigem <= listContas.Count))
                {
                    
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("O valor digitado não corresponde a nenhuma das contas cadastradas");
                    return;
                }
            }
            Console.Write("Digite o número da conta de destino: ");
            if (int.TryParse(Console.ReadLine(), out int indiceContaDestino))
            {
                if((indiceContaDestino >= 0) && (indiceContaDestino <= listContas.Count))
                {
                    
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("O valor digitado não corresponde a nenhuma das contas cadastradas");
                    return;
                }
            }
            if (indiceContaOrigem == indiceContaDestino){
                Console.WriteLine("As contas de origem e destino têm de ser diferentes");
                return;
            }
            Console.Write("Digite o valor a ser transferido: ");
            if (double.TryParse(Console.ReadLine(), out double valorTransferencia))
            {        
                if (valorTransferencia < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("O valor a ser transferido têm de ser um número real e positivo");
                    return;   
                }
            }
            else{
                Console.WriteLine();
                Console.WriteLine("O valor a ser transferido têm de ser um número real e positivo");
                return;
            }

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            if (int.TryParse(Console.ReadLine(), out int indiceConta))
            {
                if((indiceConta >= 0) && (indiceConta <= listContas.Count))
                {
                    
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("O valor digitado não corresponde a nenhuma das contas cadastradas");
                    return;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("O valor digitado não corresponde a nenhuma das contas cadastradas");
                return;
            }
            Console.Write("Digite o valor a ser sacado: ");
            if (double.TryParse(Console.ReadLine(), out double valorSaque))
            {        
                if (valorSaque < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("O valor a ser sacado têm de ser um número real e positivo");
                    return;   
                }
            }
            else{
                Console.WriteLine();
                Console.WriteLine("O valor a ser sacado têm de ser um número real e positivo");
                return;
            }

            listContas[indiceConta].Sacar(valorSaque);

        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            if (int.TryParse(Console.ReadLine(), out int indiceConta))
            {
                if((indiceConta >= 0) && (indiceConta <= listContas.Count))
                {
                    
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("O valor digitado não corresponde a nenhuma das contas cadastradas");
                    return;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("O valor digitado não corresponde a nenhuma das contas cadastradas");
                return;
            }
            Console.Write("Digite o valor a ser depositado: ");
            if (double.TryParse(Console.ReadLine(), out double valorDeposito))
            {        
                if (valorDeposito < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("O valor a ser depositado têm de ser um número real e positivo");
                    return;   
                }
            }
            else{
                Console.WriteLine();
                Console.WriteLine("O valor a ser depositado têm de ser um número real e positivo");
                return;
            }
            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Remover()
        {
             if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada para ser removida.");
                return;
            }
            ListarContas();
            Console.WriteLine("Digite o número da conta que será removida:");
            if (int.TryParse(Console.ReadLine(), out int indiceContaRemover))
            {
                if((indiceContaRemover >= 0) && (indiceContaRemover <= listContas.Count))
                {
                    if ((listContas[indiceContaRemover].Saldo > 0) || (listContas[indiceContaRemover].Saldo < 0))
                    {
                        Console.WriteLine("Não é possível remover contas contendo fundos ou saldo negativo");   
                    }
                    else
                    {
                        listContas.RemoveAt(indiceContaRemover);
                        Console.WriteLine("Conta removida com sucesso!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("O valor digitado não corresponde a nenhuma das contas cadastradas");
                    return;
                }
            }
            else
            {
                Console.WriteLine("O valor digitado não corresponde a nenhuma das contas cadastradas");
                return;
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física o 2 para Jurídica: ");
            // int entradaTipoConta = int.Parse(Console.ReadLine());
            if (int.TryParse(Console.ReadLine(), out int entradaTipoConta))
            {
                if ((entradaTipoConta != 1) && (entradaTipoConta != 2))
                {
                    Console.WriteLine("O tipo de conta têm de ser 1 ou 2");
                    return;
                }
            }
            else{
                Console.WriteLine("O tipo de conta têm de ser 1 ou 2");
                return;
            }

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            //double entradaSaldo = double.Parse(Console.ReadLine());
            if (double.TryParse(Console.ReadLine(), out double entradaSaldo))
            {        
            }
            else{
                Console.WriteLine("O saldo têm de ser um número real");
                return;
            }

            Console.Write("Digite o crédito: ");
            //double entradaCredito = double.Parse(Console.ReadLine());
            if (double.TryParse(Console.ReadLine(), out double entradaCredito))
            {        
                if (entradaCredito < 0)
                {
                    Console.WriteLine("O saldo têm de ser um número real e positivo");
                    return;   
                }
            }
            else{
                Console.WriteLine("O saldo têm de ser um número real e positivo");
                return;
            }

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            /*Assim também funciona, mas os parâmetros tem que ser passados exatamente na ordem
            do método construidor da classe. O (TipoConta) antes do entradaTipoConta serve para
            converter o entradaTipoConta para o enum TipoConta.
            Conta novaConta = new Conta((TipoConta)entradaTipoConta, 
                                        entradaSaldo,
                                        entradaCredito,
                                        entradaNome);
            */
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista das contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Remover uma conta");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper(); 
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
