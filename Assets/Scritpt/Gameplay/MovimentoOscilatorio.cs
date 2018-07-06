using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoOscilatorio : MonoBehaviour
{

    [SerializeField]
    private float velocidade;
    [SerializeField]
    private float amplitude;
    [SerializeField]
    private bool inverter;

    private float angulo;
    private Vector3 posicaoInicial;

    private void Awake()
    {
        this.angulo = 0;
        this.posicaoInicial = this.transform.position;
    }

    void Update()
    {
        this.angulo += velocidade * Time.deltaTime;
        float deslocamento = CalcularDeslocamento();
        this.transform.position = this.posicaoInicial + Vector3.up * amplitude * deslocamento;
    }

    private float CalcularDeslocamento()
    {
        var deslocamento = Mathf.Cos(angulo);
        if (this.inverter)
        {
            deslocamento = Mathf.Sin(angulo);
        }

        return deslocamento;
    }
}
