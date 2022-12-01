using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dproyectil : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private Rigidbody rb;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private float VelocidadInicial;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private float daño;

    void Start()
    {
        rb.velocity = VelocidadInicial * transform.forward;

        Destroy(gameObject, 5);

    }

    private void OnTriggerEnter(Collider other)
    {
        Vida v = other.GetComponent<Vida>();
        if (v !=  null && !other.CompareTag("Player"))
        {
            v.CausarDaño(daño);
        }
        Destroy(gameObject);
    }


}
