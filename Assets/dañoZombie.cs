using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañoZombie : MonoBehaviour
{
    bool estaAtacando = false;
    float tiempo=0;
    int yaAtaca=1;
    [SerializeField]GameObject jugador;

    public GameObject Jugador
    {
        get { return jugador; }
        set { jugador = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estaAtacando == true)
        {
            tiempo += Time.deltaTime;
            Debug.Log("preparando ataco +"+tiempo);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "jugador")
        {
            Debug.Log("preparando ataco");
            estaAtacando = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "jugador")
        {
            if (tiempo >= yaAtaca)
            {
                Debug.Log("ya ataco");
                tiempo = 0;
                estaAtacando = false;
                if (jugador.GetComponent<movimiento>().Vida > 0)
                {
                    jugador.GetComponent<movimiento>().cambiarVida(10);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "jugador")
        {
            estaAtacando = false;
            tiempo = 0;
        }
    }
}
