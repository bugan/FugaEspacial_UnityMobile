using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private float velocidadeMaxima = 1;
    

    private Rigidbody2D fisica;

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (this.alvo == null) return;

        var direcaoDesejada = (Vector2)(this.alvo.position - this.transform.position);
        direcaoDesejada = direcaoDesejada.normalized;
        direcaoDesejada *= velocidadeMaxima;
        
        var forcaDeManobra = direcaoDesejada - this.fisica.velocity; 

        this.fisica.AddForce(forcaDeManobra, ForceMode2D.Force);
    }

    public void SetAlvo(Transform novoAlvo)
    {
        this.alvo = novoAlvo;
    }
}
