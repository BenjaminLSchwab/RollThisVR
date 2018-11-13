using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedPlatformButton : MonoBehaviour {

    [SerializeField] float time;
    [SerializeField] GameObject platform;
    float timer;
    [SerializeField]Slider indicator;
    bool platformActive;
    [SerializeField]AudioSource tickTock;
    [SerializeField]AudioSource buzz;
    bool hasBuzzed;


    // Use this for initialization
    void Start () {
        //indicator = GetComponentInChildren<Slider>();
        
	}
	
	// Update is called once per frame
	void Update () {
        Sounds();
        Timer();
        indicator.value = timer / time;
        platform.SetActive(platformActive);
        indicator.gameObject.SetActive(platformActive);
	}

    void Sounds()
    {
        if (!platformActive) tickTock.mute = true;

        else tickTock.mute = false;

        if (timer < 0 && !hasBuzzed)
        {
            buzz.Play();
            hasBuzzed = true;
        }
    }

    void Timer()
    {
        if (!platformActive)
        {
            return;
        }
        tickTock.mute = false;
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            platformActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = time;
        platformActive = true;
        hasBuzzed = false;
    }
}
