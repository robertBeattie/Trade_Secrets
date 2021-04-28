using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music instance = null;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            if (SceneManager.GetActiveScene().name == "Start Menu")
            {
                this.GetComponent<AudioSource>().mute = true;
            }
        }
    }
    private void Update()
    {
        this.GetComponent<AudioSource>().mute = false;
    }
}