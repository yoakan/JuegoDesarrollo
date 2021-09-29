using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    public bool direccion;
    protected int damage;
    protected int dureza = 1;
    protected float velocidad;
    
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 16f * Time.deltaTime;
        int mundo = 1;
        if (mundo == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<SpriteRenderer>().color = new Color(12,21,12,31);
        }
        if(!direccion)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        damage = 2;
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (direccion )
        {
            transform.Translate(new Vector3(velocidad, 0.0f));

        }
        else
        {
            transform.Translate(new Vector3(-velocidad, 0.0f));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemigo" || collision.gameObject.tag == "Suelo")
        {
            
            Destroy(gameObject, 0f);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "Suelo")
        {

            Destroy(gameObject, 0f);
        }
    }
    public int getBalaDamage()
    {
        return damage;
    }
    public int getDuerza()
    {
        return dureza;
    }
}
