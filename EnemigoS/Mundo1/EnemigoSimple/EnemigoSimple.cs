using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSimple : Enemigo
{
    // Start is called before the first frame update
    private int direccion = 0;
    public float velocidad = 3;
    
    public GameObject detectorSuelo;
    void Start()
    {
        damage = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        transform.rotation = Quaternion.Euler(0, direccion, 0);
        transform.Translate(new Vector3(velocidad * Time.deltaTime, 0.0f));
        haySueloDelante();
    }

    private void haySueloDelante()
    {
        if (!detectorSuelo.GetComponent<DetectorrSueloEnemigo>().getHaySuelo() )
        {
            girarEnemigo();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            ContactPoint2D[] contacts = new ContactPoint2D[1];

            collision.GetContacts(contacts);
            if (contacts[0].normal.x >= 0.5f || contacts[0].normal.x <= -0.5f)
            {
                girarEnemigo();
                
            }
        }
        recibirDamage(collision.gameObject);
        
    }
    private void OnDisable()
    {
        
    }
    private void girarEnemigo()
    {
        direccion = direccion + 180;
        if (direccion > 180)
        {
            direccion = 0;
        }
        transform.rotation = Quaternion.Euler(0, direccion, 0);
    }
}
