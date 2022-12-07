using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rbJugador;

    [SerializeField]
    private float fuerzaSalto = 10;
    [SerializeField]
    private float modificadorGravedad = 2;
    [SerializeField]
    private bool estaEnElSuelo = true;
    public bool gameOver; //En automatico es falso

    [SerializeField]
    private Animator animJugador;
    
    [SerializeField]
    private ParticleSystem Explosion;
    [SerializeField]
    private ParticleSystem polvadera;

    [SerializeField]
    private AudioClip sonidoSalto;
    [SerializeField]
    private AudioClip sonidoChoque;
    [SerializeField] 
    private AudioSource sonidoJugador;

    [SerializeField]
    private int _puntaje = 0;
    [SerializeField]
    private TextMeshProUGUI puntuacion;
    [SerializeField] 
    private TextMeshProUGUI lose;
    [SerializeField] 
    private TextMeshProUGUI win;
    [SerializeField] 
    private Image panel;
    [SerializeField] 
    private Image panel2;
    [SerializeField] 
    private Button botonGanar;
    [SerializeField] 
    private Button botonSalir;


    void Start()
    {
        rbJugador = GetComponent<Rigidbody>();
        Physics.gravity *= modificadorGravedad;
        animJugador = GetComponent<Animator>();
        sonidoJugador = GetComponent<AudioSource>();
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        botonGanar.gameObject.SetActive(false);
        botonSalir.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo && !gameOver) //si presiono la tleca y este tocando el suelo y no este muerto
        {
            rbJugador.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse); //Impulsa hacia arriba instantaneameente
            estaEnElSuelo = false; //sirve para que el jugador no salte en el aire cuando presiono la tecla espacio
            animJugador.SetTrigger("Jump_trig"); //Activo el parametro y produce la trasicion
            polvadera.Stop(); //Detener animacion de polvo
            sonidoJugador.PlayOneShot(sonidoSalto, 1.0f); //Se produce el sonido solo una vez
        }
        if(!gameOver) //Mientras el jugador esta vivo
        {
            _puntaje = _puntaje + 1; //incrementa el puntaje uno en uno
            puntuacion.text = "Puntuación: " + _puntaje.ToString(); //Actualiza el text los puntos en vivo
        }
        if(_puntaje == 2000)
        {
            //Debug.Log("Ganaste"); //Desplagiega un mensaje
            gameOver = true;
            polvadera.Stop(); //Detener animacion de polvo
            puntuacion.text = "Puntuación final " + _puntaje;
            panel.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            win.gameObject.SetActive(true);
            botonGanar.gameObject.SetActive(true);
            Scoring.minijuegosGanados += 1;
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) //si el objeto tiene la etiqueta suelo entonces
        {
            estaEnElSuelo = true; //el jugador podra saltar otra vez
            polvadera.Play(); //Activar animacion de polvo
        }
        else if (collision.gameObject.CompareTag("Obstaculo")) //si el objeto tiene la etiqueta obstaculo entonces
        {
            //Debug.Log("Game Over"); //Desplagiega un mensaje
            gameOver = true;
            animJugador.SetBool("Death_b", true); //Activo el parametro y produce la trasicion
            animJugador.SetInteger("DeathType_int", 1); //Activo el parametro y produce la trasicion
            Explosion.Play(); //Reproduce la explosion
            polvadera.Stop(); //Detener animacion de polvo
            sonidoJugador.PlayOneShot(sonidoChoque, 1.0f); //Se produce el sonido solo una vez
            puntuacion.text = "Puntuación final " + _puntaje;
            panel.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            lose.gameObject.SetActive(true);
            botonSalir.gameObject.SetActive(true); 
        }   
    }
}
