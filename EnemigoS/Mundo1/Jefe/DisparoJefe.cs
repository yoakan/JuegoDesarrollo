using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJefe : Enemigo
{
    // Start is called before the first frame update
    private int direccion = -1;
    public float fuerzaSalto,longitudSalto;
    private  float velocidad=120;
    
    private int limSaltos = 2;
    private int saltos = 0;
    void Start()
    {
        vida = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        
        GetComponentInChildren<SpriteRenderer>().transform.rotation= Quaternion.Euler(0, 0, velocidad*Time.time);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            ContactPoint2D[] contacts = new ContactPoint2D[1];
            GetComponent<Rigidbody2D>().GetContacts(contacts);
            

            if (contacts[0].normal.y > 0.9f)
            {
                
                GetComponent<Rigidbody2D>().AddForce(new Vector2(longitudSalto*direccion,fuerzaSalto), ForceMode2D.Impulse);
                saltos++;
                
                if (saltos > limSaltos)
                {
                    
                    gameObject.SetActive(false);
                }
            }
        }
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemigo")
        {
            gameObject.SetActive(false);
        }
    }

    public void setDireccion(int direccion)
    {
        this.direccion = direccion;
    }
    private void OnDisable()
    {
        saltos = 0;
    }
}
