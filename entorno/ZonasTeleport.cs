using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonasTeleport : MonoBehaviour
{
    public GameObject[] levelTeleport;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void activarTeleports()
    {
        for(int i = 0; i < levelTeleport.Length; i++)
        {
            
            foreach (CamaraScript teleport in levelTeleport[i].GetComponentsInChildren<CamaraScript>())
            {
                
                teleport.gameObject.SetActive(true);
            }
            /*
            for (int e=0;e< levelTeleport[i].GetComponentsInChildren<Transform>().Length;e++)
            {
                levelTeleport[i].GetComponentsInChildren<GameObject>()[e].SetActive(true);
            }*/
        }
    }
    public void desactivarTeleports (GameObject otroNivel){
        
        for (int i = 0; i < levelTeleport.Length; i++)
        {   


            if (otroNivel.gameObject != levelTeleport[i].gameObject)
            {
                int e = 0;
                foreach (CamaraScript teleport in levelTeleport[i].GetComponentsInChildren<CamaraScript>())
                {
                    
                        teleport.gameObject.SetActive(false);
                    
                    
                    e++;
                    
                }/*
                for (int e = 0; e < levelTeleport[i].GetComponentsInChildren<Transform>().Length; e++)
                {
                    levelTeleport[i].GetComponentsInChildren<GameObject>()[e].SetActive(false);
                }*/
            }
            else
            {

            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
