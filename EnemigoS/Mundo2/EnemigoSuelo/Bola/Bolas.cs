using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolas : Enemigo
{
    // Start is called before the first frame update
    private int direccion=1;
    private float fuerza=10;
    public static int UP = 1, DOWN = 2, LEFT = 3, RIGHT = 4;
    void Start()
    {
        
    }
    public void setDireccion(int direccion)
    {
        this.direccion = direccion;
    }
    private void OnEnable()
    {
        //print("Direccion"+direccion);
        GetComponent<Rigidbody2D>().AddForce(vectorSeleccionado(), ForceMode2D.Impulse);
    }
    void Update()
    {
        
        
       
    }
    private Vector2 vectorSeleccionado()
    {
        Vector2 vector = new Vector2();
        switch (direccion)
        {
            case 1:vector = new Vector2(0,fuerza);
                break;
            case 2: vector = new Vector2(0, -fuerza); break;
            case 3: vector = new Vector2(fuerza, 0); break;
            case 4: vector = new Vector2(-fuerza, 0); break;
        }
        return vector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo"  || collision.gameObject.tag == "Prota")
        {
            gameObject.active = false;
        }
    }
}
