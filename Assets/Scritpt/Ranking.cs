using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private static string NOME_DO_ARQUIVO = "ranking.json";

    private ListaColocados lista;

        private void Awake()
    {
        var caminhoArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        if (File.Exists(caminhoArquivo)){
            var textoJson = File.ReadAllText(caminhoArquivo);
            this.lista = JsonUtility.FromJson<ListaColocados>(textoJson);
        }else{
            this.lista = new ListaColocados();
        }

    }

    public void AdicionarPontuacao(int novaPontuacao, string nome)
    {
        this.lista.AdicionarColocado(novaPontuacao, nome);
        this.SalvarRanking();
    }

    public Item GetColocado()
    {
        return this.lista.GetColocado();
    }

    private void SalvarRanking()
    {
        var textoJSON = JsonUtility.ToJson(this.lista);
        var caminhoArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        File.WriteAllText(caminhoArquivo, textoJSON);
    }


}

[Serializable]
public class ListaColocados
{
    [SerializeField]
    private List<Item> colocados;

    private int index;

    public ListaColocados()
    {
        this.colocados = new List<Item>();
        this.index = 0;
    }

    public void AdicionarColocado(int pontos, string nome)
    {
        var novoItem = new Item(1, nome);
        var colocacao = this.GetIndexColocacao(novoItem);
        if (colocacao == -1)
        {
            this.colocados.Add(novoItem);
        }
        else
        {
            this.colocados.Insert(colocacao, novoItem);
        }
    }

    public Item GetColocado()
    {
        if (this.index >= this.colocados.Count)
        {
            return null;
        }

        var proximo = this.colocados[this.index];
        this.index++;

        return proximo;
    }

    private int GetIndexColocacao(Item novaEntrada)
    {
        var index = -1;

        for (var i = 0; i < this.colocados.Count; i++)
        {
            if (this.colocados[i].pontos <= novaEntrada.pontos)
            {
                index = i;
                break;
            }
        }

        return index;
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