using ByteBankIO;
using System.Text;

partial class Program
{
    static void UsandoStreamDeEntrada()
    {

        using (var fluxoDeEntrada = Console.OpenStandardInput())
        using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
        {

            Console.WriteLine("Escreva seu nome:");
            var nome = Console.ReadLine();
            Console.WriteLine(nome);
            var buffer = new byte[1024];

            //É isso que o Console.ReadLine() faz por baixo dos panos
            while (true)
            {
                //armazena mais informações na console
                var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                fs.Write(buffer, 0, bytesLidos);
                fs.Flush();

                Console.WriteLine($"Bytes lidos na console: {bytesLidos}");
            }

        }
    }



}


