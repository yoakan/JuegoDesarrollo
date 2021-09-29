using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    protected int vida=10;
    protected int limVida = 10;
    protected int damage=3;
    protected bool murio = false;

    public  int getDamage()
    {
        return damage;
    }
    protected void recibirDamage(GameObject gameObject)
    {
        if (gameObject.tag == "bala")
        {
            
            vida = vida - gameObject.GetComponent<BalaScript>().getBalaDamage();
            StartCoroutine(CambioColor());
            
            if (vida < 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                murio = true;
                this.gameObject.SetActive(false);
                
            }
        }
        
    }
    IEnumerator CambioColor()
    {
        
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        
        float color = 0;
        float velocidad = 1f;

        while (color < 1)
        {
            
            color = color + Time.deltaTime * velocidad;
            GetComponent<SpriteRenderer>().color = new Color(255, color, color);
            
            yield return null;
        }
        


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        recibirDamage(collision.gameObject);
    }
    protected void OnEnable()
    {
        murio = false;
        vida = limVida;
    }
    public void revivirEnemigos()
    {
        murio = false;
    }
    public bool getMurio()
    {
        return murio;
    }
}
