using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class ControlaJogador : MonoBehaviour {
    public int velocidade = 10;
    public LayerMask mascaraChao;
    public GameObject textoGameOver;
    public bool vivo = true;
    Vector3 direcao;

    void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        
        direcao = new Vector3(eixoX, 0, eixoZ);

        if(direcao != Vector3.zero) {
            GetComponent<Animator>().SetBool("Movendo", true);
        } else {
            GetComponent<Animator>().SetBool("Movendo", false);
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

        GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position + (
                direcao * velocidade * Time.deltaTime));

        if(Physics.Raycast(raio, out impacto, 100, mascaraChao)) {
            posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;
            novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }

        Debug.DrawRay(raio.origin, raio.direction*100, Color.red);
    }
}
