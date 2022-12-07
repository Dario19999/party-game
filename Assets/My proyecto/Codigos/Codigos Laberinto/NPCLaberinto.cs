using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class NPCLaberinto : Interactable //Hereda
{
    [SerializeField]
    private TextMeshProUGUI lose;
    [SerializeField]
    private TextMeshProUGUI win;
    [SerializeField]
    private Image panel1;
    [SerializeField]
    private Image panel2;
    [SerializeField]
    private Button botonGanar;
    [SerializeField]
    private Button botonSalir;
    private AudioSource sonidojuego;

    private void Start()
    {
        sonidojuego = GetComponent<AudioSource>();  //obtiene el componente audio
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        panel1.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        botonGanar.gameObject.SetActive(false);
        botonSalir.gameObject.SetActive(false);
    }

    public override void Interact(PlayerController player)
    {
        //Debug.Log("Interactuando con el NPC");
        panel1.gameObject.SetActive(true);
        panel2.gameObject.SetActive(true);
        win.gameObject.SetActive(true);
        botonGanar.gameObject.SetActive(true);

    }


}