using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dproyectil : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private Rigidbody rb;
    [SerializeField] 
    private float VelocidadInicial;
    [SerializeField] 
    private float da�o;

    void Start()
    {
        rb.velocity = VelocidadInicial * transform.forward; // movimiento recto de la bala

        Destroy(gameObject, 4); //destruccion del objecto en 4 seg

    }

    //si colision con un objecto que tiene vida hace da�o
    private void OnTriggerEnter(Collider other)
    {
        Vida v = other.GetComponent<Vida>();
        if (v !=  null && !other.CompareTag("Player"))
        {
            v.CausarDa�o(da�o);
        }
        Destroy(gameObject);
    }


}
