using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel_Rotation : MonoBehaviour
{
    public Animator anim = null;
    public float speed = 1.0f;

    public bool reversed = false;

    Rigidbody player;

    private void Start()
    {
        player = FindObjectOfType<MovementControl>().gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Debug.Log(player.velocity.magnitude);
        speed = player.velocity.magnitude/8f;

        if (Input.GetAxis("Vertical") < 0)
        {
            reversed = false;
        }
        else
        {
            reversed = true;
        }


        anim.speed = speed;
        anim.SetBool("Forward", !reversed);
    }
}
