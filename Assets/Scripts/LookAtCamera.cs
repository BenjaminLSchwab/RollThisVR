using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    [SerializeField] Transform m_camera;
    [SerializeField] bool m_distanceCheck;
    [SerializeField] float m_distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (m_distanceCheck)
        {
            if (m_camera == null)
            {
                Debug.LogWarning("Bilboard Target is null.");
                return;
            }

            if ((transform.position - m_camera.position).magnitude > m_distance)
            {
                return;
            }


        }
        transform.LookAt(m_camera);
	}
}
