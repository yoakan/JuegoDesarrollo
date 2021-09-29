using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    // Añadir carga de la cantidad de sonido
    public GameObject controles;
    public Slider slider;
    public float valorAnteriorVolumen;

    void Start()
    {
        KeyPrefabsScript keys = new KeyPrefabsScript();
        if (PlayerPrefs.HasKey(keys.getVolumen() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada())))
        {
            float volumen= PlayerPrefs.GetFloat(keys.getVolumen() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()));
            slider.value = Mathf.Sqrt(volumen);
        }
        else
        {
            slider.value = 1;
        }
    }
    void Update()
    {
        if (slider.value != valorAnteriorVolumen)
        {
            valorAnteriorVolumen = slider.value;
            cambiarVolumen(slider.value);
        }
    }
    public void volverAPartida()
    {
        controles.SetActive(true);
        gameObject.SetActive(false);
    }

    public void cambiarVolumen( float volumen)
    {
        //print("El volumen es: "+ volumen);
        FindObjectOfType<CamaraScript>().cambiarVolumen(volumen);
    }
    public void cerrarJuego()
    {
        
        Application.Quit();
    }
    

}
