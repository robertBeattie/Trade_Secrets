using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    //player Reference
    GameObject player;
    //Pathing
    NavMeshAgent agent;
    public GameObject[] path;
    private int pathIndex = 0;
    //Color Stuff
    public ColorMap colorMap;
    public ColorMap.ColorMapping color = ColorMap.ColorMapping.White;
    //Sprite
    SpriteRenderer enemy_GFX;
    // Start is called before the first frame update
    void Start()
    {
        //player Reference
        player = GameObject.FindGameObjectWithTag("Player");
        //pathing
        agent = GetComponent<NavMeshAgent>();
        //setting color
        colorMap = new ColorMap();
        colorMap.SetColorMap(color);
        //setting sprite color
        enemy_GFX = GetComponentInChildren<SpriteRenderer>();
        enemy_GFX.color = colorMap.color;
        if (path.Length > 0)
        {
            agent.SetDestination(path[pathIndex].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //look for player
        Vision();
        //movement
        if (path.Length > 0)
        {
            Pathfinding();
        }
       
    }

    private void Vision()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 30f))
        {
            if(hit.collider.gameObject == player && player.GetComponent<PlayerController>().mapping.color != colorMap.color)
            {
                Debug.Log("Hit See Player");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);

                hit.collider.gameObject.GetComponent<PlayerController>().dead = true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
        }
    }
    private void Pathfinding()
    {
        if (Vector3.Distance(transform.position, path[pathIndex].transform.position)<= agent.stoppingDistance + .1f)
        {
            pathIndex++;
            if(pathIndex >= path.Length) {
                pathIndex = 0;
            }
            agent.SetDestination(path[pathIndex].transform.position);
        }
    }

}
