using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingSound : MonoBehaviour {

    AudioSource dingSound;

	// Use this for initialization
	void Start () {
        dingSound = GetComponentInChildren<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        dingSound.pitch = Random.Range(0.8f,1.2f);
        dingSound.Play();
    }

}
