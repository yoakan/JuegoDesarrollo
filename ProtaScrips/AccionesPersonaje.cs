using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionesPersonaje : MonoBehaviour
{
    
    public ProtaScript prota;
    public GameObject bala;
    public GameObject balaCargarda;
    public GameObject escudo;
    public Animator animacion;
    public AudioClip[] sonidosHabilidades;
    public float alturaDisparo,tiempoAnterior=0;
    private ArrayList movimientos = new ArrayList();
    private bool activado,disparando=false;
    private int tiempoSalidaRecarga, coldownEscudo = 0, cambiarHabilidad, habilidadSeleccionada = 0;
    // Start is called before the first frame update
    void Start()
    {
        tiempoSalidaRecarga = -1;
        cargarHabilidades();
        
    }

    private void cargarHabilidades()
    {
        
        prota.puedeDisparar = true;
        prota.puedeDispararCargado = true;
        /*
        prota.puedeAgacharse = true;
        
        prota.puedeUsarElEscudo = true;*/
        if (prota.puedeDisparar)
        {
            movimientos.Add("disparar");
        }
        if (prota.puedeAgacharse)
        {
            movimientos.Add("agacharse");
        }
        
        if (prota.puedeUsarElEscudo)
        {
            movimientos.Add("escudo");
        }
        if (prota.puedeDispararCargado)
        {
            movimientos.Add("dispararCargado");
        }



    }

    // Update is called once per frame
    void Update()
    {
        habilidades();
    }
    private void habilidades()
    {
        /*
         * USADAS:R
         * disparar E
         * DisparoCargado:q
         * Escudo: F
         */
        agarchar();
        disparar();
        disparoCargado();
        sacarEscudo();
        animarAcciones();
    }

    private void animarAcciones()
    {
        animacion.SetBool("estaDisparando",disparando);
    }

    private bool estaDisparando()
    {
        bool sigueDisparando = false;
        if (disparando )
        {
            sigueDisparando = true;
            tiempoAnterior = Time.time;
        }
        else{
            print("HOLA NO DISPARO!!!");
            if (tiempoAnterior!=0 && Time.time-tiempoAnterior>=2)
            {
                tiempoAnterior = 0;
                sigueDisparando = false;
            }
            else
            {
                sigueDisparando = true;
            }
        }
        return sigueDisparando;

    }

    private void sacarEscudo()
    {
        int tiempoActual = System.DateTime.Now.Second;

        if (coldownEscudo > tiempoActual)
        {
            tiempoActual = tiempoActual + 60;
        }
        if (tiempoActual - coldownEscudo >= 3)
        {
            if (Input.GetKeyUp(KeyCode.F) || activado==true  && (string)movimientos[habilidadSeleccionada] == "escudo")
            {
                float posicionBala = 1.5f;
                //escudo.GetComponent<EscudoScript>().direccion = miraDerecha;
                
                if (!prota.miraDerecha)
                {
                    posicionBala = posicionBala * (-1);
                }
                GameObject.Instantiate(escudo, new Vector3(transform.position.x + posicionBala, transform.position.y), transform.rotation);
                coldownEscudo = System.DateTime.Now.Second;

            }
        }


    }

    private void disparoCargado()
    {
        int tiempoCarga = 0;
        if (tiempoSalidaRecarga == -1 )
        {
            if(Input.GetKeyUp(KeyCode.Q) || activado == true && (string)movimientos[habilidadSeleccionada] == "dispararCargado")
            {
                tiempoSalidaRecarga = System.DateTime.Now.Second;
                
            }
            
            
            
        }
        if (tiempoSalidaRecarga > System.DateTime.Now.Second)
        {
            tiempoCarga = 60 + System.DateTime.Now.Second;
        }
        else
        {
            tiempoCarga = System.DateTime.Now.Second;
        }
        
        if (tiempoCarga - tiempoSalidaRecarga > 3)
        {
            if(Input.GetKeyUp(KeyCode.Q) || activado == true && (string)movimientos[habilidadSeleccionada] == "dispararCargado"){
               
                float posicionBala = 1.5f;
                balaCargarda.GetComponent<BalaGorda>().direccion = prota.miraDerecha;
                if (!prota.miraDerecha)
                {
                    posicionBala = posicionBala * (-1);
                }
                GameObject.Instantiate(balaCargarda, new Vector3(transform.position.x + posicionBala, transform.position.y), transform.rotation);
                activado = false;
                tiempoSalidaRecarga = -1;
            }
            
        }
    }
    
    private void disparar()
    {
        if (Input.GetKeyUp(KeyCode.E) || activado == true && (string)movimientos[habilidadSeleccionada] == "disparar")
        {
            float posicionBala = 1;
            bala.GetComponent<BalaScript>().direccion = prota.miraDerecha;
            if (!prota.miraDerecha)
            {
                posicionBala = posicionBala * (-1);
            }
            GameObject.Instantiate(bala, new Vector3(transform.position.x + posicionBala, transform.position.y+alturaDisparo), transform.rotation);
            activado = false;
            disparando = true;
            //sonidosHabilidades[0]
            GetComponent<AudioSource>().clip=sonidosHabilidades[0];
            GetComponent<AudioSource>().Play();

        }
        else
        {
            disparando = false;
        }
    }

    private void agarchar()
    {
        if (prota.puedeAgacharse)
        {
            if (Input.GetKeyDown(KeyCode.R)||activado == true && (string)movimientos[habilidadSeleccionada] == "agacharse")
            {

                prota.GetComponent<BoxCollider2D>().size = new Vector2(prota.GetComponent<BoxCollider2D>().size.x, prota.GetComponent<BoxCollider2D>().size.y / 2);
            }

            else/*if (Input.GetKeyUp(KeyCode.R))*/
            {
              
                prota.GetComponent<BoxCollider2D>().size = new Vector2(prota.GetComponent<BoxCollider2D>().size.x, prota.GetComponent<BoxCollider2D>().size.y);
            }
        }

    }

    public void pulzarBotonAccion(bool activar)
    {
        cambiarHabilidad=  System.DateTime.Now.Second;
        activado = activar;
        /*for(int i =0; i < 1000; i++)
        {

        }
        activado = false;*/
    }
    public void siguienteHabilidad()
    {
        /*  Como que esta parte la he hecho ahora xD. Parece el meme del perro mamado y el lloron
         */
        habilidadSeleccionada++;
        if (habilidadSeleccionada >= movimientos.Count)
        {
            habilidadSeleccionada = 0;
        }

    }
    public void anteriorHabilidad()
    {
        
        habilidadSeleccionada--;
        if (habilidadSeleccionada < 0)
        {
            habilidadSeleccionada = movimientos.Count - 1;
        }
    }
    public void SoltarBoton(bool activar)
    {
        int tiempoCarga;
        if (cambiarHabilidad > System.DateTime.Now.Second)
        {
            tiempoCarga = 60 + System.DateTime.Now.Second;
        }
        else
        {
            tiempoCarga = System.DateTime.Now.Second;
        }
        
        if (tiempoCarga - cambiarHabilidad > 4)
        {
            if (movimientos.Count > 0)
            {
                habilidadSeleccionada++;
                if (habilidadSeleccionada == movimientos.Count)
                {
                    habilidadSeleccionada = 0;
                }
                
                
            }


        }
            activado = activar;
        
        
            
        
    }

}
