using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generacionZombie : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject controladorDeRondas;
    [Header("Posiciones")]
    [SerializeField] Vector3 posicion1;
    [SerializeField] Vector3 posicion2;
    [Header("Datos")]
    [SerializeField] int vida;
    [SerializeField] int daño;
    [SerializeField] int velocidad;
    [SerializeField] GameObject jugador;
    [SerializeField] GameObject rotacion;
    [SerializeField] GameObject dañador;
    [SerializeField] GameObject rondas;
    [SerializeField] GameObject escopeta;
    [SerializeField] GameObject metralleta;
    bool eleccion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generacionZombieEnemigo()
    {
        eleccion = Random.Range(0, 2) == 1;
        if (eleccion == true)
        {
            GameObject enemigo= Instantiate(zombie, posicion1, rotacion.transform.rotation);
            enemigo.GetComponent<recorridoDeZombie>().Jugador = jugador;
            enemigo.GetComponent<rotacionDelEnemigo>().Jugador = jugador;
            enemigo.GetComponent<zombie>().Jugador = jugador;
            enemigo.GetComponent<zombie>().Metralleta = metralleta;
            enemigo.GetComponent<zombie>().Escopeta = escopeta;
            enemigo.GetComponent<zombie>().Rondas = rondas;
            enemigo.GetComponent<zombie>().Vida = vida * controladorDeRondas.GetComponent<controladorRondas>().Rondas;
            enemigo.GetComponent<zombie>().Daño = daño;
            enemigo.GetComponent<zombie>().Velocidad = velocidad;
            enemigo.GetComponent<recorridoDeZombie>().Posicion = 1;
            enemigo.GetComponent<zombie>().enabled = false;
        }
        else
        {
            GameObject enemigo = Instantiate(zombie, posicion2, transform.rotation);
            enemigo.GetComponent<recorridoDeZombie>().Jugador = jugador;
            enemigo.GetComponent<rotacionDelEnemigo>().Jugador = jugador;
            enemigo.GetComponent<zombie>().Jugador = jugador;
            enemigo.GetComponent<zombie>().Metralleta = metralleta;
            enemigo.GetComponent<zombie>().Escopeta = escopeta;
            enemigo.GetComponent<zombie>().Rondas = rondas;
            enemigo.GetComponent<zombie>().Vida = vida * controladorDeRondas.GetComponent<controladorRondas>().Rondas;
            enemigo.GetComponent<zombie>().Daño = daño;
            enemigo.GetComponent<zombie>().Velocidad = velocidad;
            enemigo.GetComponent<recorridoDeZombie>().Posicion = 2;
            enemigo.GetComponent<zombie>().enabled = false;
        }
    }
}
