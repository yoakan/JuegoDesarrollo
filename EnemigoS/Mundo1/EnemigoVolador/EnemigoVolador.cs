using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVolador : Enemigo
{
    public float distanciaDeteccion;
    public float velocidad;
    public GameObject prota;
    private bool puedeMoverDerecha=true, puedeMoverIzquierda=true;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (distanciaPersonaje()<= distanciaDeteccion)
        {
            
            
            float vuelo = Mathf.Sin(velocidad * transform.position.x * 10) * Time.deltaTime;
            
            
            float moverEnemigo = direccionDeMovimiento() * velocidad * Time.deltaTime;
            if (transform.position.x - prota.transform.position.x > -0.1f && transform.position.x - prota.transform.position.x < 0.1f)
            {
                vuelo =0 ;
                moverEnemigo = 0;
                
            }
            transform.Translate(new Vector3(
                moverEnemigo, 
                vuelo,
                0
                ));

        }
    }
    private int direccionDeMovimiento()
    {
        int direccion = 1;
        if (transform.position.x - prota.transform.position.x > 0)
        {
            direccion = direccion * (-1);
            if (!puedeMoverIzquierda)
            {
                direccion = 0;
            }
        }
        /*
         */
        if (transform.position.x - prota.transform.position.x < 0)
        {
            if (!puedeMoverDerecha)
            {
                direccion = 0;
            }
        }
        return direccion;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            ContactPoint2D[] contacts = new ContactPoint2D[1];

            collision.GetContacts(contacts);
            if (contacts[0].normal.x >= 0.5f  )
            {

                puedeMoverDerecha = false;
            }
            if(contacts[0].normal.x <= -0.5f)
            {
                puedeMoverIzquierda = false;
            }
        }
        recibirDamage(collision.gameObject);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            if (puedeMoverIzquierda == false)
            {
                puedeMoverIzquierda = true;
            }
            if (!puedeMoverDerecha)
            {
                puedeMoverDerecha = true;
            }
        }
    }
    private float distanciaPersonaje()
    {
        float distancia=0;
        
        distancia = Vector2.Distance(prota.transform.position,transform.position);
        
        return distancia;
    }
}
