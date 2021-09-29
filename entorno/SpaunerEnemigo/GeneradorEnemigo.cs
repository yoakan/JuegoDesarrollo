using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemigo;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void generarEnemigo()
    {
        
        
        enemigo.gameObject.SetActive(true);

        enemigo.transform.position=new Vector3(transform.position.x, transform.position.y, -1);
        
    }
    public void eleminarEnemigo()
    {
        enemigo.gameObject.SetActive(false);


    }
}
