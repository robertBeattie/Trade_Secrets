using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    public ColorMap mapping;
    public SpriteRenderer GFX;
    private Vector3 moveDirection = Vector3.zero;
    public Color color;
    public Interactable nearbyInteractable;
    public bool hasKey;
    public bool dead;
    public GameObject deathX;
    public GameObject restartUI;
    public GameObject caught;

    void Start()
    {
        restartUI.SetActive(false);
        hasKey = false;
        dead = false;

        controller = GetComponent<CharacterController>();

        mapping = new ColorMap();
        mapping.SetColorMap(ColorMap.ColorMapping.White);
    }

    void Update()
    {
        // Color
        GFX.color = mapping.color;
        color = mapping.color;

        // Movement
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (dead)
        {
            deathX.SetActive(true);
            speed = 0;
            if (nearbyInteractable != null)
            {
                nearbyInteractable.UI.SetActive(false);
                nearbyInteractable = null;
            }
            if (!restartUI.active)
            {
                Instantiate(caught);
            }
            restartUI.SetActive(true);
        }

        if (nearbyInteractable != null)
        {
            // Allow space press to trigger Interactable
            if (Input.GetKeyDown(KeyCode.Space))
            {
                nearbyInteractable.interact();

                if (nearbyInteractable.GetComponent<KeyInteractable>() != null)
                {
                    hasKey = true;
                }
            }
        }
    }

    public void SetColor(ColorMap.ColorMapping color)
    {
        mapping.SetColorMap(color);
    }

    public void setInteractable(Interactable nearbyInteractable)
    {
        this.nearbyInteractable = nearbyInteractable;
    }
}