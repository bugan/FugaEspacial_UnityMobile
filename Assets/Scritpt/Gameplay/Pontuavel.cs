using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuavel : MonoBehaviour {

    [HideInInspector]
    private Pontuacao pontuacao;

    public void Pontuar()
    {
        this.pontuacao.Pontuar();
    }

    public void SetPontuacao(Pontuacao pontuacao)
    {
        this.pontuacao = pontuacao;
    }

}
