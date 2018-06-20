using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private float forca = 1;

    private Rigidbody2D fisica;

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (this.alvo == null) return;

        var direcao = this.alvo.position - this.transform.position;
        direcao = direcao.normalized;

        this.fisica.AddForce(direcao * forca, ForceMode2D.Force);
    }

    public void SetAlvo(Transform novoAlvo)
    {
        this.alvo = novoAlvo;
    }
}
