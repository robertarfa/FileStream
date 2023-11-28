using ByteBankIO;
using System.Text;

partial class Program
{
    static void Main(string[] args)
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

                Console.WriteLine(linha);
            }
        }

        Console.ReadLine();
    }


}


