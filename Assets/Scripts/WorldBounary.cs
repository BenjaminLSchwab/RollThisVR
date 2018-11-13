using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBounary : MonoBehaviour {

    SpawnPoint spawnPoint;
    //[SerializeField]
    OVRScreenFade screenFade;
    float timer;
    [SerializeField]
    float time = 1f;
    bool isFading = false;

    private void Start()
    {
        timer = time;
        spawnPoint = FindObjectOfType<SpawnPoint>();
        screenFade = FindObjectOfType<OVRScreenFade>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MovementControl>())
        {

            if (!isFading)
            {
            screenFade.FadeOut();

            }



            isFading = true;
        
        //spawnPoint.Spawn();
        }
    }

    private void Update()
    {

        if (isFading)
        {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            spawnPoint.Spawn();
                timer = time;
                isFading = false;
                screenFade.SetFadeLevel(0f);
        }

        }


    }

}
