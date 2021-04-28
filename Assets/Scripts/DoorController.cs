using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Interactable
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        interacted = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (interacted)
        {
            player.GetComponent<PlayerController>().hasKey = false;
            UI.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            if (player.GetComponent<PlayerController>().hasKey)
            {
                UI.SetActive(true);
                player.GetComponent<PlayerController>().setInteractable(this);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(false);
            other.GetComponent<PlayerController>().setInteractable(null);
        }
    }
}
