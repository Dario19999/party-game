using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverALaIzquierda : MonoBehaviour
{
    private float velocidad = 17;
    private ControlJugador scriptControlJugador;
    private float limiteIzquierdo = -15;
    void Start()
    {
        scriptControlJugador = GameObject.Find("Jugador").GetComponent<ControlJugador>(); //Encuentra el objeto llamdo jugador y dentro del objeto jugaodr, obtiene el componente ControlJugador que es el script
    }

    void Update()
    {
        if (scriptControlJugador.gameOver == false) //Si el jugador no a muerto entonces;
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime); //el puso y el fondo se movera a la izquierda
        }
        if (transform.position.x < limiteIzquierdo && gameObject.CompareTag("Obstaculo")) //Si la posicion del eje equis de mi objeto es menor al limite y tiene la etiqueta Obstaculo entonces
        {
            Destroy(gameObject); //Destruye el objeto
        }
    }
}
