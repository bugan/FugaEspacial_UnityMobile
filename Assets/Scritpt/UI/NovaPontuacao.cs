using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovaPontuacao : MonoBehaviour {
    [SerializeField]
    private Ranking ranking;
    [SerializeField]
    private Text nome;
    [SerializeField]
    private Text pontos;

    private int index;
    private int totalDePontos;

    void Start () {
        this.totalDePontos = -1;
        if (Pontuacao.Instancia != null)
        {
            this.totalDePontos = Pontuacao.Instancia.Pontos;
        }

        this.pontos.text = this.totalDePontos.ToString();

        var ultimoNome = "Jogagor";
        if (PlayerPrefs.HasKey("UltimoNome"))
        {
            ultimoNome = PlayerPrefs.GetString("UltimoNome");
        }

        this.nome.text = ultimoNome;
        this.Salvar(ultimoNome);
    }

    public void AlterarNome(string nome)
    {
        this.nome.text = nome;
        this.ranking.AlterarNome(nome, index);
        
        PlayerPrefs.SetString("UltimoNome", nome);
    }

    private void Salvar(string nome)
    {
        this.index = this.ranking.AdicionarPontuacao(this.totalDePontos, nome);
        this.ranking.SalvarColocacao();
    }
}
