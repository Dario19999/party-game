using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private Transform[] lista;
    [SerializeField]
    private List<Transform> casilla = new List<Transform>();

    public List<Transform> getCasilla()
    {
        return casilla;
    }
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