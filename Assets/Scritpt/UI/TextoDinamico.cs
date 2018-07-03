using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextoDinamico : MonoBehaviour {
    private Text texto;

    private void Awake()
    {
        this.texto = this.GetComponent<Text>();
    }

    public void AtualizarTexto(int novoTexto)
    {
        this.texto.text = novoTexto.ToString() ;
    }

    public void AtualizarTexto(string novoTexto)
    {
        this.texto.text = novoTexto;
    }
}
