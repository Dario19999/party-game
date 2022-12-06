using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private Transform objetivo;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private NavMeshAgent agente;


    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        if (g == null)
        {
            Destroy(gameObject);
        }
        else
        {
            objetivo = g.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(objetivo == null)
        {
            return;
        }
        agente.SetDestination(objetivo.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            Destroy(other.gameObject);

        }
    }

}
