using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pontuacao : MonoBehaviour
{
    public int Pontos
    {
        get
        {
            return this.pontos;
        }
    }

    [SerializeField]
    private MeuEventoDinamicoInt aoPontuar;

    private int pontos;


    public void Pontuar()
    {
        this.pontos++;
        this.aoPontuar.Invoke(this.pontos);
    }
}

[System.Serializable]
public class MeuEventoDinamicoInt : UnityEvent<int> { }
