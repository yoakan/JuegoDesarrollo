using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] spritesDeLaVida;
    public GameObject[] stackVida;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void actualizarVidaProta(int vidaActual)
    {
        int vidaSimplificada=simplificarVida(vidaActual);
        print("Vida" + vidaSimplificada);
        if(vidaActual>=0 && vidaActual < spritesDeLaVida.Length)
        {
            GetComponent<Image>().sprite = spritesDeLaVida[vidaSimplificada];
        }
    }

    private int simplificarVida(int vidaActual)
    {
        int vidaEnStack = vidaActual / 8;
        for(int e = 0; e < stackVida.Length; e++)
        {
            
            if (e < vidaEnStack&& vidaActual != (e + 1) * 8)
            {
                
                stackVida[e].SetActive(true);
                
            }
            else
            {
                stackVida[e].SetActive(false);
            }
        }
        return (vidaActual - vidaEnStack*8)-1;
    }
}
