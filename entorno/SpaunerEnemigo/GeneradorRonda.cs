using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorRonda : MonoBehaviour
{
    // Start is called before the first frame update
    private bool termino=false;
    public GameObject puertaDerecha,puertaIzquierda;
    
    public GameObject[] enemigos;
    public int id;
    public KeyPrefabsScript keys= new KeyPrefabsScript();
    private int ronda = 0;
    
    void Start()
    {
        //PlayerPrefs.DeleteKey(keys.getUnaRonda(id) + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()));
        if (PlayerPrefs.HasKey(keys.getUnaRonda(id) + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada())))
        {
            termino = true;
        }
        
        if (!termino)
        {
            revivirEnemigos();
            
            puertaDerecha.GetComponent<BoxCollider2D>().enabled = true;
            puertaIzquierda.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void revivirEnemigos()
    {
        for(int e=0;e<  enemigos.Length;e++)
        {
            enemigos[e].GetComponent<Enemigo>().revivirEnemigos();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!termino)
        {
            if (ronda < 2)
            {
                rondaUnEnemigo();
            }
            else
            {
                rondaDosEnemigos();
                
            }

        }
        animacionesPuerta();

    }

    private void animacionesPuerta()
    {
        puertaDerecha.GetComponent<Animator>().SetBool("AbrirPuerta", termino);
        
        puertaIzquierda.GetComponent<Animator>().SetBool("AbrirPuerta", termino);
    }

    private void rondaUnEnemigo()
    {
        int rondaActual = ronda;
        if (enemigos[ronda].GetComponent<Enemigo>().getMurio())
        {
            
            ronda++;
        }
        if (!enemigos[ronda].gameObject.activeSelf && rondaActual == ronda)
        {
            
            enemigos[ronda].gameObject.SetActive(true);

            enemigos[ronda].transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }
    private void rondaDosEnemigos (){
        if (enemigos[ronda].GetComponent<Enemigo>().getMurio() && enemigos[ronda + 1].GetComponent<Enemigo>().getMurio())
        {
            termino = true;
            PlayerPrefs.SetString(keys.getUnaRonda(id) + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()),"true");
            puertaDerecha.GetComponent<BoxCollider2D>().enabled = false;
            puertaIzquierda.GetComponent<BoxCollider2D>().enabled = false;
            

        }

        if (!enemigos[ronda].gameObject.activeSelf && !enemigos[ronda + 1].gameObject.activeSelf && !termino)
        {

            enemigos[ronda].gameObject.SetActive(true);

            enemigos[ronda].transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            enemigos[ronda + 1].gameObject.SetActive(true);

            enemigos[ronda + 1].transform.position = new Vector3(transform.position.x + 1, transform.position.y, -1);
        }
    }
}
