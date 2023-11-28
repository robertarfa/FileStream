using ByteBankIO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        //colocar o arquivo na pasta do executável para poder utilizar o caminho mais simples como abaixo.

        var enderecoDoArquivo = "contas.txt";
        var numeroDeBytesLidos = -1; //bytes são iguais a zero ou maiores que zero, nunca serão -1;



        //abrir arquivo por partes
        var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);

        //recuperar os bytes que estão dentro do arquivo
        //byte[] array => armazena os bytes lidos => buffer
        //int offset => onde vai iniciar o preenchimento do array
        //int count => quantas posições quer preencher

        var buffer = new byte[1024]; //1024 é 1kb

        numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

        while (numeroDeBytesLidos != 0)
        {
            numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
            EscreverBuffer(buffer);

        }


        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        //Unicode contém os 127 caracteres do ASCII
        //UTF faz a transformação do Unicode pra forma que vemos na máquina
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer);

        Console.Write(texto);

        //foreach (var meuByte in buffer)
        //{
        //    Console.Write(meuByte);
        //    Console.Write(' ');
        //}

    }
}