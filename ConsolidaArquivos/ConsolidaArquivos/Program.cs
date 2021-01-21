using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsolidaArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string conteudoArquivo = string.Empty;

            StringBuilder conteudoCompleto = new StringBuilder();

            string nomeArquivo = string.Empty;

            string diretorioArquivos = string.Empty;

            string caminhoArquivoOutput = string.Empty;

            Console.WriteLine("Informe o caminho dos scripts que deseja consolidar: ");

            diretorioArquivos = Console.ReadLine();

            diretorioArquivos = diretorioArquivos.Replace(@"\", "\\");

            Console.WriteLine("Informe o caminho do arquivo Consolidado: ");

            caminhoArquivoOutput = Console.ReadLine();

            caminhoArquivoOutput = caminhoArquivoOutput.Replace(@"\", "\\");

            var listaArquivos = Directory.GetFiles(diretorioArquivos);

            foreach (var Arquivo in listaArquivos)
            {
                nomeArquivo = "------------- " + Arquivo.Substring(Arquivo.LastIndexOf("\\")) + "------------------";
                nomeArquivo = nomeArquivo.Replace("\\", string.Empty);
                conteudoArquivo = File.ReadAllText(Arquivo);
                conteudoCompleto.Append(nomeArquivo).Append("\n");
                conteudoCompleto.Append(conteudoArquivo);
                conteudoCompleto.Append("\n");
            }
            try
            {
                File.WriteAllText(caminhoArquivoOutput + "\\consolidado.sql", conteudoCompleto.ToString(), Encoding.UTF8);
                Console.WriteLine("Arquivo consolidado com sucesso.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha ao gravar arquivo. \n Erro: " + ex.Message);
                Console.ReadKey();
            }
            
        }
    }
}
