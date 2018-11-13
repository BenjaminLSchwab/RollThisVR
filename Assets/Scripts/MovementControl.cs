using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementControl : MonoBehaviour {

    public bool boostReady;
    float mouseXPosAtClick;
    float mouseYPosAtClick;
    float fadeTimer;
    [SerializeField]
    float fadeTime = 1f;
    bool isFading;
    OVRScreenFade screenFade;

    Rigidbody rb;
    CameraAnchor cameraAnchor;
    Rigidbody anchorRB;
    [SerializeField]ParticleSystem boostIndicator;
    //public bool jumpInput;
    [SerializeField] float m_moveSpeed = 20f;
    [SerializeField] float m_rotSpeed = .5f;
    [SerializeField] float m_boostSpeed = 2300f;
    [SerializeField] float m_sneakSpeed = .3f;
    public float sneakModifier;
    Vector3 flatCameraForward;
    Vector3 flatCameraRight;

	// Use this for initialization
	void Start () {
        screenFade = FindObjectOfType<OVRScreenFade>();
        fadeTimer = fadeTime;
        rb = GetComponent<Rigidbody>();
        cameraAnchor = FindObjectOfType<CameraAnchor>();
        //anchorRB = cameraAnchor.GetComponent<Rigidbody>();
        //boostIndicator = GetComponentInChildren<ParticleSystem>();
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveCamera();
        Roll();
        Boost();
        StopGame();
    }

    void StopGame()
    {

        if (isFading)
        {
            fadeTimer -= Time.deltaTime;
            if (fadeTimer < 0)
            {
                Application.Quit();

            }
        }

        


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isFading)
            {
                screenFade.FadeOut();
            }
            isFading = true;
            fadeTimer = fadeTime;

        }
    }

    void Boost()
    {

        boostIndicator.gameObject.SetActive(boostReady);



        if ((Input.GetAxis("Oculus_GearVR_RIndexTrigger") == 1f)  && boostReady)
        {
            rb.AddForce(flatCameraForward * m_boostSpeed);
            boostReady = false;
        }
    }

    void Roll()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sneakModifier = m_sneakSpeed;
        }
        else
        {
            sneakModifier = 1;
        }

        rb.AddForce(flatCameraForward * Input.GetAxis("Vertical") * m_moveSpeed * sneakModifier * -1);
        rb.AddForce(flatCameraRight * Input.GetAxis("Horizontal") * m_moveSpeed * sneakModifier);
        //anchorRB.AddTorque(Vector3.up * xInput * m_rotSpeed);
        // cameraAnchor.transform.Rotate(Vector3.up * xInput * m_rotSpeed);
        //rb.AddForce(cameraAnchor.transform.right * xInput);


    }

    void MoveCamera()
    {

        if (Input.GetMouseButtonDown(1))
        {
            mouseXPosAtClick = Input.mousePosition.x;
            mouseYPosAtClick = Input.mousePosition.y;

        }


        if (Input.GetMouseButton(1))
        {
            //anchorRB.AddTorque(Vector3.up * (Input.mousePosition.x - mouseXPosAtClick) * m_rotSpeed);
            cameraAnchor.transform.Rotate(Vector3.up * ((Input.mousePosition.x - mouseXPosAtClick)/ Screen.width) * m_rotSpeed);
            cameraAnchor.transform.Rotate(Vector3.right * ((Input.mousePosition.y - mouseYPosAtClick)/ Screen.height) * (m_rotSpeed * -1f));

        }
        else
        {
            mouseXPosAtClick = Input.mousePosition.x;
            mouseYPosAtClick = Input.mousePosition.y;
        }

        cameraAnchor.transform.Rotate(Vector3.up * (Input.GetAxis("RightStickX")) * m_rotSpeed);
        //cameraAnchor.transform.Rotate(Vector3.right * (Input.GetAxis("RightStickY")) * (m_rotSpeed * -1f));

        flatCameraForward = cameraAnchor.transform.forward;
        flatCameraForward.y = 0;
        flatCameraRight = cameraAnchor.transform.right;
        flatCameraRight.y = 0;
    }
}
