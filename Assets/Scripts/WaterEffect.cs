using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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
      // buscar en el profile el efecto LensDistortion

        if (efecto.profile.TryGet(out LensDistortion distortion))
        {
            FloatParameter xValue = new FloatParameter(1 + Mathf.Cos(velocidad * Time.time) / 2);
            FloatParameter yValue = new FloatParameter(1 + Mathf.Sin(velocidad *Time.time) / 2);
            distortion.xMultiplier.SetValue(xValue);
            distortion.yMultiplier.SetValue(yValue);

        }

        
    }
} 

