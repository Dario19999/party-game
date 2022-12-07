using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] 
    private Transform objetivo;
    [SerializeField] 
    private NavMeshAgent agente;


    // Start is called before the first frame update
    //busca enemigo con tag player si no existe se destruye, si existe se vuelve objetivo
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
    //si no tenemos objetivo sale de la funcion, si lo tenemos por medio del agente de 
    //nagevacion lo movemos hacia el objetivo.
    void Update()
    {
        if(objetivo == null)
        {
            return;
        }
        agente.SetDestination(objetivo.position);
    }

}
