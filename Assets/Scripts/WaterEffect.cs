using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WaterEffect : MonoBehaviour
{
    
    Volume efecto;
    [SerializeField] float velocidad;

    void Start()
    {
      efecto = GetComponent<Volume>();    
    }

    void Update()
    {
      
    }
}
