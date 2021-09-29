using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Interfaz : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] ranuraPartidas;
    public GameObject botonDelete, botonCopiar;
    
    private bool deleteSelect=false, copiSelect=false;
    private int eleccionCopiar=0, dondeCopiar=0;
    private KeyPrefabsScript keys= new KeyPrefabsScript();
    void Start()
    {
        for(int e = 0; e < ranuraPartidas.Length; e++)
        {
            if(PlayerPrefs.HasKey(keys.getKeyMundo() + (e + 1)))
            {
                ranuraPartidas[e].GetComponent<RanuraPartida>().tieneUnaPartida();
                ranuraPartidas[e].GetComponent<RanuraPartida>().colocarTextItem(""+contarItems(e+1));
                ranuraPartidas[e].GetComponent<RanuraPartida>().colocarTextMundo(""+PlayerPrefs.GetInt(keys.getKeyMundo() + (e + 1)));
            }
        }
        
    }

    private string contarItems(int partida)
    {
        int contador = 0;
        for (int e =0; e<keys.getAllItems().Length;e++)
        {
            if (PlayerPrefs.HasKey(keys.getAllItems()[e] + partida)){
                contador++;
            }
        }
        return contador+"";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pulsaDelete()
    {
        
        deleteSelect = true;
        botonDelete.GetComponent<Image>().color = Color.red;
        copiSelect = false;
        botonCopiar.GetComponent<Image>().color = Color.black;
    }
    public void pulsaSelect()
    {
        botonCopiar.GetComponent<Image>().color = Color.blue;
        copiSelect = true;
        deleteSelect = false;
        botonDelete.GetComponent<Image>().color = Color.black;
    }
    public void fueraArea()
    {
        print("AHORA NO ");
        deleteSelect = false;
        botonDelete.GetComponent<Image>().color = Color.black;

        copiSelect = false;
        botonCopiar.GetComponent<Image>().color = Color.black;
    }
    public void gestionarPartida(int partida)
    {
        
        if(deleteSelect || copiSelect)
        {
            if (deleteSelect)
            {
                
                borrarPartida(partida);
                deleteSelect = false;
                botonDelete.GetComponent<Image>().color = Color.black;
                
            }
            if (copiSelect)
            {
                if (eleccionCopiar == 0)
                {
                    eleccionCopiar = partida;
                }
                else{

                    
                    dondeCopiar = partida;
                    copiarPartida();
                    eleccionCopiar = 0;
                    
                    copiSelect = false;
                    botonCopiar.GetComponent<Image>().color = Color.black;
                }
                
                
            }
        }
        else
        {
            cargarPartida(partida);
        }
    }

    private void cargarPartida(int partida)
    {
        PlayerPrefs.SetInt(keys.getKeyPartidaSeleccionada(),partida);
        
        abrirMundo(partida);
    }

    private void abrirMundo(int partida)
    {
        if(PlayerPrefs.HasKey(keys.getKeyMundo() + partida))
        {
            
            switch (PlayerPrefs.GetInt(keys.getKeyMundo() + partida))
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

    private void copiarPartida()
    {
        int mundo = PlayerPrefs.GetInt(keys.getKeyMundo() + eleccionCopiar);
        
        PlayerPrefs.SetInt(keys.getKeyMundo() + dondeCopiar,mundo);

        //print("HOLA NO SALGO POR QUE NO ME SALE DE LOS COJONES"+PlayerPrefs.GetInt(keys.getKeyMundo() + dondeCopiar));
        PlayerPrefs.SetFloat(keys.getVolumen() + dondeCopiar, PlayerPrefs.GetFloat(keys.getVolumen() + eleccionCopiar));
        PlayerPrefs.SetString(keys.getKeyTeleport() + dondeCopiar, PlayerPrefs.GetString(keys.getKeyTeleport() + eleccionCopiar));
        PlayerPrefs.SetInt(keys.getKeyJefesPasado() + dondeCopiar, PlayerPrefs.GetInt(keys.getKeyJefesPasado() + eleccionCopiar));
        print(" KEY: " + keys.getKeyMundo() + dondeCopiar + " DA" + PlayerPrefs.GetInt(keys.getKeyMundo() + dondeCopiar));
        copiarEnArrays(keys.getAllHabilidades());
        copiarEnArrays(keys.getAllItems());
        copiarEnArrays(keys.getAllRondas());
        copiarEnArrays(keys.getAllStats());
        ranuraPartidas[dondeCopiar-1].GetComponent<RanuraPartida>().tieneUnaPartida();
        ranuraPartidas[dondeCopiar - 1].GetComponent<RanuraPartida>().colocarTextItem("" + contarItems(dondeCopiar));
        
        ranuraPartidas[dondeCopiar - 1].GetComponent<RanuraPartida>().colocarTextMundo(""+PlayerPrefs.GetInt(keys.getKeyMundo() + dondeCopiar));
    }

    private void copiarEnArrays(string[] elementosPartidas)
    {
        for(int e=0; e < elementosPartidas.Length; e++)
        {
            if (PlayerPrefs.HasKey(elementosPartidas[e] + eleccionCopiar))
            {
                if (elementosPartidas[e] != "Mundo")
                {
                    PlayerPrefs.SetString(elementosPartidas[e] + dondeCopiar, PlayerPrefs.GetString(elementosPartidas[e] + eleccionCopiar));
                }
                
            }
        }
    }

    private void borrarPartida(int partida)
    {
        PlayerPrefs.DeleteKey(keys.getVolumen() + partida);
        PlayerPrefs.DeleteKey(keys.getKeyMundo() + partida);
        PlayerPrefs.DeleteKey(keys.getKeyTeleport() + partida);
        PlayerPrefs.DeleteKey(keys.getKeyJefesPasado() + partida);
        borrarArrays(partida,keys.getAllStats());
        borrarArrays(partida, keys.getAllHabilidades());
        borrarArrays(partida, keys.getAllRondas());
        borrarArrays(partida, keys.getAllItems());
        ranuraPartidas[partida-1].GetComponent<RanuraPartida>().noTieneNada();
        
    }

    private void borrarArrays(int partida,String[] elementos )
    {
        for(int e=0; e < elementos.Length; e++)
        {

            PlayerPrefs.DeleteKey(elementos[e] + partida);
        }
    }
    public void cerrarJuego()
    {
        Application.Quit();
    }
}
