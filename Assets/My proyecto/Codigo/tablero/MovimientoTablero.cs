using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoTablero : MonoBehaviour
{
    public Waypoint Rott;

    public Image ObjectwithImage;
    public Sprite[] images;
    public int num;


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
            num = Random.Range(0, images.Length);
            ObjectwithImage.sprite = images[num];


            Debug.Log("Dado: " + images[num]);
            if (rpposicion + num < Rott.casilla.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
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
        while (num > -1)
        {
            Vector3 nextPos = Rott.casilla[rpposicion + 0].position;
            while (MoveToNexNode(nextPos)) { yield return null; }
            yield return new WaitForSeconds(0.1f);
            num--;
            rpposicion++;
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
