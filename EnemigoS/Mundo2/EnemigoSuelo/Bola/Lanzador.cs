using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bola;
    public int direccion;
    private float cooldown = 0 ,limCooldown=2;
    void Start()
    {
        bola.GetComponent<Bolas>().setDireccion(direccion);
    }

    // Update is called once per frame
    void Update()
    {
        if (!bola.activeSelf  && Time.time-cooldown>=limCooldown)
        {
            cooldown = Time.time;
            bola.transform.position = transform.position;
            bola.active = true;
        }
    }
}
