using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class ConfiguracaoSlider : MonoBehaviour {
    [SerializeField]
    private string parametro;
    [SerializeField]
    private float valorPadrao = 0.85f;

    private Slider slider;

    private void Awake()
    {
        this.slider = this.GetComponent<Slider>();
    }

    private void Start () {
        if (PlayerPrefs.HasKey(this.parametro))
        {
            this.slider.value = PlayerPrefs.GetFloat(this.parametro);
        }
        else
        {
            this.slider.value = this.valorPadrao;
        }
	}
	
	public void AtualizarValorSalvo(float novoValor)
    {
        PlayerPrefs.SetFloat(this.parametro, novoValor);
    }
}
