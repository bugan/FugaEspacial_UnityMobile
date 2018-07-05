using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{

    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private Pontuacao pontuacao;
    [SerializeField]
    private float tempo;
    [SerializeField]
    private Rect area;
    [SerializeField]
    private Pool pool;
    
    private Color corDoGuizmo = new Color(255, 0, 150, .5f);

    private void Start()
    {
        InvokeRepeating("Instanciar", 0, this.tempo);
        if(this.pontuacao == null)
        {
            this.pontuacao = GameObject.FindGameObjectWithTag(Pontuacao.TAG_PONTUACAO).GetComponent<Pontuacao>();
        }
    }

    private void Instanciar()
    {
        var inimigo = this.pool.PegarObjeto();
        if (InimigoExiste(inimigo))
        {
            var gameObjectDoInimigo = inimigo.gameObject;
            this.DefinirPosicaoInimigo(gameObjectDoInimigo);
            this.InjetarDependencias(gameObjectDoInimigo);
        }
    }

    private void InjetarDependencias(GameObject gameObjectDoInimigo)
    {
        gameObjectDoInimigo.GetComponent<Seguir>().SetAlvo(this.alvo);
        gameObjectDoInimigo.GetComponent<Pontuavel>().pontuacao = this.pontuacao;
    }

    private void DefinirPosicaoInimigo(GameObject inimigo)
    {
        var posicaoAleatoria = new Vector3(
                        Random.Range(this.area.x, this.area.x + this.area.width),
                        Random.Range(this.area.y, this.area.y + this.area.height),
                        0);

        var posicaoInimigo = this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }

    private bool InimigoExiste(ObjetoDePool inimigo)
    {
        return inimigo != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = corDoGuizmo;

        var posicao = new Vector3(
            this.transform.position.x + this.area.x + this.area.width/2,
            this.transform.position.y + this.area.y + this.area.height / 2,
            0);

        Gizmos.DrawWireCube(posicao, new Vector3(this.area.width, this.area.height, 0));
    }
}
