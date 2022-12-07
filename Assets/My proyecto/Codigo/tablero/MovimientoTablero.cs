using System.Collections;
using UnityEngine;

public class MovimientoTablero : MonoBehaviour
{
    [SerializeField]
    private Waypoint Rott;
    private int _num;
    private ScenaController escenaLoader = new ScenaController();

    private int rpposicion;
    private bool movimie;
    private int mj_1_jugado = 0;
    private int mj_2_jugado = 0;
    private int mj_3_jugado = 0;
    private int mj_4_jugado = 0;

    private void Awake()
    {
        loadMGState();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(mj_1_jugado);
        Debug.Log(mj_2_jugado);
        Debug.Log(mj_3_jugado);
        Debug.Log(mj_4_jugado);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !movimie)
        {
            _num = 0;
            if (rpposicion < Rott.getCasilla().Count)
            {
                 
                StartCoroutine(Move());
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerPrefs.SetInt("mj_1_state", 1);
            PlayerPrefs.SetInt("mj_2_state", 1);
            PlayerPrefs.SetInt("mj_3_state", 0);
            PlayerPrefs.SetInt("mj_4_state", 0);
            Debug.Log("backspace");
        }
    }

    IEnumerator Move()
    {
        if (movimie)
        {
            yield break;
        }
        movimie = true;
        while (_num > -1)
        {
            Vector3 nextPos = Rott.getCasilla()[rpposicion].position;
            while (MoveToNexNode(nextPos)) { yield return null; }
            yield return new WaitForSeconds(0.1f);
            _num--;
            rpposicion++;
        }
        movimie = false;
    }
    bool MoveToNexNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 20f * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("mj_1"))
        {
            if(mj_1_jugado != 1)
            {
                mj_1_jugado = 1;
                saveMGState("mj_1_state", mj_1_jugado);
                escenaLoader.LoadInstruccionesObstaculos();
            }
        }
        if (collision.gameObject.CompareTag("mj_2"))
        {
            if (mj_2_jugado != 1)
            {
                mj_2_jugado = 1;
                saveMGState("mj_2_state", mj_2_jugado);
                escenaLoader.LoadInstruccionesLaberinto();
            }
        }
        if (collision.gameObject.CompareTag("mj_3"))
        {
            if (mj_3_jugado != 1)
            {
                mj_3_jugado = 1;
                saveMGState("mj_3_state", mj_3_jugado);
                escenaLoader.LoadInstruccionesDisparador();
            }
        }
        if (collision.gameObject.CompareTag("mj_4"))
        {
            if (mj_4_jugado != 1)
            {
                mj_4_jugado = 1;
                saveMGState("mj_4_state", mj_4_jugado);
                escenaLoader.LoadInstruccionesPong();
            }
        }
    }

    void saveMGState(string name, int mg)
    {
        PlayerPrefs.SetInt(name, mg);
    }

    void loadMGState()
    {
        mj_1_jugado = PlayerPrefs.GetInt("mj_1_state");
        mj_2_jugado = PlayerPrefs.GetInt("mj_2_state");
        mj_3_jugado = PlayerPrefs.GetInt("mj_3_state");
        mj_4_jugado = PlayerPrefs.GetInt("mj_4_state");
    }
    void OnTriggerEnter(Collider other)
    {

    }
}
