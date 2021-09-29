using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVoladorM2 : Enemigo
{
    // Start is called before the first frame update
    private float fuerzaSaltoX=3, fuerzaSaltoY=10;
    public GameObject prota;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        comprobarSuelo();
        if (transform.rotation.z != 0)
        {
            
            transform.rotation= Quaternion.Euler(0, 0, 0);
        }
    }

    public LayerMask capaSuelo;
    private float ultPosicionSuelo = 0;
    private void comprobarSuelo()
    {
        RaycastHit2D rayCastSuelo = Physics2D.Raycast(transform.position, Vector2.up , 20f, capaSuelo);
        
        if (rayCastSuelo)
        {
            
            ultPosicionSuelo = transform.position.x;
        }
        else
        {
            
            int direccion = 1;
            if (transform.position.x - ultPosicionSuelo < 0)
            {
                direccion = 1;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(direccion * 5, GetComponent<Rigidbody2D>().velocity.y);

        }
       // Debug.DrawRay(transform.position, Vector2.up*20, Color.blue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {

            ContactPoint2D[] contacts = new ContactPoint2D[1];

            collision.GetContacts(contacts);
            if (contacts[0].normal.y < -0.9f)
            {
                int direccion = 1;
                if(prota.transform.position.x - transform.position.x < 0)
                {
                    direccion = -1;
                }
                if(Vector2.Distance(prota.transform.position, transform.position) < 10)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaSaltoX * direccion, -fuerzaSaltoY), ForceMode2D.Impulse);
                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -fuerzaSaltoY), ForceMode2D.Impulse);
                }
                
            }
            
        }
    }
   
}
