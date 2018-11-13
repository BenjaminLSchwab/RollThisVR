using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {



    public void LoadLevel(string name)
    {
        Debug.Log("Loading: " + name);
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        //Debug.Log("Quit Requested");
        Application.Quit();
    }

}
