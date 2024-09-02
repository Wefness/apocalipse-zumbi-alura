using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        Vector3 direcao;
        Quaternion novaRotacao;

        if (distancia > 3) {
            direcao = jogador.transform.position - transform.position;
            novaRotacao = Quaternion.LookRotation(direcao);

            GetComponent<Rigidbody>().MovePosition(
                GetComponent<Rigidbody>().position + (
                    direcao.normalized * velocidade * Time.deltaTime));

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }

    }
}
