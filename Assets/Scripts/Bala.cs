using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidade;
    private Rigidbody rigidbodyBala;

    void Start() {
        rigidbodyBala = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rigidbodyBala.MovePosition(
            rigidbodyBala.position +
            (transform.forward * velocidade * Time.deltaTime)
        );
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Inimigo") {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
