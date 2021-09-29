using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloRompible : MonoBehaviour
{
    // Start is called before the first frame update
    public int vida;
    public int levelDureza;
    public GameObject paredVinculada;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            paredVinculada.SetActive(false);
            gameObject.SetActive(false);

        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "bala")
        {
            if (collision.gameObject.GetComponent<BalaScript>().getDuerza() >= levelDureza)
            {
                vida = vida - collision.gameObject.GetComponent<BalaScript>().getBalaDamage();

            }

        }
    }
    public void destruirPorCargarLaPared()
    {
        vida = -1;
    }
    
}
