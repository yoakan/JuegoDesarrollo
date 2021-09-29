using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconoGuardarScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Start is called before the first frame update
    private float intensidad = 1;
    private float tiempoPasado = 0;
    private float velocidad = 0.5f;
    

    // Update is called once per frame
    void Update()
    {
        if (Time.time - tiempoPasado > 1)
        {
            intensidad = intensidad - velocidad * Time.deltaTime;
            GetComponent<Image>().color = new Color(
                    GetComponent<Image>().color.r,
                    GetComponent<Image>().color.g,
                    GetComponent<Image>().color.b,
                    intensidad
                );
            if (intensidad < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnEnable()
    {
        intensidad = 1;
        tiempoPasado = Time.time;
        GetComponent<Image>().color = new Color(
                    GetComponent<Image>().color.r,
                    GetComponent<Image>().color.g,
                    GetComponent<Image>().color.b,
                    1
                );
    }
    
}
