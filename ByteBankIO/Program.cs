using ByteBankIO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        //colocar o arquivo na pasta do executável para poder utilizar o caminho mais simples como abaixo.

        var enderecoDoArquivo = "contas.txt";

        //using cria um try catch pra verificar se é nulo, se for nulo vai fazer o dispose
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {

            var numeroDeBytesLidos = -1; //bytes são iguais a zero ou maiores que zero, nunca serão -1;

            //recuperar os bytes que estão dentro do arquivo
            //byte[] array => armazena os bytes lidos => buffer
            //int offset => onde vai iniciar o preenchimento do array
            //int count => quantas posições quer preencher

            //abrir arquivo por partes
            var buffer = new byte[1024]; //1024 é 1kb

            numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

                Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");

                EscreverBuffer(buffer, numeroDeBytesLidos);

            }

            //Essa função vai avisar para o SO que o arquivo não está mais sendo
            //utilizado e assim podemos modificar o arquivo fora daqui
            fluxoDoArquivo.Close();

            Console.ReadLine();
        }
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        //Unicode contém os 127 caracteres do ASCII
        //UTF faz a transformação do Unicode pra forma que vemos na máquina
        var utf8 = new UTF8Encoding();


        //bytesLidos Para não repetir os dados depois que acabarem os bytes
        var texto = utf8.GetString(buffer, 0, bytesLidos);

        Console.Write(texto);

        //foreach (var meuByte in buffer)
        //{
        //    Console.Write(meuByte);
        //    Console.Write(' ');
        //}

    }
}