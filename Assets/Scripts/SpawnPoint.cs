using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    [SerializeField] GameObject m_spawn;
    [SerializeField] float m_vertOffset = 5f;
    Vector3 m_offset = Vector3.zero;
    Rigidbody rb;
   // Destructable m_dest;

	// Use this for initialization
	void Start () {
        if (m_spawn == null)
        {
            m_spawn = FindObjectOfType<MovementControl>().gameObject;
        }
        //m_dest = m_spawn.GetComponent<Destructable>();
        m_offset.y = m_vertOffset;
        rb = m_spawn.GetComponent<Rigidbody>();
	}

    //Update is called once per frame


    public void Spawn()
    {
        m_spawn.transform.position = transform.position + m_offset;
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
