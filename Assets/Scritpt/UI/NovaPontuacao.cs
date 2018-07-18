using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovaPontuacao : MonoBehaviour {
    private const int VALOR_DE_ERRO = -1;

    [SerializeField]
    private Text textoPontuacao;

    private Pontuacao pontuacao;
	
	private void Start () {
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();

        var totalDePontos = VALOR_DE_ERRO;

        if (Existe(this.pontuacao))
        {
            totalDePontos = this.pontuacao.Pontos;
        }

        this.textoPontuacao.text = totalDePontos.ToString();
	}
	
	private bool Existe(Object objeto)
    {
        return objeto != null;
    }
}
