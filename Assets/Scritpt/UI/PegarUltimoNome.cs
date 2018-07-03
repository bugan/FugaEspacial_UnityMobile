using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegarUltimoNome : MonoBehaviour {

    
    private InputField inputNome;

    private void Awake()
    {
        this.inputNome = this.GetComponent<InputField>();    
    }

    private void Start () {
        var ultimoNome = "Jogagor";
        if (PlayerPrefs.HasKey("UltimoNome"))
        {
            ultimoNome = PlayerPrefs.GetString("UltimoNome");
        }

        this.inputNome.text = ultimoNome;
    }

}
