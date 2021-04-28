using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : Interactable
{

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
            Destroy(this.gameObject);
            UI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(true);
            other.GetComponent<PlayerController>().setInteractable(this);
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
