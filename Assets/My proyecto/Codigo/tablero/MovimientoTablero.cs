using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoTablero : MonoBehaviour
{
    [SerializeField]
    private Waypoint Rott;
    [SerializeField]
    private Image ObjectwithImage;
    [SerializeField]
    private Sprite[] images;
    [SerializeField]
    private int _num;


    int rpposicion;
    bool movimie;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !movimie)
        {
            _num = Random.Range(0, images.Length);
            ObjectwithImage.sprite = images[_num];


            Debug.Log("Dado: " + images[_num]);
            if (rpposicion + _num < Rott.getCasilla().Count)
            {
                StartCoroutine(Move());
            }
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
            if(rpposicion == 3)
            {
                transform.Rotate(0, 90, 0);
            }
            else if (rpposicion == 10)
            {
                transform.Rotate(0, 90, 0);
            }
            else if (rpposicion == 17)
            {
                transform.Rotate(0, 90, 0);
            }
            else if (rpposicion == 24)
            {
                transform.Rotate(0, 90, 0);
            }
        }
        movimie = false;
    }
    bool MoveToNexNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 20f * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {

    }
}
