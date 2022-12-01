using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI contador;
    private float tiempo = 50f;
    public TextMeshProUGUI lose;
    public TextMeshProUGUI win;
    public Image panel1;
    public Image panel2;
    public Button botonGanar;
    public Button botonSalir;

    // Use this for initialization
    void Start()
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
        tiempo -= Time.deltaTime;
        contador.text = " " + tiempo.ToString("f0");

        if (tiempo <= 0)
        {
            contador.text = "0";
            panel1.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            lose.gameObject.SetActive(true);
            botonSalir.gameObject.SetActive(true);

        }

    }
}
