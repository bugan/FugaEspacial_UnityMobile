using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovaPontuacao : MonoBehaviour
{
    private const int VALOR_DE_ERRO = -1;
    public const string CHAVE_ULTIMO_NOME = "UltimoNome";
    public const string NOME_PADRAO = "Jogagor";

    [SerializeField]
    private Ranking ranking;
    [SerializeField]
    private Text nome;
    [SerializeField]
    private Text pontos;

    private int index;
    private int totalDePontos;
    private Pontuacao pontuacao;

    void Start()
    {

        this.totalDePontos = GetPontuacao();
        string ultimoNome = GetUltimoNome();

        this.pontos.text = this.totalDePontos.ToString();
        this.nome.text = ultimoNome;

        this.Salvar(ultimoNome);
    }

    private int GetPontuacao()
    {
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();

        var totalDePontos = VALOR_DE_ERRO;

        if (Existe(this.pontuacao))
        {
            totalDePontos = this.pontuacao.Pontos;
        }

        return totalDePontos;
    }

    public static string GetUltimoNome()
    {
        var ultimoNome = NOME_PADRAO;
        if (PlayerPrefs.HasKey(CHAVE_ULTIMO_NOME))
        {
            ultimoNome = PlayerPrefs.GetString(CHAVE_ULTIMO_NOME);
        }

        return ultimoNome;
    }

    private static bool Existe(Object objeto)
    {
        return objeto != null;
    }

    public void AlterarNome(string nome)
    {
        this.nome.text = nome;
        this.ranking.AlterarNome(nome, index);

        PlayerPrefs.SetString(CHAVE_ULTIMO_NOME, nome);
    }

    private void Salvar(string nome)
    {
        this.index = this.ranking.AdicionarPontuacao(this.totalDePontos, nome);
        this.ranking.SalvarColocacao();
    }
}
