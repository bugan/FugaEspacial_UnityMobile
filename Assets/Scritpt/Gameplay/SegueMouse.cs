using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueMouse : MonoBehaviour
{
    private const float DISTANCIA_MAXIMA = .5f;
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
        if (this.EstaMuitoLonge(destino))
        {
            Vector2 direcao = destino - this.transform.position;
            this.transform.position += (Vector3)(direcao * velocidade * Time.deltaTime);
        }

    }

    private bool EstaMuitoLonge(Vector3 destino)
    {
        return Vector3.Distance(this.transform.position, destino) > DISTANCIA_MAXIMA;
    }
}
