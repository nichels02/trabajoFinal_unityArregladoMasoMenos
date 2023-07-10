using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class controladorRondas : MonoBehaviour
{
    int rondas=1;
    [SerializeField] float tiempoGeneracion=10;
    [SerializeField] float restaDelTiempo=1;
    float tiempo=0;
    int cantidadZombies=0;
    int cantidadzombiesMax=20;
    int cantidadzombiesMaxDato=20;
    [SerializeField]UnityEvent generarZombie;

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
        cantidadzombiesMax = cantidadzombiesMaxDato * rondas;
        tiempoGeneracion = tiempoGeneracion - restaDelTiempo;
    }
}
