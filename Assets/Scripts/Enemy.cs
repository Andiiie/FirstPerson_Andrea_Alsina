using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Player player;
    

    void Start()
    {
       agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindObjectOfType<Player>();
    }

    void Update()
    {
        //Tengo que definir como destino la POSICIÓN DEL PLAYER
        agent.SetDestination(player.transform.position);
    }
}
