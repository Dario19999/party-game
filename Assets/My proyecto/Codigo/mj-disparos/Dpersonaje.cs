using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dpersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private float velocidad;
    private float velRotacion = 90;
    Vector3 movimiento = Vector3.zero;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private Animator animaciones;
    
    

    [SerializeField] //Mostrar en pantalla las caracteristicas
    private Transform grafico;

    [Header("Disparos")]
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private GameObject bala;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private Transform cañon;

    [Header("Graficos")]
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private TextMeshProUGUI Muertes;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    public static int cuenta = 0;
    public TextMeshProUGUI contador;
    public float tiempo = 60f;
    public TextMeshProUGUI lose;
    public TextMeshProUGUI win;
    public Image panel1;
    public Image panel2;
    public Button botonGanar;
    public Button botonSalir;

    private void Start()
    {
        contador.text = " " + tiempo;
        win.gameObject.SetActive(false);
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
        transform.Rotate(0, movimiento.x * velRotacion * Time.deltaTime, 0);
        animaciones.SetBool("caminando", movimiento.magnitude > 0.2f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bala, cañon.position, cañon.rotation);
        }

        Muertes.text = "Puntuación: " + cuenta.ToString("00");

        tiempo -= Time.deltaTime;
        contador.text = " " + tiempo.ToString("f0");

        if (tiempo <= 0 || cuenta >= 15)
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
        if (other.CompareTag("Enemigo"))
        {
            Time.timeScale = 0f;
            panel1.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            lose.gameObject.SetActive(true);
            botonSalir.gameObject.SetActive(true); 
        }
    }
    

}
