using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RanuraPartida : MonoBehaviour
{
    public GameObject iconoItem,textItem,iconoMundo,textMundo,textNada;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void colocarTextItem(string texto)
    {
        textItem.GetComponent<Text>().text = texto;

    }
    public void colocarTextMundo(string texto)
    {
        textMundo.GetComponent<Text>().text = texto;
    }
    public void noTieneNada()
    {
        iconoMundo.gameObject.SetActive(false);
        iconoItem.gameObject.SetActive(false);
        textMundo.gameObject.SetActive(false);
        textItem.gameObject.SetActive(false);
        textNada.gameObject.SetActive(true);

    }
    public void tieneUnaPartida()
    {
        iconoMundo.gameObject.SetActive(true);
        iconoItem.gameObject.SetActive(true);
        textMundo.gameObject.SetActive(true);
        textItem.gameObject.SetActive(true);
        textNada.gameObject.SetActive(false);
    }

    
}
