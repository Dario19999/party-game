using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Transform[] lista;
    public List<Transform> casilla = new List<Transform>();

    // Update is called once per frame
    void Update()
    {
        casilla.Clear();
        lista = GetComponentsInChildren<Transform>();

        foreach (Transform child in lista)
        {

            if (child != this.transform)
            {
                casilla.Add(child);

            }

        }
    }
}