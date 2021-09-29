using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSueloM2 : Enemigo
{
    // Start is called before the first frame update
    public GameObject prota;
    private float velocidad = 4;
    private float colision = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Vector2.Distance(prota.transform.position, transform.position) < 10)
        {
            
            int direccion = 1;
            if (prota.transform.position.x - transform.position.x < 0)
            {
                direccion = -1;
            }
            //print("Direccion: " + direccion + " COLISION " + colision);
            if (direccion != colision)
            {
                transform.Translate(new Vector3(velocidad * direccion * Time.deltaTime, 0, 0));
                colision = 0;
               
            }
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            
            ContactPoint2D[] contacts = new ContactPoint2D[1];
           
            collision.GetContacts(contacts);
            
            if (contacts[0].normal.x >= 0.5f)
            {
                colision = -1;
                print("ESTOY EN LA IZQUIERDA DE LA PARED");

            }
            else if (contacts[0].normal.x <= -0.5f)
            {
                colision = 1;
                //print("Estoy a la DERECHA");
                
            }
        }
    }
}
