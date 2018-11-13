using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {

    Rigidbody m_rigidBody;
    [SerializeField] float m_speed = 4000;
    [SerializeField] float m_maxAngle = 3;
    bool direction;
    bool aboveMax;


	// Use this for initialization
	void Start () {
        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.centerOfMass = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float angle = Vector3.Angle(Vector3.up, transform.up);
        Vector3 torque = (transform.forward * m_speed);
        if (direction)
        {
        m_rigidBody.AddTorque(torque);

        }
        else
        {
            m_rigidBody.AddTorque(torque * -1);
        }

        if (angle > m_maxAngle)
        {
            if (!aboveMax)
            {
            direction = (direction) ? false : true;

            }
            
            aboveMax = true;
           

        }
        else
        {
            aboveMax = false;
        }
    }
}
