using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirFondo : MonoBehaviour
{
    private Vector3 posInicio;
    private float anchoRepeticion;
    void Start()
    {
        posInicio = transform.position; //almacenamos el inicio del fondo
        anchoRepeticion = GetComponent<BoxCollider>().size.x /2; //almacena el valor de la mitad del fondo
    }

    void Update()
    {
        if (transform.position.x < posInicio.x - anchoRepeticion) //si el fondo en x es menor a 50 del inicial entonces;
        {
            transform.position = posInicio; //se regresa a la posicion inicial
        }
    }
}
