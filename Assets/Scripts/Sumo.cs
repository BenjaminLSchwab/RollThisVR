using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumo : MonoBehaviour {

    public Vector3 targetDirection;
    public float throttle = 1f;
    [SerializeField] float speed;
    [SerializeField] float delayControl;
    Transform player;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<MovementControl>().transform;
	}
	
	// Update is called once per frame
	void Update () {

        Timer();
        TargetPlayer();
        rb.AddForce(targetDirection * speed * throttle);
	}

    void TargetPlayer()
    {
        targetDirection = (player.position - transform.position);
        targetDirection.y = 0;
        targetDirection = targetDirection.normalized;

    }

    void Timer()
    {
        delayControl -= Time.deltaTime;

        if (delayControl > 0)
        {
            throttle = 0;
        }
        else
        {
            throttle = 1;
        }
    }
}
