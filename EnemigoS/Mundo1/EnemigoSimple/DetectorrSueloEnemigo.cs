using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorrSueloEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    private bool haySuelo = true;
    private GameObject sueloEstablecido;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0.121f, -0.114f,0);
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (sueloEstablecido == collision.gameObject)
        {
            haySuelo = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (sueloEstablecido == null)
        {
            sueloEstablecido = collision.gameObject;
        }
        haySuelo = true;
        
    }
    public bool getHaySuelo()
    {
        return haySuelo;
    }
    private void OnDisable()
    {

        sueloEstablecido = null;
    }

}
