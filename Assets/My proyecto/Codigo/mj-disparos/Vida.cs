using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private float VidaActual =100;

    public void CausarDa�o(float cuanto)
    {
        VidaActual -= cuanto;
        if(VidaActual<=0)
        {
            Destroy(gameObject);
            Dpersonaje.cuenta++;
        }
    }
}
