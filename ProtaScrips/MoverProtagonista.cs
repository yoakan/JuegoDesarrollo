using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverProtagonista:MonoBehaviour
{
    // Start is called before the first frame update
    public ProtaScript prota;
    [HideInInspector]
    public float velocidad,tiempoSalto=0;
    public Animator animacion;
    public AudioClip sonidoSalto;
    private int contadorSaltos;
    
    private float fuerzaSalto;

    private bool estaQuieto = true;
    private bool moverDerecha = false, moverIzquierda = false;
    
    private bool stopDerecha = false , stopIzquierda=false;
    private void Start()
    {
       
        fuerzaSalto =  9.3f;
        velocidad = 9.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        movimiento();
        animaciones();
        limitarVelocidad();
        estaQuieto = true;
    }

    private void limitarVelocidad()
    {
        if (GetComponent<Rigidbody2D>().velocity.y <= -17)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,-20);
        }
    }

    private void animaciones()
    {
        animacion.SetBool("MueveADerecha", prota.miraDerecha);
        animacion.SetBool("estaQuieto", estaQuieto);
        animacion.SetBool("estaSaltando",estaSaltando());
    }

    private bool estaSaltando()
    {
        bool estaSuelo = true;
        if (contadorSaltos ==0)
        {
            estaSuelo = false;
        }
        return estaSuelo;
    }

    private void FixedUpdate()
    {
       
        saltarTeclado();
    }
    public void movimiento()
    {
        pulzarTeclado();
        if ( moverDerecha)
        {
            if (!stopDerecha)
            {
                transform.Translate(new Vector3(velocidad*Time.deltaTime, 0.0f));
                prota.miraDerecha = true;
                estaQuieto = false;
            }


        }
        
        
        if ( moverIzquierda)
        {
            if (!stopIzquierda)
            {
                transform.Translate(new Vector3(-velocidad*Time.deltaTime, 0.0f));
                prota.miraDerecha = false;
                estaQuieto = false;
            }


        }
        
        


    }
    
    private void pulzarTeclado()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moverDerecha = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moverDerecha = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moverIzquierda = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moverIzquierda = false;
        }
    }

    public void moverADerecha(bool entrada)
    {
        moverDerecha = entrada;
    }
    public void moverAIzquierda(bool entrada)
    {
        moverIzquierda = entrada;
    }
    private void saltarTeclado()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            saltar();




        }
    }

    public void saltar()
    {
        
         if (contadorSaltos == 1)
        {
            if (tiempoSalto == 0 || Time.time - tiempoSalto < 0.15f)
            {
                impulsarPlayer();
                print("SALTO SIN CONTADOR");
            }
        }
        else
        {
            
            if (contadorSaltos < prota.limSaltos)
            {

                impulsarPlayer();


                contadorSaltos++;
            }
        }

        
        

    }

    private void impulsarPlayer()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        GetComponent<AudioSource>().clip = sonidoSalto;
        GetComponent<AudioSource>().Play();
        if (stopIzquierda)
        {
            transform.Translate(new Vector3(+0.018f, 0));
        }
        if (stopDerecha)
        {
            transform.Translate(new Vector3(-0.018f, 0));
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private GameObject colSuelo;
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            ContactPoint2D[] contacts = new ContactPoint2D[1];
            collision.GetContacts(contacts);
            
            if (contacts[0].normal.x == 0f)
            {

                stopDerecha = false;
                stopIzquierda = false;
            }
            if (colSuelo == collision.gameObject)
            {
                contadorSaltos++;
                tiempoSalto = Time.time;
                
            }
           
            

        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            ContactPoint2D[] contacts = new ContactPoint2D[1];
            
            collision.GetContacts(contacts);

            
            if (contacts[0].normal.y >0.9f)
            {

                
                contadorSaltos = 0;
                tiempoSalto = 0;
                colSuelo = collision.gameObject;
                
            }
  
            
            
            if (contacts[0].normal.x>=0.5f)
            {
                
                stopIzquierda = true;
                

            }
            else if(contacts[0].normal.x <= -0.5f)
            {
                
                stopDerecha = true;
                transform.Translate(new Vector3(-0.018f, -0.01f));
            }
            


        }
        

    }
}
