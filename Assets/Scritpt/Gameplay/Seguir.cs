using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{   
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private float velocidade;

    private Rigidbody2D fisica;

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var direcaoDesejada = (Vector2)(this.alvo.position - this.transform.position);
        direcaoDesejada = direcaoDesejada.normalized;
        direcaoDesejada *= velocidade;
        this.fisica.AddForce(direcaoDesejada, ForceMode2D.Force);
    }

    public void SetAlvo(Transform alvo)
    {
        this.alvo = alvo;
    }
}
