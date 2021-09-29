using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaGorda : MonoBehaviour
{
    // Start is called before the first frame update
    public bool direccion;
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (direccion == true)
        {
            transform.Translate(new Vector3(0.15f, 0.0f));

        }
        else
        {
            transform.Translate(new Vector3(-0.15f, 0.0f));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "SueloRompible")
        {
            print("ESTAS MUERTO NENA");
            Destroy(collision.gameObject, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("ESTAS  NENA");
        if (collision.gameObject.tag == "SueloRompible")
        {
            print("ESTAS MUERTO NENA");
            Destroy(collision.gameObject, 1f);
        }
    }
}
