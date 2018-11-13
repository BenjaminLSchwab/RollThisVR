using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {

    [SerializeField] float bumpSoundThreshHold = 12;
    [SerializeField] float rollSoundThreshHold = 20;
    [SerializeField]AudioSource bumpSound;
    [SerializeField] AudioSource rollSound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Collision Magnitude : " + collision.relativeVelocity.magnitude.ToString() + "\nCollision Force Sum: " + collision.impulse.ToString());
        if ((collision.relativeVelocity.magnitude < bumpSoundThreshHold))
        {
            return;
        }
        //bumpSound.volume = 1f * ((float)(1/10) * (float)collision.relativeVelocity.magnitude);
        bumpSound.Play();

    }

    private void OnCollisionStay(Collision collision)
    {
        if ((collision.relativeVelocity.magnitude < rollSoundThreshHold))
        {
            rollSound.mute = true;
            return;
        }

        rollSound.mute = false;
    }

}
