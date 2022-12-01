using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wazowski : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    //public float m_Thrust = 20f;

    public Vector3 initialImpulse;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(initialImpulse, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {

        if (Input.GetButton("Jump"))
        {
            m_Rigidbody.AddForce(transform.up * m_Thrust);
        }
    }*/
}
