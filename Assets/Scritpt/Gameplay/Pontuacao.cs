using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Pontuacao : MonoBehaviour {
    [SerializeField]
    private EventoDinamicoComInt aoPontuar;
    
    public int Pontos { get; private set; }
    
    public void Pontuar()
    {
        this.Pontos++;
        this.aoPontuar.Invoke(this.Pontos);
    }
}

[System.Serializable]
public class EventoDinamicoComInt: UnityEvent<int>{}