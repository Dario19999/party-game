using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class NPCLaberinto : Interactable //Hereda
{

    public TextMeshProUGUI lose;
    public TextMeshProUGUI win;
    public Image panel1;
    public Image panel2;
    public Button botonGanar;
    public Button botonSalir;

    private void Start()
    {
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