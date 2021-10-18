using System;
namespace DIO.Bank
{
    public class Conta
    {
       private TipoConta tipoConta { get; set; }
       private double Saldo { get; set; }
       private double Credito { get; set; }
       private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.tipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            // Validação saldo insuficiente
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            
            this.Saldo = this.Saldo - valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo = this.Saldo + valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }
       // public void NumeroPix(double ContaPix)
        
           // {
              //  this.Saldo = this.Saldo + ContaPix;

               // Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
           // }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
                {
                    contaDestino.Depositar(valorTransferencia);
                    Console.WriteLine("Transferencia efetuada com sucesso!");
                }
        }
        public void Pix(double contaPix, Conta pixDestino)
        {
            if (this.Sacar(contaPix))
                {
                    pixDestino.Depositar(contaPix);
                    Console.WriteLine("Pix efetuado com sucesso!");
                }
        }
        public override string ToString()
            {
                string retorno = "";
                retorno += "TipoConta " + this.tipoConta + " | ";
                retorno += "Nome " + this.Nome + " | ";
                retorno += "Saldo " + this.Saldo + " | ";
                retorno += "Crédito " + this.Credito;
            return retorno;
            } 
    }
}