using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    [SerializeField] Rigidbody myRigidbody;
    [SerializeField] float velocidad;
    [SerializeField]int daño;
    bool yaColiciono = false;
    GameObject jugador;

    public GameObject Jugador
    {
        get { return jugador; }
        set { jugador = value; }
    }
    public int Daño
    {
        get { return daño; }
        set { daño = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = transform.forward * velocidad;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colicion 1");
        if (yaColiciono == false)
        {
            Debug.Log("colicion 2");
            if (other.tag == "enemigo")
            {
                Debug.Log("colicion 3");
                if (other.GetComponent<zombie>().EstaSiguiendolo == true)
                {
                    yaColiciono = true;
                    Debug.Log("colicion 4");
                    other.GetComponent<zombie>().Vida -= daño;
                    Debug.Log(other.GetComponent<zombie>().Vida);
                    jugador.GetComponent<movimiento>().ELPuntaje += 10;
                    if (other.GetComponent<zombie>().Vida <= 0)
                    {
                        jugador.GetComponent<movimiento>().ELPuntaje += 100;
                        other.GetComponent<zombie>().morir();
                    }

                    jugador.GetComponent<movimiento>().actualizarPuntaje();

                }

            }
        }
        if(other.tag != "disparador" && other.tag != "jugador" && other.tag != "bala")
        {
            if (other.tag == "enemigo")
            {
                Debug.Log("colicion destruccion");
            }
            else
            {
                Debug.Log(other.tag);
            }
            Destroy(gameObject);
        }
    }
}
