using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfiguracaoVibrar : MonoBehaviour
{
    public static string Vibrar = "Vibrar";

    private const int LIGADO = 1;
    private const int DESLIGADO = 0;

    [SerializeField]
    private Toggle toggle;

    private void Awake()
    {
        this.toggle.isOn = DeveVibrar();
    }

    public void SalvarConfiguracao(bool vibrar)
    {
        if (vibrar)
        {
            PlayerPrefs.SetInt(Vibrar, LIGADO);
        }
        else
        {
            PlayerPrefs.SetInt(Vibrar, DESLIGADO);
        }
    }

    private static bool DeveVibrar()
    {
        return PlayerPrefs.GetInt(Vibrar) == LIGADO;
    }
}
