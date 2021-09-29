using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorPared : MonoBehaviour
{
    // Start is called before the first frame update
    private bool colisionaConPared = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0f, 0f, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            colisionaConPared = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo"  )
        {
            colisionaConPared = false;
            
        }
        
    }
    public bool getPared()
    {
        return colisionaConPared;
    }
}
