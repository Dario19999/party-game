using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerador : MonoBehaviour
{
    public GameObject[] generadorOsbtaculos;
    private Vector3 posicionGenerador = new Vector3(25, 0, 0);
    private float tiempoRetraso = 2;
    private float intervaloRepeticion = 2;
    private ControlJugador scriptControlJugador;
    public int _tiempo = 0;
    void Start()
    {
        Invoke("GeneraObstaculo", tiempoRetraso); //Invoca repetidamente
        scriptControlJugador = GameObject.Find("Jugador").GetComponent<ControlJugador>(); //Encuentra el objeto llamdo jugador y dentro del objeto jugaodr, obtiene el componente ControlJugador que es el script
    }

    // Update is called once per frame
    void Update()
    {
        _tiempo = _tiempo + 1;
    }

    void GeneraObstaculo()
    {
        intervaloRepeticion = Random.Range(1.5f, 3); //Le damos un valor aleatorio entre 1.5 y 3 segundos+
        if (!scriptControlJugador.gameOver) //Si el jugador no a muerto entonces;
        {
            if (_tiempo < 900)
            {
                int n = Random.Range(0, generadorOsbtaculos.Length);
                Instantiate(generadorOsbtaculos[n], posicionGenerador, generadorOsbtaculos[n].transform.rotation); //Genera el objeto y su posicion
                Invoke("GeneraObstaculo", intervaloRepeticion); //Va asignar un nuevo valor
            }
        }
    }
}
