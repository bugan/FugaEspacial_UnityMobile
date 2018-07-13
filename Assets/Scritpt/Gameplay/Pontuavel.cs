using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuavel : MonoBehaviour
{
    [HideInInspector]
    private Pontuacao pontuacao;

    public void Pontuar()
    {
        pontuacao.Pontuar();
        if (PlayerPrefs.GetInt(ConfiguracaoVibrar.Vibrar) == 1)
        {
            Handheld.Vibrate();
        }
    }

    public void SetPontuacao(Pontuacao pontuacao)
    {
        this.pontuacao = pontuacao;
    }
}
