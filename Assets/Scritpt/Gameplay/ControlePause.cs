using System.Collections;
using UnityEngine;

public class ControlePause : MonoBehaviour
{
    private const float ESCALA_NORMAL_DE_TEMPO = 1;
    private const float TAXA_PADRAO_DE_ATUALIZACAO_DA_FISICA = 0.02f;

    [SerializeField]
    private GameObject painelPause;

    [SerializeField, Range(0, ESCALA_NORMAL_DE_TEMPO)]
    private float escalaDeTempoDuranteOPause = 0.2f;

    private bool parado;
    private void Update()
    {
        if (EstaoTocandoNaTela())
        {
            if (this.parado)
            {
                this.ContinuarOJogo();
            }
        }
        else
        {
            if (!this.parado)
            {
                this.PararOJogo();
            }
        }
    }

    private bool EstaoTocandoNaTela()
    {
#if UNITY_EDITOR
        return Input.GetKey(KeyCode.A);
#elif UNITY_ANDROID
        return Input.touchCount > 0;
#endif
    }

    private void PararOJogo()
    {
        this.parado = true;
        this.painelPause.SetActive(true);
        this.AlterarEscalaDeTempo(this.escalaDeTempoDuranteOPause);
    }

    private void ContinuarOJogo()
    {
        this.parado = false;
        StartCoroutine(this.EsperarEContinuarOJogo());
    }

    private void AlterarEscalaDeTempo(float novaEscala)
    {
        Time.timeScale = novaEscala;
        Time.fixedDeltaTime = TAXA_PADRAO_DE_ATUALIZACAO_DA_FISICA * novaEscala;
    }

    private IEnumerator EsperarEContinuarOJogo()
    {
        yield return new WaitForSecondsRealtime(.1f);
        this.painelPause.SetActive(false);
        this.AlterarEscalaDeTempo(ESCALA_NORMAL_DE_TEMPO);
    }
}
