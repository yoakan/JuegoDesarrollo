using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeador : MonoBehaviour
{
    // Start is called before the first frame update
    public string tipoUpgrade;
    
    
    public GameObject teleportVinculado,iconoGuardar;
    private KeyPrefabsScript keys;
    // El primer numero es el mundo, y el segundo es el numero de la zona
    public int mundoActual;
 
    void Start()
    {
        keys = new KeyPrefabsScript();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mejorarPersonaje(Collider2D col)
    {
        
        ProtaScript prota = col.GetComponent<ProtaScript>();
        switch (tipoUpgrade)
        {
            case "masVida":
                prota.limVida = prota.limVida++;
                PlayerPrefs.SetInt(keys.getKeyVida() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()), prota.limVida);
                break;
            case "disparar":
                prota.puedeDisparar=true;
                PlayerPrefs.SetInt(keys.getKeyDisparo()+ PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()), prota.limSaltos);
                break;
            case "dobleSalto": 
                prota.limSaltos ++;
                PlayerPrefs.SetInt(keys.getKeySalto() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()), prota.limSaltos);
                break;
            
                /*
            case "agarchar": 
                prota.puedeAgacharse=true;
                PlayerPrefs.SetInt(keys.get, prota.limSaltos);
                break;
            
            case "disparoCargado":
                prota.puedeDispararCargado=true;
                PlayerPrefs.SetInt(prota.keys[5], prota.limVida);
                break;
            case "escudo": 
                prota.puedeUsarElEscudo=true;
                PlayerPrefs.SetInt(prota.keys[4], prota.limVida);
                break;*/
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            iconoGuardar.SetActive(true);

            mejorarPersonaje(collision);
            
            guardarPartida();



        }
    }
    

    private void guardarPartida()
    {
        
        PlayerPrefs.SetInt(keys.getKeyMundo()+ PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()), mundoActual);
        PlayerPrefs.DeleteKey(keys.getKeyTeleport() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()));
        PlayerPrefs.SetString(keys.getKeyTeleport()+ PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()), teleportVinculado.GetComponent<TeleportCheckPointScript>().nombre);

       
    }
}
