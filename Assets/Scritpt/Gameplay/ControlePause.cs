using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePause : MonoBehaviour
{
    private const float INTERVALO_FIXED_UPDATE = 0.02f;
    private const float ESCALA_NORMAL_DE_TEMPO = 1f;

    [SerializeField]
    private GameObject painelPause;
    [SerializeField, Range(0, 1)]
    private float escalaDeTempoDuranteOPause = 0.005f;
    [SerializeField]
    private float tempoAntesDoPause;

    private Coroutine espera;
    private bool estaParado;

    private void Awake()
    {
        this.MudarEscalaDeTempo(ESCALA_NORMAL_DE_TEMPO);
    }

    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.A))
        {
            this.DevePararOJogo();
        }
        else
        {
            this.DeveContinuarOJogo();
        }

#elif UNITY_ANDROID
        if(Input.touchCount == 0){
            this.DevePararOJogo();
        }else{
            this.DeveContinuarOJogo();   
        }
#endif

    }

    private void DevePararOJogo()
    {
        if (this.espera != null) return;

        this.espera = StartCoroutine(EsperarEPausar(this.tempoAntesDoPause));
        this.MudarEscalaDeTempo(this.escalaDeTempoDuranteOPause);
    }

    private void DeveContinuarOJogo()
    {
        if (this.espera != null)
        {
            StopCoroutine(this.espera);
            this.espera = null;
        }
        StartCoroutine(EsperarERetomar(.5f));
    }

    private void RetomarJogo()
    {
        if (!estaParado) return;
        this.MudarEscalaDeTempo(ESCALA_NORMAL_DE_TEMPO);
        painelPause.SetActive(false);
        this.estaParado = false;
    }

    private void PausarJogo()
    {
        if (estaParado) return;

        painelPause.SetActive(true);
        this.estaParado = true;
    }

    private void MudarEscalaDeTempo(float escala)
    {
        Time.timeScale = escala;
        Time.fixedDeltaTime = INTERVALO_FIXED_UPDATE * Time.timeScale;
    }

    private IEnumerator EsperarEPausar(float tempo)
    {
        yield return new WaitForSecondsRealtime(tempo);
        this.PausarJogo();
    }

    private IEnumerator EsperarERetomar(float tempo)
    {
        yield return new WaitForSecondsRealtime(tempo);
        this.RetomarJogo();
    }
}
