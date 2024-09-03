using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade;
    private Rigidbody rigidbodyInimigo;
    private Animator animatorInimigo;

    // Start is called before the first frame update
    void Start()
    {
        int geraTipoZumbi = Random.Range(1, 28);

        jogador = GameObject.FindWithTag("Player");
        rigidbodyInimigo = GetComponent<Rigidbody>();
        animatorInimigo = GetComponent<Animator>();

        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        Vector3 direcao = jogador.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);

        rigidbodyInimigo.MoveRotation(novaRotacao);

        if (distancia > 3) {
            rigidbodyInimigo.MovePosition(
                rigidbodyInimigo.position +
                (direcao.normalized * velocidade * Time.deltaTime)
            );
            animatorInimigo.SetBool("Atacando", false);
        } else {
            animatorInimigo.SetBool("Atacando", true);
        }

    }

    void AtacaJogador() {
        Time.timeScale = 0;
        jogador.GetComponent<ControlaJogador>().textoGameOver.SetActive(true);
        jogador.GetComponent<ControlaJogador>().vivo = false;
    }
}
