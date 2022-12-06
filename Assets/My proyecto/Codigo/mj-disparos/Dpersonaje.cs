using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Text txtMuertes;

    [SerializeField] //Mostrar en pantalla las caracteristicas
    private Transform grafico;

    [Header("Disparos")]
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private GameObject bala;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private Transform cañon;

    public static int cuenta = 0;
    public GameObject gameOver;
    

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

        txtMuertes.text = cuenta.ToString("00");

    }

    private void OnDestroy()
    {
       
    }

}
