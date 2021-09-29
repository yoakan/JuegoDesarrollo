using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject game;
    public bool direccion;
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        float espacio=4;
        if (!direccion)
        {
            espacio = espacio * (-1);
        }
        transform.position = new Vector3(game.GetComponent<Transform>().position.x+espacio, game.GetComponent<Transform>().position.y, game.GetComponent<Transform>().position.z);
    }
}
