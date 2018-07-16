using System.Collections;
using UnityEngine;

public class ControlePause : MonoBehaviour
{

    [SerializeField]
    private GameObject painelPause;

    private void Update()
    {
        if (EstaoTocandoNaTela())
        {
            this.ContinuarOJogo();
        }
        else
        {
            this.PararOJogo();
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
        this.painelPause.SetActive(true);
    }

    private void ContinuarOJogo()
    {
        this.painelPause.SetActive(false);
    }
}
