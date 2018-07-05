using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Pontuacao : MonoBehaviour {
    public static string TAG_PONTUACAO = "Pontuação";

    [SerializeField]
    private EventoDinamicoComInt aoPontuar;
    
    public int Pontos { get; private set; }

    private void Awake()
    {
        TAG_PONTUACAO = this.tag;
    }

    public void Pontuar()
    {
        this.Pontos++;
        this.aoPontuar.Invoke(this.Pontos);
    }
}

[System.Serializable]
public class EventoDinamicoComInt: UnityEvent<int>{}