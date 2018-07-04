using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegarUltimoNome : MonoBehaviour {
    private InputField entradaNome;

    private void Awake()
    {
        this.entradaNome = this.GetComponent<InputField>();    
    }

    private void Start () {
        this.entradaNome.text = NovaPontuacao.GetUltimoNome();
    }

}
