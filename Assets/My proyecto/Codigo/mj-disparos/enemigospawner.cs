using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigospawner : MonoBehaviour
{
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private Vector2 tiempoRandom;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private GameObject prefabEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CrearEnemigo", Random.Range(tiempoRandom.x, tiempoRandom.y)); 
    }

    void CrearEnemigo()
    {
        Instantiate(prefabEnemigo, transform.position, transform.rotation);
        Invoke("CrearEnemigo", Random.Range(tiempoRandom.x, tiempoRandom.y));

    }

}
