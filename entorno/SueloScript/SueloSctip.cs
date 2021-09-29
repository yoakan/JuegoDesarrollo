using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloSctip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("HOLAAA");
        if (collision.gameObject.tag == "bala")
        {
            Destroy(gameObject, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("HOLAAA");
        if (collision.gameObject.tag == "bala")
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
