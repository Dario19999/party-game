using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wazowski : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody rb;

    public float speed;

    [SerializeField]
    private int jugador1Score;
    [SerializeField]
    private int jugador2Score;


    public Vector3 spawnPoint;

    [SerializeField]
    private TextMeshProUGUI Jugador1Text;
    [SerializeField]
    private TextMeshProUGUI Jugador2Text;

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

    // Start is called before the first frame update
    void Start()
    {
        jugador1Score = 0;
        jugador2Score = 0;

        this.rb = GetComponent<Rigidbody>();
        this.direction = new Vector3(1f, 0f, 1f);

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
        this.transform.position += direction * speed * Time.deltaTime;
        Jugador1Text.text = jugador1Score.ToString();
        Jugador2Text.text = jugador2Score.ToString();

        if (jugador1Score == 3)
        {
            Time.timeScale = 0f;
            panel.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            win.gameObject.SetActive(true);
            botonGanar.gameObject.SetActive(true);
        }
        if (jugador2Score == 3)
        {
           Time.timeScale = 0f;
            panel.gameObject.SetActive(true);
            panel2.gameObject.SetActive(true);
            lose.gameObject.SetActive(true);
            botonSalir.gameObject.SetActive(true);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        Vector3 normal = col.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);

        if (col.gameObject.name == "Borde2")
        {
            jugador1Score++;
            transform.position = spawnPoint;
        }

        if (col.gameObject.name == "Borde3")
        {
            jugador2Score++;
            transform.position = spawnPoint;
        }
    }
}
