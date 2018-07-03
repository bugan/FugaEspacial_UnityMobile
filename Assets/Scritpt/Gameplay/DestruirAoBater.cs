using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestruirAoBater : MonoBehaviour {
    [SerializeField]
    private UnityEvent aoBater;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        aoBater.Invoke();
    }
}
