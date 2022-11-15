using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : Interactable
{
    [SerializeField]
    private int _puntos = 1;
    public override void Interact(PlayerController player)
    {
        player.UpdatePuntos(_puntos);
        Destroy(gameObject);
    }
}
