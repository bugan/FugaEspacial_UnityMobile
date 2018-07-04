using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuavel : MonoBehaviour
{
    

    public void Pontuar()
    {
        Pontuacao.Instancia.Pontuar();
        if (PlayerPrefs.GetInt(ConfiguracaoVibrar.Vibrar) == 1)
        {
            Handheld.Vibrate();
        }
    }
}
