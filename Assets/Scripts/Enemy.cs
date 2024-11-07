using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    float vidas;
    private NavMeshAgent agent;
    private Player player;
    private Animator anim;
    private bool ventanaAtck;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask WhoIsDying;




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindObjectOfType<Player>();
    }

    void Update()
    {
        Perseguir();
        if (ventanaAtck)
        {
            DetectarJugador();
        }
    }

    private void DetectarJugador()
    {
        Collider[] collisDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, WhoIsDying);
    }

    private void Perseguir()
    {
        //Tengo que definir como destino la POSICIÓN DEL PLAYER
        agent.SetDestination(player.transform.position);

        //Si la distanciaque nos queda hacia el objeto cae por debajo del stoppingDistance
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            //Me paro ante él 
            agent.isStopped = true;
            anim.SetBool("attacking", true);
        }
    }

    public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;

        if (vidas <= 0)
        {
            //Destroy this.gameObject

        }
         
    }

    #region Eventos de animación 
    private void FinAtaque()
    {
        //Cuando termine de atacar, vuelvo a moverme
        agent.isStopped = false;
        anim.SetBool("attacking", false);
    }
    private void AbrirVentana()
    {
        ventanaAtck = true;
    }
    private void CerrarVentana()
    {
        ventanaAtck = false;
    }
    #endregion

}
