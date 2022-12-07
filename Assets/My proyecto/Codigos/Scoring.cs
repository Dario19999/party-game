using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public static int minijuegosGanados;

    [SerializeField]
    private Image diamante;
    [SerializeField]
    private Image medallaoro;
    [SerializeField]
    private Image medallaplata;
    [SerializeField]
    private Image medallabronce;
    [SerializeField]
    private Image loser;

    void Start()
    {
        diamante.gameObject.SetActive(false);
        medallaoro.gameObject.SetActive(false);
        medallaplata.gameObject.SetActive(false);
        medallabronce.gameObject.SetActive(false);
        loser.gameObject.SetActive(false);
    }

    void Update()
    {
        if (minijuegosGanados == 4)
        {
            Debug.Log("Ganó 4");
            diamante.gameObject.SetActive(true);
        }
        else if (minijuegosGanados == 3)
        {
            Debug.Log("Ganó 3");
            medallaoro.gameObject.SetActive(true);
        }
        else if (minijuegosGanados == 2)
        {
            Debug.Log("Ganó 2");
            medallaplata.gameObject.SetActive(true);
        }
        else if (minijuegosGanados == 1)
        {
            Debug.Log("Ganó 1");
            medallabronce.gameObject.SetActive(true);
        }
        else if (minijuegosGanados == 0)
        {
            Debug.Log("No ganó ningún juego");
            loser.gameObject.SetActive(true);
        }
    }
}
