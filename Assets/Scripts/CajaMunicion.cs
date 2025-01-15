using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour
{
    [SerializeField] Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    

    public void Abrir()
    {
        anim.SetTrigger("abrir");
    }
  
}
