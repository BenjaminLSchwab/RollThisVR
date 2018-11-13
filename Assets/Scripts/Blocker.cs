using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{

    enum MotionMode { rising, falling, idleAtBottom, IdleAtTop };

    MotionMode motionMode;

    [SerializeField] Vector3 topPos;
    [SerializeField] Vector3 bottomPos;
    [SerializeField] float interval = 10;
    [SerializeField] float waitTime = 3;
    
    
    float t;
    float idleTime;
    bool rising;


    // Use this for initialization
    void Start()
    {
    }

    private void FixedUpdate()
    {
        Timer();
        transform.position = Vector3.Slerp(bottomPos, topPos, t / interval);
    }

    void Timer()
    {
        switch (motionMode)
        {
            case MotionMode.rising:
                t += Time.deltaTime;
                if (t > interval)
                {
                    motionMode = MotionMode.IdleAtTop;
                }
                break;

            case MotionMode.falling:
                t -= Time.deltaTime;
                if (t < 0)
                {
                    motionMode = MotionMode.idleAtBottom;
                }
                break;

            case MotionMode.idleAtBottom:
                idleTime += Time.deltaTime;
                if (idleTime > waitTime)
                {
                    idleTime = 0;
                    motionMode = MotionMode.rising;
                }

                break;

            case MotionMode.IdleAtTop:
                idleTime += Time.deltaTime;
                if (idleTime > waitTime)
                {
                    idleTime = 0;
                    motionMode = MotionMode.falling;
                }

                break;
        }
        //if (rising)
        //{
        //    t += Time.deltaTime;
        //        if ( t > interval)
        //    {
        //        rising = false;
        //    }
        //}
    }

}
