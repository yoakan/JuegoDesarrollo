using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controles : MonoBehaviour
{
    public GameObject ajustesSetting;
    public Slider slider;
    private float puntoInicio, puntoCambiado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void mostrarAjuste()
    {
        ajustesSetting.SetActive(true);
        gameObject.SetActive(false);
    }

    public void cambiarArma()
    {
        //Fruit ninja!!
        if (puntoInicio != -1)
        {
            puntoCambiado = slider.value-puntoInicio;
           
        }
        
    }

   
    public void inicioPulsoSlider()
    {
        puntoInicio = slider.value;
        
    }
    public void finalPulsoSlider()
    {
        
        
        if (puntoCambiado >= 20)
        {

            FindObjectOfType<AccionesPersonaje>().anteriorHabilidad();
        }
        if (puntoCambiado <= -20)
        {


            FindObjectOfType<AccionesPersonaje>().siguienteHabilidad();
        }
        puntoCambiado = 0;
        puntoInicio = -1;
    }
}
