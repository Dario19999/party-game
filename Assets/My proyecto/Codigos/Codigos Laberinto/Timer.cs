using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float tiempo = 60f;
    [SerializeField] 
    private TextMeshProUGUI contador;
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

        if (win.gameObject.activeSelf)
        {
            Time.timeScale = 0f;
        }

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
