using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject teleportVinculado;
    public GameObject levelVinculado;
    
    public Transform limTeleportInferiorLevel,limTeleportSuperiorLevel;

    public bool teleportDerecha;
    public float dezplazamientoEnX, dezplazamientoEnY;
    



    public String eleccion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            cambiarZonaCamara();
            try
            {
                descargarNivelActual();
                cargarNivelSiguiente();
            }
            catch(Exception e)
            {
                print(e);
            }
            
            teleportarPlayer(collision);
        }
        
        
    }

    private void teleportarPlayer(Collider2D prota)
    {
        Vector3 lugar = teleportVinculado.GetComponent<teleportScript>().getCoordenadasTeleport();
        
        prota.transform.position = new Vector3(lugar.x,lugar.y,prota.transform.position.z);
        
    }

    private void descargarNivelActual()
    {
        for(int e = 0; e < levelVinculado.GetComponentsInChildren<GeneradorEnemigo>().Length;e++)
        {
            
            levelVinculado.GetComponentsInChildren<GeneradorEnemigo>()[e].eleminarEnemigo();
        }
        levelVinculado.SetActive(false);

    }

    private void cambiarZonaCamara()
    {
        CamaraScript camaraScript = FindObjectOfType<CamaraScript>();

        camaraScript.limInicial = new Vector2(
            teleportVinculado.GetComponent<teleportScript>().limTeleportInferiorLevel.position.x,
            teleportVinculado.GetComponent<teleportScript>().limTeleportInferiorLevel.position.y);
        ;
        camaraScript.limFinal = new Vector2(
            teleportVinculado.GetComponent<teleportScript>().limTeleportSuperiorLevel.position.x,
            teleportVinculado.GetComponent<teleportScript>().limTeleportSuperiorLevel.position.y
            );
    }
    private void cargarNivelSiguiente()
    {
        
        teleportVinculado.GetComponent<teleportScript>().levelVinculado.SetActive(true);
        GameObject levelSiguiente =
        teleportVinculado.GetComponent<teleportScript>().levelVinculado;
        
        for (int e = 0; e < levelSiguiente.GetComponentsInChildren<GeneradorEnemigo>().Length; e++)
        {

            
            levelSiguiente.GetComponentsInChildren<GeneradorEnemigo>()[e].generarEnemigo();
        }
        
        //GetComponentInParent<ZonasTeleport>().desactivarTeleports(teleportVinculado.GetComponentInParent<ZonasTeleport>().gameObject);
        //teleportVinculado.GetComponentInParent<ZonasTeleport>().activarTeleports();
    }
    public Vector3 getCoordenadasTeleport()
    {
        return new Vector3(transform.position.x+dezplazamientoEnX,
            transform.position.y+dezplazamientoEnY,transform.position.z);
    }
    public bool getDireccionTeleport()
    {
        return teleportDerecha;
    }

}
