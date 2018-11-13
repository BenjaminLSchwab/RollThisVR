using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinwheel : MonoBehaviour {

    [SerializeField] float speed;
    //float otherSpeed;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        //otherSpeed = speed;
        rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        //otherSpeed += Random.Range(-0.2f,0.2f);
        //transform.Rotate(Vector3.up * speed * otherSpeed);
        rb.AddTorque(Vector3.up * speed);
    }
}
