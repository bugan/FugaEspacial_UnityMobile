using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueMouse : MonoBehaviour {
	private void Update () {
        var destino = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(destino.x, destino.y, this.transform.position.z);
	}
}
