using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour
{
    public GameObject jogador;
    private Vector3 distCompensar;

    // Start is called before the first frame update
    void Start()
    {
        distCompensar = transform.position - jogador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jogador.transform.position + distCompensar;
    }
}
