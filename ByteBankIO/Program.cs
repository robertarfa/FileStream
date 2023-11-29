using ByteBankIO;
using System.Text;

partial class Program
{
    static void Main(string[] args)
    {
        var linhas = File.ReadAllLines("contas.txt");
        Console.WriteLine(linhas.Length);

        foreach (var line in linhas)
        {
            Console.WriteLine(line);
        }

        var bytesArquivo = File.ReadAllBytes("contas.txt");
        Console.WriteLine($"O arquivo contém {bytesArquivo.Length} bytes");

        File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

        Console.WriteLine("Aplicação finalizada...");

        Console.ReadLine();
    }



}


