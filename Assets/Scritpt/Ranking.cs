using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private const string NOME_DO_ARQUIVO = "ranking.json";

    public ListaColocados ListaColocados { get; private set; }

    private void Awake()
    {
        string caminhoArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);

        if (File.Exists(caminhoArquivo))
        {
            string dadosJson = File.ReadAllText(caminhoArquivo);
            this.ListaColocados = JsonUtility.FromJson<ListaColocados>(dadosJson);
        }
        else
        {
            this.ListaColocados = new ListaColocados();
        }
    }

    public int AdicionarPontuacao(int pontuacao, string nome)
    {
        return this.ListaColocados.AdicionarColocado(new Item(pontuacao, nome));
    }


    public void SalvarColocacao()
    {
        string caminhoArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        File.WriteAllText(caminhoArquivo, JsonUtility.ToJson(this.ListaColocados));
    }

    public void AlterarNome(string nome, int index)
    {
        this.ListaColocados.AlterarNome(nome, index);
        this.SalvarColocacao();
    }

    public Item GetColocado()
    {
        return this.ListaColocados.GetColocado();
    }
}

[Serializable]
public class ListaColocados
{
    private const int INDEX_PADRAO = -1;
    public int tamanho;
    public List<Item> colocados;

    private int index;

    public ListaColocados()
    {

        this.colocados = new List<Item>();
        this.tamanho = 0;
        this.index = 0;
    }

    public int AdicionarColocado(Item novaEntrada)
    {
        var index = INDEX_PADRAO;
        index = GetIndexColocacao(novaEntrada, index);

        this.tamanho++;

        if (NaoEncontrouColocacao(index))
        {
            return AdicionarNoFinalDaLista(novaEntrada);
        }
        else
        {
            return InserirNoLocalCorreto(novaEntrada, index);
        }
    }

    private int InserirNoLocalCorreto(Item novaEntrada, int index)
    {
        this.colocados.Insert(index, novaEntrada);
        return index;
    }

    private int AdicionarNoFinalDaLista(Item novaEntrada)
    {
        this.colocados.Add(novaEntrada);
        return this.colocados.Count - 1;
    }

    private int GetIndexColocacao(Item novaEntrada, int index)
    {
        for (var i = this.colocados.Count - 1; i >= 0; i--)
        {
            if (this.MaiorQueElemento(novaEntrada, i))
            {
                index = i;
            }
        }

        return index;
    }

    private static bool NaoEncontrouColocacao(int index)
    {
        return index == INDEX_PADRAO;
    }

    private bool MaiorQueElemento(Item novaEntrada, int i)
    {
        return this.colocados[i].pontos <= novaEntrada.pontos;
    }

    public Item GetColocado()
    {
        if (this.index >= this.tamanho)
        {
            return null;
        }
        
        var proximo = this.colocados[this.index];
        this.index++;

        return proximo;
    }

    public void AlterarNome(string nome, int index)
    {
        this.colocados[index].nome = nome;
    }
}

[Serializable]
public class Item
{
    public int pontos;
    public string nome;

    public Item(int pontos, string nome)
    {
        this.pontos = pontos;
        this.nome = nome;
    }
}
