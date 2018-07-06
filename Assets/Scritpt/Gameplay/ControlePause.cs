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
    private float tempoAntesDeParar;
    [SerializeField]
    private float tempoAntesDeRetornar;

    private Coroutine tarefaAntesDeParar;
    private Coroutine tarefaAntesDeRetornar;
    private bool estaParado;

    private delegate void AcaoDePause();

    private void Awake()
    {
        this.MudarEscalaDeTempo(ESCALA_NORMAL_DE_TEMPO);
    }

    private void Update()
    {
        if (NaoEstaoTocandoNaTela())
        {
            this.PararOJogo();
        }
        else
        {
            this.ContinuarOJogo();
        }
    }

    private bool NaoEstaoTocandoNaTela()
    {
#if UNITY_EDITOR
        return Input.GetKey(KeyCode.A);
#elif UNITY_ANDROID
        return Input.touchCount == 0;
#endif
    }

    private void PararOJogo()
    {
        this.AjustarTarefasEmEspera(ref this.tarefaAntesDeParar, ref this.tarefaAntesDeRetornar, EsperarEExecutarAcao(this.tempoAntesDeParar, MostrarPainelDePause));
        this.MudarEscalaDeTempo(this.escalaDeTempoDuranteOPause);
    }

    private void ContinuarOJogo()
    {
        this.AjustarTarefasEmEspera(ref this.tarefaAntesDeRetornar, ref this.tarefaAntesDeParar, EsperarEExecutarAcao(this.tempoAntesDeRetornar, RetomarJogo));
    }

    private void RetomarJogo()
    {
        this.painelPause.SetActive(false);
        this.MudarEscalaDeTempo(ESCALA_NORMAL_DE_TEMPO);
    }

    private void MostrarPainelDePause()
    {
        this.painelPause.SetActive(true);
    }

    private void MudarEscalaDeTempo(float escala)
    {
        Time.timeScale = escala;
        Time.fixedDeltaTime = INTERVALO_FIXED_UPDATE * Time.timeScale;
    }

    private IEnumerator EsperarEExecutarAcao(float tempo, AcaoDePause acao)
    {
        yield return new WaitForSecondsRealtime(tempo);
        acao();
    }

    private bool TarefaEstaEmEspera(Coroutine tarefa)
    {
        return tarefa != null;
    }

    private void InterromperTarefaEmEspera(ref Coroutine tarefa)
    {
        StopCoroutine(tarefa);
        tarefa = null;
    }

    private void AjustarTarefasEmEspera(ref Coroutine paraIniciar, ref Coroutine paraParar, IEnumerator rotina)
    {
        if (this.TarefaEstaEmEspera(paraIniciar)) return;

        if (this.TarefaEstaEmEspera(paraParar))
        {
            this.InterromperTarefaEmEspera(ref paraParar);
        }

        paraIniciar = StartCoroutine(rotina);
    }
}
