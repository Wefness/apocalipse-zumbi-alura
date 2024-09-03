using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using JetBrains.Rider.Unity.Editor;

public class ControlaJogador : MonoBehaviour {
    public int velocidade = 10;
    public LayerMask mascaraChao;
    public GameObject textoGameOver;
    public bool vivo = true;
    private Vector3 direcao;
    private Animator animatorJogador;
    private Rigidbody rigidbodyJogador;

    void Start()
    {
        Time.timeScale = 1;
        animatorJogador = GetComponent<Animator>();
        rigidbodyJogador = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        
        direcao = new Vector3(eixoX, 0, eixoZ);

        if(direcao != Vector3.zero) {
            animatorJogador.SetBool("Movendo", true);
        } else {
            animatorJogador.SetBool("Movendo", false);
        }

        if(vivo == false) {
            if(Input.GetButtonDown("Fire1")) {
                SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;
        Vector3 posicaoMiraJogador;
        Quaternion novaRotacao;

        rigidbodyJogador.MovePosition(
            rigidbodyJogador.position +
            (direcao * velocidade * Time.deltaTime)
        );

        if(Physics.Raycast(raio, out impacto, 100, mascaraChao)) {
            posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;
            novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            rigidbodyJogador.MoveRotation(novaRotacao);
        }

        Debug.DrawRay(raio.origin, (raio.direction * 100), Color.red);
    }
}
