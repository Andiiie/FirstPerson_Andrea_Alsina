using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    FirstPerson player;
    Animator anim;
    bool ventanaAbierta = false;
    [SerializeField] Transform Attackpoint;
    [SerializeField] float RadioAtaque = 1f;
    [SerializeField] LayerMask queEsDanable;
    [SerializeField] int danhoAtaque = 25;
    bool danhoRealizado = false;
    [SerializeField] private float vidas;
    Rigidbody[] huesos;
    static int zombiesMorir;
    bool matar1=true;

    public float Vidas { get => vidas; set => vidas = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FirstPerson>();
        anim = GetComponent<Animator>();
        huesos = GetComponentsInChildren<Rigidbody>();

        CambiarEstadoHuesos(true);

    }

    // Update is called once per frame
    void Update()
    {
        perseguir();
        if (ventanaAbierta && !danhoRealizado)
        {
            DetectarJugador();
        }

    }
    public void Morir()
    {
        // gameobject=set active;;; componentes = enabled bool
        
        Debug.Log(zombiesMorir);
        if (matar1 == true)
        {
            zombiesMorir++;
            matar1 = false;
        }
        if (zombiesMorir >= 15)
        {
            SceneManager.LoadScene(3);

        }
        agent.enabled = false;
        anim.enabled = false;
        CambiarEstadoHuesos(false);
        Destroy(gameObject, 10);

    }

    private void CambiarEstadoHuesos(bool Estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = Estado;


        }
    }

    private void DetectarJugador()
    {
        Collider[] colliderDetectados = Physics.OverlapSphere(Attackpoint.position, RadioAtaque, queEsDanable);
        // si al menos hemos detectado 1 colider...
        if (colliderDetectados.Length > 0)
        {
            for (int i = 0; i < colliderDetectados.Length; i++)
            {
                colliderDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoAtaque);

            }
            danhoRealizado = true;
        }
    }

    //funciona con evento de animacion
    private void perseguir()
    {
        //Tengo que definir como destino la posicion del player
        agent.SetDestination(player.transform.position);

        //Si no hay calculos Pendientes para saber donde esta mi objetivo
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            //me paro
            agent.isStopped = true;
            //activar la animacion de ataque
            anim.SetBool("attacking", true);
            EnfocarPlayer();
        }
    }

    private void EnfocarPlayer()
    {
        //calculo al vector que enfoque al jugador
        Vector3 direccionAPlayer = (player.transform.position - transform.position).normalized;
        //me aseguro que no vuelque el enemigo al player
        direccionAPlayer.y = 0;
        //calcula la rotacion a la que me tengo que girar para orientarme en esa direccion
        transform.rotation = Quaternion.LookRotation(direccionAPlayer);
    }

    public void FinAtaque()
    {
        //cuando termino animacion me muevo
        anim.SetBool("attacking", false);
        agent.isStopped = false;
        danhoRealizado = false;
    }
    public void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    }
    public void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
    }
    public void AtaqueAlPlayer(int danhoAtaque)
    {

    }

    public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
        
        
        if (vidas <= 0)
        {

            Destroy(this.gameObject);
        }

    }

}

