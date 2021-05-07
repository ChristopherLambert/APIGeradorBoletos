using APIGerarBoletos.Models;
using BoletoNet;
using System;
using System.IO;

//BOLETO.NET VERSÃO 1 -- SEM SUPORTE A NET CORE, APENAS A NET FRAMEWORK
namespace APIGerarBoletos.Services
{
    public abstract class GeradorBase
    {
        protected MemoryStream SaveBoletoPDF(byte[] boletoPdf, bool isFile = false)
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(boletoPdf, 0, boletoPdf.Length);
            stream.Seek(0, SeekOrigin.Begin);

            if (isFile)
            {
                if (File.Exists("C:\\boleto.pdf"))
                    File.Delete("C:\\boleto.pdf");

                var fileStream = File.Create("C:\\boleto.pdf");
                stream.CopyTo(fileStream);
                fileStream.Close();
            }

            return stream;
        }
    }
}
