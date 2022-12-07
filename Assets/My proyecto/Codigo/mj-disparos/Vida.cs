using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    //jugador como enemigos tienen este script
    [SerializeField] 
    private float VidaActual =100;

    //si se causa daño se le resta ese valor a la vida del enemigo
    //y si lo destruye se suma uno a la puntuacion del jugador 
    public void CausarDaño(float cuanto)
    {
        VidaActual -= cuanto;
        if(VidaActual<=0)
        {
            Destroy(gameObject);
            Dpersonaje.cuenta++;
        }
    }
}
