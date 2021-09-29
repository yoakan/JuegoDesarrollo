using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prota;
    public GameObject limCamaraFinal;
    private float relacionX, relacionY;
    public Vector2 limInicial;
    public Vector2 limFinal;
   
    
    private float volumen;
    
    
    
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
        relacionX = limCamaraFinal.transform.position.x - transform.position.x;
        relacionY = limCamaraFinal.transform.position.y - transform.position.y;
        KeyPrefabsScript keys = new KeyPrefabsScript();
        if (PlayerPrefs.HasKey(keys.getVolumen() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada())))
        {
            volumen = PlayerPrefs.GetFloat(keys.getVolumen() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()));
            GetComponent<AudioSource>().volume =volumen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        float inicioCamaraX = limInicial.x - relacionX,
            finalCamaraX= limFinal.x + relacionX,
            inicioCamaraY= limInicial.y - relacionY,
            finalCamaraY= limFinal.y + relacionY;
        if (inicioCamaraX > finalCamaraX)
        {

            float correcion = (finalCamaraX + inicioCamaraX) / 2;
            finalCamaraX = correcion;
            inicioCamaraX = correcion;
        }

        if (inicioCamaraY > finalCamaraY)
        {
            finalCamaraY = inicioCamaraY;
        }
        transform.position = new Vector3(
            Mathf.Clamp(prota.transform.position.x, inicioCamaraX, finalCamaraX),
            Mathf.Clamp(prota.transform.position.y, inicioCamaraY, finalCamaraY), 
            transform.position.z
            );
    }
    public void cambiarVolumen(float volumen)
    {
        this.volumen = volumen * volumen;
        KeyPrefabsScript keys = new KeyPrefabsScript();
        PlayerPrefs.SetFloat(keys.getVolumen() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()), this.volumen);
        GetComponent<AudioSource>().volume = this.volumen;
    }
    public void setCancion( AudioClip musica)
    {
        GetComponent<AudioSource>().clip = musica;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = FindObjectOfType<CamaraScript>().volumen;
    }
    public float getVolumen()
    {
        return volumen;
    }
}
