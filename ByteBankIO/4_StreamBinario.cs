using ByteBankIO;
using System.Text;

partial class Program
{
    static void EscritaBinaria()
    {

        var caminhoNovoArquivo = "contaCorrente.txt";


        using (var fs = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new BinaryWriter(fs))
        {
            //Utilizar a forma binária para ocupar menos espaço

            //não tem writeLine, pq não tem a ideia de linha
            escritor.Write(4563);
            escritor.Write(523698);
            escritor.Write(1456.20);
            escritor.Write("Robs");

            //Conteúdo vai ficar em um formato estranho pq está binário e não mais UTF8
            //Vamos precisar de um leitor binário
        }

        Console.WriteLine("Aplicação Finalizada");

        Console.ReadLine();

        //var caminhoNovoArquivo = "testaEscrita.txt";


        ////FileMode.CreateNew => Somente vai Criar um arquivo se o arquivo não existir
        //using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        //using (var escritor = new StreamWriter(fluxoDeArquivo))
        //{
        //    escritor.WriteLine(true); //1byte
        //    escritor.WriteLine(false);//1byte
        //    escritor.WriteLine(14569875236);//4bytes na memória do pc

        //    //Utilizar a forma binária para ocupar menos espaço
        //}

        //Console.WriteLine("Aplicação Finalizada");
    }

    static void LeituraBinaria()
    {
        var caminhoNovoArquivo = "contaCorrente.txt";


        using (var fs = new FileStream(caminhoNovoArquivo, FileMode.Open))
        using (var leitor = new BinaryReader(fs))
        {
            var agencia = leitor.ReadUInt32();
            var numeroConta = leitor.ReadUInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}");
        }

    }
}


