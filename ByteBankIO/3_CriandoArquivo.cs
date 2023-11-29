﻿using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        //Mesma pasta onde tem o executável
        var caminhoNovoArquivo = "contasExportadas.csv";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456,7895,4785.40,Robs Aguilar";

            var enconding = Encoding.UTF8;

            var bytes = enconding.GetBytes(contaComoString);

            fluxoDeArquivo.Write(bytes, 0, bytes.Length);
        }
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadas2.csv";


        //FileMode.CreateNew => Somente vai Criar um arquivo se o arquivo não existir
        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            escritor.Write("456,7895,4785.40,Robs Ferreira");
        }

    }
}