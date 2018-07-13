using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour {
    public int Pontos { get; private set; }
    private int pontos;
	
     public void Pontuar() {
        this.pontos++;
    }
}
