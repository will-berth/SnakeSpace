using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public HUD hud;
    public int PuntosTotales { get; private set;}

    private int vidas = 3;
    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Hay mas de un GameManager en escena");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
        hud.ActualizarPuntos(PuntosTotales);
    }

    public void PerderVida()
    {
        vidas -= 1;
        if(vidas == 0)
        {
            // El nivel se reinicia
            SceneManager.LoadScene(0);
        }
        hud.DesactivarVida(vidas);
    }

    public void RecuperarVida()
    {
        if(vidas == 3)
        {
            return;
        }
        
        hud.ActivarVida(vidas);
        vidas += 1;
    }
}
