using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private float tempo;
    [SerializeField]
    private Rect area;
    [SerializeField]
    private Pool pool;
    

    private void Start()
    {
        InvokeRepeating("Instanciar", 0, this.tempo);
    }

    private void Instanciar()
    {
        var inimigo = this.pool.PegarObjeto();
        if (inimigo != null)
        {
            var gobj = inimigo.gameObject;

            var posicaoAleatoria = new Vector3(
                Random.Range(this.area.x, this.area.x + this.area.width),
                Random.Range(this.area.y, this.area.y + this.area.height),
                0);

            var posicaoInimigo = this.transform.position + posicaoAleatoria;
            gobj.transform.position = posicaoInimigo;
            gobj.GetComponent<Seguir>().SetAlvo(this.alvo);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255, 0, 150, .5f);
        var posicao = new Vector3(
            this.transform.position.x + this.area.x + this.area.width/2,
            this.transform.position.y + this.area.y + this.area.height / 2,
            0);

        Gizmos.DrawWireCube(posicao, new Vector3(this.area.width, this.area.height, 0));
    }
}
