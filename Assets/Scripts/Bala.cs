using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidade;
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position + (
                transform.forward * velocidade * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Inimigo") {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
        //Destroy(gameObject, 5);
    }
}
