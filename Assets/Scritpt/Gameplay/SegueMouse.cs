using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueMouse : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    private Vector3 posicao;

    private void Awake()
    {
        this.posicao = Input.mousePosition;
        this.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(this.posicao);
    }

    private void Update()
    {
        this.posicao = Input.mousePosition;

        var destino = Camera.main.ScreenToWorldPoint(this.posicao);
        if(Vector3.Distance(this.transform.position, destino) > .5f)
        {
            Vector2 direcao = destino - this.transform.position;            
            this.transform.position += (Vector3)(direcao * velocidade * Time.deltaTime);
        }

    }


}
