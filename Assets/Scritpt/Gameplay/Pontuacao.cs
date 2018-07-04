using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pontuacao : MonoBehaviour {
    [SerializeField]
    private EventoDinamicoComInt aoPontuar;

    public int Pontos { get; private set; }

    private static Pontuacao _instancia;
    public static Pontuacao Instancia
    {
        get
        {
            if (NaoFoiInicializado())
            {
                _instancia = FindObjectOfType<Pontuacao>();
            }
            return _instancia;
        }
    }

    private static bool NaoFoiInicializado()
    {
        return _instancia == null;
    }

    public void Pontuar()
    {
        this.Pontos++;
        this.aoPontuar.Invoke(this.Pontos);
    }

    private void Awake()
    {
        if(_instancia != null)
        {
            GameObject.Destroy(_instancia.gameObject);
        }
    }
}

[System.Serializable]
public class EventoDinamicoComInt: UnityEvent<int>{}