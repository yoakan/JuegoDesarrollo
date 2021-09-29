using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ProtaScript : MonoBehaviour
{
    //F8 SI QUIERES SOLUCIONAR EL PROBLEMA DE LOS SCRIPT
    //UNITY BLOQUEA TODOS LOS SCRIPTS HASTA QUE SOLCUIONES EL PROBLEMA
    /*public float velocidad;*/
    public int limSaltos;
    private int vida;
    public int mundoActual;
    public int limVida;
    private KeyPrefabsScript keysCreadas= new KeyPrefabsScript();
    public bool puedeAgacharse, puedeDisparar,puedeUsarElEscudo,puedeDispararCargado;
    public bool miraDerecha;

    public AudioClip recibeDamague, gameOver;
    private float tiempoGolpe,coldownInvurnerabilidad=1.5f;
    public GameObject ventanaGameOver;

    private float intensidadColor = 0 ,velocidadColor=2f;

    // Start is called before the first frame update
    void Start()
    {
        tiempoGolpe = 0;
        
        cargarPropiedades();
        vida = limVida;
        //limSaltos = 1;
        
        
        
    }
    
    //Me asegurop de que ha cargado la vida
    private void LateUpdate()
    {
        FindObjectOfType<VidaScript>().actualizarVidaProta(limVida);
    }
    private void cargarPropiedades()
    {
        if(PlayerPrefs.HasKey(keysCreadas.getKeyVida()+ PlayerPrefs.GetInt(keysCreadas.getKeyPartidaSeleccionada())))
        {
            limVida = PlayerPrefs.GetInt(keysCreadas.getKeyVida() + PlayerPrefs.GetInt(keysCreadas.getKeyPartidaSeleccionada()));
        }
        else{    limVida = 8;
            
        }

        if (PlayerPrefs.HasKey(keysCreadas.getKeySalto() + PlayerPrefs.GetInt(keysCreadas.getKeyPartidaSeleccionada()))){limSaltos = PlayerPrefs.GetInt(keysCreadas.getKeySalto() + PlayerPrefs.GetInt(keysCreadas.getKeyPartidaSeleccionada()));
            
        }
        else { limSaltos = 1; }

        if (PlayerPrefs.HasKey(keysCreadas.getKeyDisparo()+ PlayerPrefs.GetInt(keysCreadas.getKeyPartidaSeleccionada()))) { puedeDisparar = true; } else { puedeDisparar = false; }
        /*
        if (PlayerPrefs.HasKey(keys[3])) { puedeAgacharse= true; } else { puedeAgacharse = false; }
        if (PlayerPrefs.HasKey(keys[4])) { puedeUsarElEscudo = true; } else { puedeUsarElEscudo = false; }
        if (PlayerPrefs.HasKey(keys[5])) { puedeDispararCargado = true; } else { puedeDispararCargado = false; }*/
        
            
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation=Quaternion.Euler(0,0,0);
        
        if(tiempoGolpe!=0 )
        {
            visualizarInvurnerabilidad();
            
            
            if (Time.time - tiempoGolpe >= coldownInvurnerabilidad)
            {
                Physics2D.IgnoreLayerCollision(5, 8, false);
                tiempoGolpe = 0;
                GetComponent<SpriteRenderer>().color = new Color(
                GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b,
                1
                );
            }

            
            
        }
    }

    private void visualizarInvurnerabilidad()
    {
        if (intensidadColor >= 1)
        {
            velocidadColor = 2f * -1;
        }
        if (intensidadColor <= 0)
        {
            velocidadColor = 2f;
        }

        intensidadColor = intensidadColor + velocidadColor * Time.deltaTime;
        GetComponent<SpriteRenderer>().color = new Color(
            GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b,
            intensidadColor
            );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("GAME OVER"+ vida);
        if (collision.gameObject.tag == "Enemigo")
        {

            vida = vida - collision.gameObject.GetComponent<Enemigo>().getDamage();

            
            FindObjectOfType<VidaScript>().actualizarVidaProta(vida);

            
            Physics2D.IgnoreLayerCollision(5,8,true);
            tiempoGolpe = Time.time;
            //StartCoroutine("IndicarProtaErido");
            GetComponent<AudioSource>().clip = recibeDamague;
            GetComponent<AudioSource>().Play();
            
            if (vida <= 0)
            {

                mostrarGameOver();
                
                
            }
        }
        
    }

    private void mostrarGameOver()
    {
        Physics2D.IgnoreLayerCollision(5, 8, false);
        FindObjectOfType<CamaraScript>().GetComponent<AudioSource>().Pause();
        GetComponent<AudioSource>().clip = gameOver;
        GetComponent<AudioSource>().Play();
        ventanaGameOver.SetActive(true);
    }

    public void recargarLevel()
    {
        KeyPrefabsScript keys = new KeyPrefabsScript();
        if (PlayerPrefs.HasKey(keys.getKeyMundo() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada())))
        {

            switch (PlayerPrefs.GetInt(keys.getKeyMundo() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada())))
            {
                case 1:

                    SceneManager.LoadScene(1);
                    break;
                    /*
                case 0:
                    SceneManager.LoadScene(1);
                    break;
                    ;*/

            }
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mejoras")
        {
            vida = limVida;
            FindObjectOfType<VidaScript>().actualizarVidaProta(vida);
        }
        
    
    }
   
    public int getLimSaltos()
    {
        return limSaltos;
    }
    
}
