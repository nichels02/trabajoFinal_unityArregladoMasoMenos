using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    float velocidad;
    int daño;
    float vida;
    [SerializeField] GameObject jugador;
    [SerializeField] Rigidbody MyRigidbody;
    [SerializeField] BoxCollider colider;
    GameObject rondas;
    bool estaSiguiendolo=false;
    Vector3 seguimiento;
    bool estaMuerto = false;
    bool inicio = false;

    public bool EstaSiguiendolo
    {
        get { return estaSiguiendolo; }
        set { estaSiguiendolo = value; }
    }

    public float Velocidad
    {
        get { return velocidad; }
        set { velocidad = value; }
    }
    public int Daño
    {
        get { return daño; }
        set { daño = value; }
    }
    public float Vida
    {
        get { return vida; }
        set { vida = value; }
    }
    public GameObject Jugador
    {
        get { return jugador; }
        set { jugador = value; }
    }
    public GameObject Rondas
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
        if (estaSiguiendolo == true)
        {
            seguimiento = new Vector3(jugador.transform.position.x, 138, jugador.transform.position.z);
            MyRigidbody.velocity = (seguimiento - transform.position).normalized * velocidad;
        }
        if (estaMuerto == true)
        {
            
        }
        
    }

    public void morir()
    {
        estaMuerto = true;
        estaSiguiendolo = false;
        colider.enabled = false;
        MyRigidbody.velocity = Vector3.zero;
        rondas.GetComponent<controladorRondas>().CantidadZombies -= 1;
        if(rondas.GetComponent<controladorRondas>().CantidadZombies==0 && rondas.GetComponent<controladorRondas>().CantidadZombiesMax == 0)
        {
            rondas.GetComponent<controladorRondas>().terminoRonda();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (inicio == false)
        {
            estaSiguiendolo = true;
            MyRigidbody.mass = 1;
            inicio=true;
        }
    }
}
