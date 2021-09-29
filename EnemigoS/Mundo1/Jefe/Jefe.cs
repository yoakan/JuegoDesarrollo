using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jefe : Enemigo
{
    // Start is called before the first frame update
    public GameObject detector;
    public float velocidad;
    public GameObject[] disparos;
    private bool stop=false;
    public GameObject[] objetosMapa;
    public GameObject suelo;
    public Animator animacion;
    public AudioClip[] musica;
    private int eleccion = 70, numDisparo = 0,direccion=0;
    private float tiempo = 0;
    public int numJefe;

    void Start()
    {
        vida = 60;
        direccion = 0;
        KeyPrefabsScript keys = new KeyPrefabsScript();
        
        if (PlayerPrefs.GetInt(keys.getKeyJefesPasado()+ PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada())) < numJefe)
        {

            FindObjectOfType<CamaraScript>().setCancion(musica[0]);
            for (int e=0; e<objetosMapa.Length;e++)
            {
                objetosMapa[e].SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, direccion, 0);
        if (detector.GetComponent<DetectorPared>().getPared() == true)
        {
            if (stop == false)
            {
                
                eleccion = Random.Range(0, 100);
                
            }
            
            if (eleccion < 50)
            {
                stop = true;
            }
            if (stop == true)
            {
                disparar();
                
            }
            else
            {
                
                direccion = direccion +180;
                if (direccion > 182)
                {
                    direccion = 0;
                }
                transform.rotation = Quaternion.Euler(0, direccion, 0);
            }
        }
        else
        {
            numDisparo = 0;
            
               transform.Translate(new Vector3( velocidad * Time.deltaTime, 0.0f));
            
            
        }
        animar();
    }

    private void animar()
    {
        
        animacion.SetBool("disparar", detector.GetComponent<DetectorPared>().getPared());
    }

    private void OnDisable()
    {
       
        KeyPrefabsScript keys = new KeyPrefabsScript();
        if (PlayerPrefs.GetInt(keys.getKeyJefesPasado() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada())) < numJefe && vida<=0)
        {
            PlayerPrefs.SetInt(keys.getKeyJefesPasado() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()), numJefe);
            
            FindObjectOfType<CamaraScript>().setCancion(musica[1]);
        }
        
        for (int e = 0; e < objetosMapa.Length; e++)
        {
            objetosMapa[e].SetActive(true);
        }
        suelo.gameObject.SetActive(false);

    }

    private void disparar()
    {
        if (numDisparo < 3 )
        {
            
            if (tiempo == 0)
            {
                tiempo = Time.time;
            }
            
            if (Time.time - tiempo >= 3)
            {
                tiempo = Time.time;
                aparecerBala();
                numDisparo++;
                
            }
        }
        else
        {
            numDisparo = 0;
            stop = false;
        }
    }
    
    private void aparecerBala()
    {
        float distanciaBala = 1f;
        int direccionBala = 1;
        if (this.direccion == 0)
        {
            
            distanciaBala = distanciaBala * (-1);
            direccionBala = -1;
        }
        disparos[numDisparo].transform.position = new Vector3(transform.position.x+distanciaBala,transform.position.y,transform.position.z);
        disparos[numDisparo].GetComponent<DisparoJefe>().setDireccion(direccionBala);
        disparos[numDisparo].SetActive(true);
        disparos[numDisparo].GetComponent<Rigidbody2D>().AddForce(new Vector2(4*direccionBala,1),ForceMode2D.Impulse);
    }
}
