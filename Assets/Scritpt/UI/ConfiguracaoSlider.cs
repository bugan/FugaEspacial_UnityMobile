using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class ConfiguracaoSlider : MonoBehaviour
{
    private const float VALOR_PADRAO = 0.85f;

    [SerializeField]
    private string parametro;   

    private Slider slider;

    private void Awake()
    {
        this.slider = this.GetComponent<Slider>();
    }

    private void Start()
    {
        this.slider.value = this.GetValorPadrao();
    }

    public void AtualizarValorSalvo(float novoValor)
    {
        PlayerPrefs.SetFloat(this.parametro, novoValor);
    }

    private float GetValorPadrao()
    {
        if (PlayerPrefs.HasKey(this.parametro))
        {
            return PlayerPrefs.GetFloat(this.parametro);
        }

        return VALOR_PADRAO;
    }
}
