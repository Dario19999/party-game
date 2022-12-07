using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigospawner : MonoBehaviour
{
    [SerializeField] 
    private Vector2 tiempoRandom;
    [SerializeField] 
    private GameObject prefabEnemigo;

    // Start is called before the first frame update
    //invoca crear enemigo y les tiempos aleatorios para la aparicion
    void Start()
    {
        Invoke("CrearEnemigo", Random.Range(tiempoRandom.x, tiempoRandom.y)); 
    }

    //aparicion del enemigo y de nuevo invocacion
    void CrearEnemigo()
    {
        Instantiate(prefabEnemigo, transform.position, transform.rotation);
        Invoke("CrearEnemigo", Random.Range(tiempoRandom.x, tiempoRandom.y));

    }

}
