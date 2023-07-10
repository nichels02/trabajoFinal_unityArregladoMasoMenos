using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    [SerializeField] Rigidbody myRigidbody;
    [SerializeField] float velocidad;
    [SerializeField]int da�o;

    public int Da�o
    {
        get { return da�o; }
        set { da�o = value; }
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
        if(other.tag == "enemigo")
        {
            if (other.GetComponent<zombie>().EstaSiguiendolo==true)
            {
                other.GetComponent<zombie>().Vida -= da�o;
                Debug.Log(other.GetComponent<zombie>().Vida);
                if (other.GetComponent<zombie>().Vida <= 0)
                {
                    other.GetComponent<zombie>().morir();
                }
            }

        }
        if(other.tag != "disparador" && other.tag != "jugador")
        {
            Destroy(gameObject);
        }
    }
}
