using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    ScoreKeeper scoreKeeper;
    [SerializeField] float rotSpeed = 1;
    float timeUntilDestruct = 3;
    AudioSource coinSound;
    bool pickedUp;

	// Use this for initialization
	void Start () {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        coinSound = GetComponentInChildren<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotation = Vector3.forward * rotSpeed;
        transform.Rotate(rotation);
        RiseAfterPickup();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<MovementControl>())
        {
            return;
        }
        if (pickedUp)
        {
            return;
        }
        coinSound.Play();
        scoreKeeper.CoinUp();
        pickedUp = true;
        //this.gameObject.SetActive(false);
    }

    void RiseAfterPickup()
    {
        if (!pickedUp)
        {
            return;
        }
        Vector3 newPos = transform.position;
        newPos.y += (rotSpeed * .05f);
        transform.position = newPos;
        timeUntilDestruct -= Time.deltaTime;
        if (timeUntilDestruct < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
