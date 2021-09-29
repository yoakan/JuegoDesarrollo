using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    // Start is called before the first frame update
    public int numColeccion;
    KeyPrefabsScript keys;
    private float altura = 0.0025f;
    private float velocidad = 2;
    
    void Start()
    {
        
        keys = new KeyPrefabsScript();
        PlayerPrefs.DeleteKey(keys.getIdItem(numColeccion) + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()));
        if (PlayerPrefs.HasKey(keys.getIdItem(numColeccion) + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()))){
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        transform.Translate(new Vector3(0, Mathf.Sin(Time.time*velocidad)*altura));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            print("HOLA HE ENTRADO");
            PlayerPrefs.SetString(keys.getIdItem(numColeccion) + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada()), "true");
            gameObject.SetActive(false);
        }
    }
}
