using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool interacted;
    public GameObject lightToMove;
    public SpriteRenderer GFX;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!interacted)
        {
            lightToMove.GetComponent<LightController>().StopPathing();
            GFX.color = Color.red;
        } else
        {
            lightToMove.GetComponent<LightController>().ResumePathing();
            GFX.color = Color.green;
        }
    }

    public void interact()
    {
        interacted = !interacted;
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
