using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dpersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Jugador")]
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private float velocidad;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private float velRotacion = 90;
    Vector3 movimiento = Vector3.zero;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private Animator animaciones;

    [SerializeField]
    private Transform grafico;

    [Header("Disparos")]
    [SerializeField] 
    private GameObject bala;
    [SerializeField] 
    private Transform cañon;

    [Header("Graficos y Sonido")]
    [SerializeField]
    private AudioClip sonidodisparo;
    private AudioSource sonidojuego;
    [SerializeField] 
    private TextMeshProUGUI Muertes;
    public static int cuenta = 0;
    [SerializeField]
    private TextMeshProUGUI contador;
    [SerializeField]
    private float tiempo = 60f;
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

    private void Start()
    {
        contador.text = " " + tiempo;               //impresion del tiempo en contador
        sonidojuego = GetComponent<AudioSource>();  //obtiene el componente audio
        win.gameObject.SetActive(false);        //desactiva graficos
        lose.gameObject.SetActive(false);
        panel1.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        botonGanar.gameObject.SetActive(false);
        botonSalir.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        movimiento.x = Input.GetAxis("Horizontal");
        movimiento.z = Input.GetAxis("Vertical");   
        transform.Translate(0, 0, movimiento.z * velocidad * Time.deltaTime);
        transform.Rotate(0, movimiento.x * velRotacion * Time.deltaTime, 0); //movimiento
        animaciones.SetBool("caminando", movimiento.magnitude > 0.2f);      //animacion
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bala, cañon.position, cañon.rotation);  //incializacion de la bala
            sonidojuego.PlayOneShot(sonidodisparo, 0.03f);       //sonido al disparar
        }

        Muertes.text = "Puntuación: " + cuenta.ToString("00");  //actualiza puntuacion

        tiempo -= Time.deltaTime;                       //contador de tiempo inverso
        contador.text = " " + tiempo.ToString("f0");    //impresion del contador

        if (tiempo <= 0 || cuenta >= 15)        //forma de ganar
        {
            Time.timeScale = 0f;
            contador.text = "0";
            Muertes.text = "Puntuación Final: " + cuenta.ToString("00");
            panel1.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            win.gameObject.SetActive(true);
            botonGanar.gameObject.SetActive(true);
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))    //forma de perder
        {
            Time.timeScale = 0f;
            panel1.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            lose.gameObject.SetActive(true);
            botonSalir.gameObject.SetActive(true); 
        }
    }
    

}
