using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private string arquivo = "ranking.json";

    public ListaColocados ListaColocados { get; private set; }

    private void Awake()
    {
        string caminhoArquivo = Path.Combine(Application.persistentDataPath, this.arquivo);

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
        string caminhoArquivo = Path.Combine(Application.persistentDataPath, this.arquivo);
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
        var index = -1;
        for (var i = this.colocados.Count - 1; i >= 0; i--)
        {
            if (this.colocados[i].pontos <= novaEntrada.pontos)
            {
                index = i;
            }
        }

        this.tamanho++;
        if (index == -1)
        {
            this.colocados.Add(novaEntrada);
            return this.colocados.Count - 1;
        }
        else
        {
            this.colocados.Insert(index, novaEntrada);
            return index;
        }
    }

    public Item GetColocado()
    {
        if (this.index >= this.tamanho)
        {
            return null;
        }

        var proximo = this.colocados[index];
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
