
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

public class Livro
{
    public string codigo { get; set; }
    public string titulo { get; set; }
    public string sinopse { get; set;}
    public string genero { get; set;}
    public string autor { get; set; }
    public string ano { get; set;}
    public string editora { get; set;}
    public double precoaquisicao { get; set; }
    public double lucro { get; set; }
    public double valorvenda { get; set; }


    public Livro()
    {

    }

    public bool CadastrarLivro(Livro livro)
    {
        try
        {

            string caminhoarquivo = ("C:\\Users\\vanes\\OneDrive\\2 B IFRO\\LIVROS.doc");

            using(StreamWriter file = File.AppendText(caminhoarquivo))
            {
                file.WriteLine($"Código: {livro.codigo} Título: {livro.titulo} Sinopse: {livro.sinopse} Gênero: {livro.genero} Autor(a): {livro.autor} Ano lançamento: {livro.ano} Editora: {livro.editora} Preço aquisição: {livro.precoaquisicao} Lucro: {livro.lucro} Valor a ser vendido: {livro.valorvenda}");
            }

        }   

        catch (Exception ex)
        {
            MessageBox.Show("Erro ao salvar o livro" + ex.Message);
            return false; 

           

        }
      return true;
    }

    public static List<Livro> LerArquivo()
    {
        List<Livro> livros = new List<Livro>();
        string[] linhas = File.ReadAllLines("C:\\Users\\vanes\\OneDrive\\2 B IFRO\\LIVROS.doc");
        

        foreach(string s in linhas)
        {
            string []a = s.Split(' ');
            Livro v = new Livro();
            v.codigo = a[0];
            v.titulo = a[1];
            v.sinopse = a[2];
            v.genero = a[3];
            v.autor = a[4];
            v.ano = a[5];
            v.editora = a[6];

            double valorVenda;
            double lucro;
            double precoAquisicao;

            if (double.TryParse(a[7], out valorVenda))
            {
                v.valorvenda = valorVenda;

                if (double.TryParse(a[8], out lucro))
                {
                    v.lucro = lucro;
                }
                if (double.TryParse(a[9], out precoAquisicao))
                {
                    v.precoaquisicao = precoAquisicao;
                }

            }



           

            livros.Add(v); 
        }

     
      
        return livros;
    }
}

