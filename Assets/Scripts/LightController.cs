using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightController : MonoBehaviour
{
    public ColorMap mapping;
    public ColorMap.ColorMapping color = ColorMap.ColorMapping.White;
    public ColorMap.ColorMapping mixedColor;

    private GameObject player;
    private bool onPlayer = false;

    // Path finding
    private NavMeshAgent agent;
    public GameObject[] path;
    private int pathIndex = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        mapping = new ColorMap();
        mapping.SetColorMap(color);
        GetComponentInChildren<Light>().color = mapping.color;
        mixedColor = color;

        InvokeRepeating("ChangePlayerColors", 0.0f, 0.2f);

        agent = GetComponent<NavMeshAgent>();
        if (path.Length > 0)
        {
            agent.SetDestination(path[pathIndex].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path.Length > 0)
        {
            Pathfinding();
        }
    }

    void ChangePlayerColors()
    {
        if (onPlayer)
        {
            if (mixedColor != color)
            {
                player.GetComponent<PlayerController>().SetColor(mixedColor);
            }
            else
            {
                player.GetComponent<PlayerController>().SetColor(color);
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            //Debug.Log("yo its another light");
            mixedColor = mapping.CombineColors(mapping.color, collision.gameObject.GetComponent<LightController>().mapping.color);
        }
        else if (collision.gameObject.tag == "Player")
        {
            onPlayer = true;
            //Debug.Log("yo its a player");
            
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            //Debug.Log("bye light");
            mixedColor = color;
        }
        else if (collision.gameObject.tag == "Player")
        {
            onPlayer = false;

        }
    }

    private void Pathfinding()
    {
        if (Vector3.Distance(transform.position, path[pathIndex].transform.position) <= agent.stoppingDistance + .5f)
        {
            pathIndex++;
            if (pathIndex >= path.Length)
            {
                pathIndex = 0;
            }
            agent.SetDestination(path[pathIndex].transform.position);
        }
    }

    public void StopPathing()
    {
        agent.Stop();
    }

    public void ResumePathing()
    {
        agent.Resume();
    }
}
