﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TrabalhandoComArquivos.Entities;

namespace TrabalhandoComArquivos
{
    class Program
    {
        static void Main(string [] args)
        {

            List<Product> list = new List<Product>();
            Console.Write("Entre com o nome do arquivo a ser criado (digitar o formato ex : txt, csv .....) :  ");
            string arq = Console.ReadLine();
            Console.WriteLine();

            string caminho = @"C:\Users\alexandre.filho\Desktop\pastaEntrada\" + arq;
            string subPasta = @"C:\Users\alexandre.filho\Desktop\pastaEntrada\pastadeSaida";

            Console.Write("Entre com o nome do arquivo a ser criado na saida (digitar o formato ex : txt, csv .....) :  ");
            string saida = Console.ReadLine();
            Console.WriteLine();

            string arquivoDeSaida = subPasta + @"\" + saida;

            Directory.CreateDirectory(subPasta);

            try
            {
                Console.WriteLine("Quantos vão ser adicionados ? : ");
                int n = int.Parse(Console.ReadLine());

                for(int i = 0 ; i < n ; i++)
                {
                    Console.Write("Nome : ");
                    string nome = Console.ReadLine();
                    Console.Write("Preço : ");
                    double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Quantidade : ");
                    int qtd = int.Parse(Console.ReadLine());
                    list.Add(new Product(nome, preco, qtd));
                    Console.WriteLine();

                }
                foreach(Product prod in list)
                {
                    using(StreamWriter writer = new StreamWriter(caminho, true))
                    {
                        writer.WriteLine(prod.ToString());
                    }
                }
                foreach(Product prod in list)
                {
                    using(StreamWriter sw = File.AppendText(arquivoDeSaida))
                    {
                        sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }

            }
            catch(IOException)
            {

                Console.WriteLine("ERROR !");
            }

            Console.Read();


        }
    }
}
