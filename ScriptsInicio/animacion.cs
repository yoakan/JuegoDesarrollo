using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animacion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] escenas;
    public GameObject fondoNegro;
    public GameObject textStart;
    public GameObject buttonStart;
    public GameObject intertfaz,interfazcesPartidas;
    private int fondoUsado=0 , direccion = 1;
    private bool terminarFondos = false ,estaEnInterfazPartida=false;
    private float intensidadNegro=1, intensidadLetras=0.9f;
    private float tiempo=0,tiempoMax=5,velocidad=0.2f;
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
    }

    // Update is called once per frame
    void Update()
    {
        aniamciones();
    }

    private void aniamciones()
    {
        
        pasarFondoNegroABlanco();
        if (!terminarFondos)
        {
            cambiarFondo();
        }
        else
        {
            if (!estaEnInterfazPartida)
            {
                
                pasarStart();
                cambiarIntensidadLetra();
                textStart.gameObject.SetActive(true);
                
                
            }
            else
            {
                textStart.gameObject.SetActive(false);
                interfazcesPartidas.SetActive(true);
                intertfaz.SetActive(true);
            }
        }
        
    }

    private void cambiarIntensidadLetra()
    {
        
        if (intensidadLetras<0)
        {
            direccion = 1;
        }
        if (intensidadLetras >= 1)
        {
            direccion = -1;
        }
        intensidadLetras = intensidadLetras +Time.deltaTime * 0.5f*direccion;
        
        textStart.GetComponent<Text>().color = new Color(
            textStart.GetComponent<Text>().color.r,
            textStart.GetComponent<Text>().color.g,
            textStart.GetComponent<Text>().color.b,

            intensidadLetras
            );
    }

    private void pasarStart()
    {
        escenas[0].gameObject.SetActive(false);
        escenas[1].gameObject.SetActive(false);
       
    }

    private void cambiarFondo()
    {

        if (Time.time - tiempo >= tiempoMax  )
        {
            if(fondoUsado < 2)
            {
                escenas[fondoUsado].gameObject.SetActive(false);
                
                fondoUsado++;
                tiempo = Time.time;
               
            }
            else
            {
                print("TERMINA EN "+Time.time);
                terminarFondos = true;
            }
            

        }
    }

    private void pasarFondoNegroABlanco()
    {
        intensidadNegro = intensidadNegro - Time.deltaTime * velocidad;
        if (intensidadNegro >= 0)
        {


            fondoNegro.GetComponent<SpriteRenderer>().color = new Color(
            fondoNegro.GetComponent<SpriteRenderer>().color.r,
            fondoNegro.GetComponent<SpriteRenderer>().color.g,
            fondoNegro.GetComponent<SpriteRenderer>().color.b,

            intensidadNegro
            );

        }
    }
    public void  clickPasarImagen()
    {
        if (!terminarFondos)
        {
            terminarFondos = true;
            pasarStart();
        }
        else
        {
            if (!estaEnInterfazPartida)
            {
                estaEnInterfazPartida = true;
                buttonStart.gameObject.SetActive(false);
                pasarAInterface();
                intensidadNegro = 1;
            }
        }
    }
    private void pasarAInterface()
    {
        escenas[2].gameObject.SetActive(false);
    }
}
