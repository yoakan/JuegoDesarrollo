using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPrefabsScript 
{
    private string partidaActualKey;
    private string volumenSonido;
    private string jefesPasados;
    private string[] rondaSuperadas;
    private string[] stats;
    private string[] habiliades;
    private string[] items;
    
    private PlayerPrefs prefs = new PlayerPrefs();
    public KeyPrefabsScript()
    {
        volumenSonido = "volumenDelSonido";
        rondaSuperadas = new string[] {"Ronda1_1"};
        jefesPasados = "jefesPasados";
        partidaActualKey = "partidaActual";
        items = new string[] {"objetoMuestra" };
        stats = new string[] { "vida", "saltos",   "Mundo", "nombreTeleportUsado" };
        habiliades = new string[] { "disparoLigero", "agacharse", "escudo", "disparoCargado", };
    }
    // Start is called before the first frame update
    public string[] getAllItems()
    {
        return items;
    }
    public string getIdItem(int id)
    {
        return items[id];
    }
    public string[] getAllStats(){
        return stats;
    }
    public string[] getAllHabilidades()
    {
        return habiliades;
    }
    public string[] getAllRondas()
    {
        return rondaSuperadas;
    }
    public string getUnaRonda( int id)
    {
        return rondaSuperadas[id];
    }
    public string getKeyPartidaSeleccionada()
    {
        return partidaActualKey;
    }
    public string getKeyPartodaSeleccionada2()
    {
        
        return PlayerPrefs.GetInt(partidaActualKey)+"";
    }
    public string getKeyJefesPasado()
    {
        return jefesPasados;
    }
    public string getKeyVida()
    {
        return stats[0];
    }
    public string getKeySalto()
    {
        return stats[1];
    }
    public string getKeyMundo()
    {
        return stats[2];
    }
    public string getKeyTeleport()
    {
        return stats[3];
    }
    public string getKeyDisparo()
    {
        return habiliades[0];
    }
    public string getVolumen()
    {
        return volumenSonido;
    }
    
}
