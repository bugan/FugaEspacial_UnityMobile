using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour {
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private float tempo;
	
	private void Start () {
        InvokeRepeating("Instanciar", 0, this.tempo);
	}
	
    private void Instanciar()
    {
        var gobj = GameObject.Instantiate(this.prefab, this.transform, true);
        gobj.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
        gobj.GetComponent<Seguir>().SetAlvo(this.alvo);
    }
}
