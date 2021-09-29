using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCheckPointScript : teleportScript
{
    // Start is called before the first frame update
    public GameObject checkPoint;
    public string nombre;
    private KeyPrefabsScript keys= new KeyPrefabsScript();

    void Start()
    {
        cargarEntorno();
    }
    public void cargarEntorno()
    {
        string mundoSeleccionado = "" + keys.getKeyPartidaSeleccionada();
        
        if(PlayerPrefs.HasKey(keys.getKeyTeleport() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada())))
        {
            if (PlayerPrefs.GetString(keys.getKeyTeleport() + PlayerPrefs.GetInt(keys.getKeyPartidaSeleccionada())) == nombre)
            {
                CamaraScript camaraScript = FindObjectOfType<CamaraScript>();
                camaraScript.limInicial = new Vector2(
                         limTeleportInferiorLevel.position.x,
                         limTeleportInferiorLevel.position.y
                    );
                camaraScript.limFinal = new Vector2(
                         limTeleportSuperiorLevel.position.x,
                         limTeleportSuperiorLevel.position.y
                    );
                levelVinculado.SetActive(true);
                ProtaScript protaScript = FindObjectOfType<ProtaScript>();
                protaScript.gameObject.transform.position = new Vector3(
                        checkPoint.transform.position.x,
                        checkPoint.transform.position.y,
                        protaScript.gameObject.transform.position.z
                    );
            }
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
