﻿
using System;
using System.Collections.Generic;
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
            var file = File.AppendText("C:\\Users\\vanes\\OneDrive\\2 B IFRO\\LIVROS.doc");
            file.WriteLine($"Código: {livro.codigo} Título: {livro.titulo} Sinopse: {livro.sinopse} Gênero: {livro.genero} Autor(a): {livro.autor} Ano lançamento: {livro.ano} Editora: {livro.editora} Preço aquisição: {livro.precoaquisicao} Lucro: {livro.lucro} Valor a ser vendido: {livro.valorvenda}");
            file.Close();

        }   
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao salvar o livro" + ex.Message);
        }
      return true;


    }






    /*public bool Salvar(Livro livro)
    {
        try
        {
            using (var salvar = new StreamWriter("C:\\Cadastro Livro\\Livro.doc"))
            {
                salvar.WriteLine($"Código: {livro.codigo} Título: {livro.titulo} Sinopse: {livro.sinopse} Gênero: {livro.genero} Autor(a): {livro.autor} Ano lançamento: {livro.ano} Editora: {livro.editora} Preço aquisição: {livro.precoaquisicao} Lucro: {livro.lucro} Valor a ser vendido: {livro.valorvenda}");
            }

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }*/

    public static List<Livro> LerArquivo()
    {
        List<Livro> livros = new List<Livro>(); 
        string[] linhas = File.ReadAllLines("C:\\Cadastro Livro\\Livro.doc");

        foreach(string s in linhas)
        {
            string []a = s.Split('-');
            Livro v = new Livro();
            v.codigo = a[0];
            v.titulo = a[1];
            v.sinopse = a[2];
            v.genero = a[3];
            v.autor = a[4];
            v.ano = a[5];
            v.editora = a[6];
            v.valorvenda = Convert.ToInt32(Console.ReadLine());
            v.lucro = Convert.ToInt32(Console.ReadLine());
            v.precoaquisicao = Convert.ToInt32(Console.ReadLine());

            livros.Add(v);
        }

     
      
        return livros;
    }
}

