using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class controladorRondas : MonoBehaviour
{
    int rondas=1;
    [SerializeField] float tiempoGeneracion=1;
    [SerializeField] float restaDelTiempo=0.1f;
    [SerializeField] TMP_Text textoDeRondas;
    [SerializeField] GameObject jugador;
    float tiempo=0;
    int cantidadZombies=0;
    int cantidadzombiesMax=10;
    int cantidadzombiesMaxDato=10;
    [SerializeField]UnityEvent generarZombie;

    public int CantidadZombiesMax
    {
        get { return cantidadzombiesMax; }
        set { cantidadzombiesMax = value; }
    }
    public int CantidadZombies 
    { 
        get { return cantidadZombies; } 
        set { cantidadZombies = value; } 
    }
    public int Rondas
    {
        get { return rondas; }
        set { rondas = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        if (tiempo >= tiempoGeneracion && cantidadzombiesMax != 0)
        {
            generarZombie.Invoke();
        }
    }

    public void generacionZombieRonda()
    {
        cantidadZombies = cantidadZombies + 1;
        cantidadzombiesMax=cantidadzombiesMax - 1;
        tiempo = 0;
    }
    public void terminoRonda()
    {
        tiempoGeneracion = tiempoGeneracion - (restaDelTiempo / rondas);
        rondas += 1;
        cantidadzombiesMax = cantidadzombiesMaxDato * rondas;
        textoDeRondas.text = "Ronda "+rondas;
        jugador.GetComponent<movimiento>().ELPuntaje += 10;
        jugador.GetComponent<movimiento>().actualizarPuntaje();
    }
}
