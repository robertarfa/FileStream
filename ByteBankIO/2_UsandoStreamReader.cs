using ByteBankIO;
using System.Text;

partial class Program
{
    static void UsandoStreamReader(string[] args)
    {

        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {

            //Fazer leitura sem buffer
            var leitor = new StreamReader(fluxoDeArquivo);

            // var linha = leitor.ReadLine();

            //Console.WriteLine(linha);


            // Pode ter problema se o arquivo for muito grande
            //var texto = leitor.ReadToEnd();

            //Console.WriteLine(texto);


            //primeiro caracter em bytes
            //var numero = leitor.Read();

            //Console.WriteLine(numero);

            //Vai carregar  linha a linha, parte por parte, diferente do ReadToEnd
            //Faz toda a questão do buffer por baixo
            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();

                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var msg = $"{contaCorrente.Titular.Nome}: Conta número: {contaCorrente.Numero}, Ag: {contaCorrente.Agencia}, Saldo: {contaCorrente.Saldo}";

                Console.WriteLine(msg);
            }
        }

        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {

        var campos = linha.Split(',');

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numeroComInt = int.Parse(numero);
        var saldoComDouble = double.Parse(saldo);

        var titular = new Cliente
        {
            Nome = nomeTitular
        };

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt);

        resultado.Depositar(saldoComDouble);

        resultado.Titular = titular;

        return resultado;
    }

}


