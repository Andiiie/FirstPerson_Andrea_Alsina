using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParteEnemigo : MonoBehaviour
{
    [SerializeField] private Enemy mainScript;
    [SerializeField] private float multiplicadorDanho;

    public void RecibirDanho(float danhorecibido)
    {
        mainScript.Vidas -= (danhorecibido * multiplicadorDanho);
        if (mainScript.Vidas <= 0)
        {
            mainScript.Morir();
        }
    }
    public void Explotar()
    {
        mainScript.Vidas -= 101;
        mainScript.GetComponent<Animator>().enabled = false;
        mainScript.GetComponent<NavMeshAgent>().enabled = false;
        mainScript.enabled = false;
    }
}
