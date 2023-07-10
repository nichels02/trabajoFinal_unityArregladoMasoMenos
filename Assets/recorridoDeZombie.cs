using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recorridoDeZombie : MonoBehaviour
{
    [SerializeField] zombie Zombie;
    [SerializeField] rotacionDelEnemigo rotacion;
    [SerializeField] Rigidbody MyRigidbody;
    [SerializeField] BoxCollider colider;
    [SerializeField] GameObject jugador;
    [SerializeField] GameObject dañador;

    Vector3[] Vectores = new Vector3[5];
    listas.grafo<Vector3> Grafo = new listas.grafo<Vector3>();
    int posicion;
    public GameObject Jugador
    {
        get { return jugador; }
        set { jugador = value; }
    }
    public int Posicion
    {
        get { return posicion; }
        set { posicion = value; }
    }

    private void Awake()
    {
        



    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (posicion == 1)
        {
            Debug.Log("ya funciono");
            Vectores[0] = new Vector3(-645.2f, 140, -239.58f);
            Vectores[1] = new Vector3(-645.2f, 140, -203.9f);
            Vectores[2] = new Vector3(-604.56f, 140, -203.9f);
            Vectores[3] = new Vector3(-604.56f, 156.98f, -203.9f);
            Vectores[4] = new Vector3(-594.31f, 156.98f, -203.9f);

            for (int i = 0; i < Vectores.Length; i++)
            {
                Grafo.add(Vectores[i]);
            }

            for (int i = 0; i < Vectores.Length - 1; i++)
            {
                Grafo.asignarEspecial(i + 1);
                Grafo.asignarEspecial2(i + 2);
                Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
            }
            Debug.Log("ya funciono");
            Grafo.asignarEspecial(1);
            MyRigidbody.velocity = (Grafo.Tmp.Valor - transform.position).normalized * Zombie.GetComponent<zombie>().Velocidad;
        }
        else if (posicion == 2)
        {
            Debug.Log("ya funciono");
            Vectores[0] = new Vector3(-580, 140, -536);
            Vectores[1] = new Vector3(-540, 140, -536);
            Vectores[2] = new Vector3(-540, 140, -421);
            Vectores[3] = new Vector3(-540, 158.6f, -421);
            Vectores[4] = new Vector3(-540, 158.6f, -411.7f);

            for (int i = 0; i < Vectores.Length; i++)
            {
                Grafo.add(Vectores[i]);
            }

            for (int i = 0; i < Vectores.Length - 1; i++)
            {
                Grafo.asignarEspecial(i + 1);
                Grafo.asignarEspecial2(i + 2);
                Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
            }
            Debug.Log("ya funciono");
            Grafo.asignarEspecial(1);
            MyRigidbody.velocity = (Grafo.Tmp.Valor - transform.position).normalized * Zombie.GetComponent<zombie>().Velocidad;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void colisionRecorido()
    {
        
        if (Grafo.Tmp.Lista.Head != null)
        {
            Grafo.asignarEspecialConexion();
            MyRigidbody.velocity = (Grafo.Tmp.Valor - transform.position).normalized * Zombie.GetComponent<zombie>().Velocidad;
        }
        else
        {
            Zombie.Velocidad = 15;
            MyRigidbody.useGravity = true;
            colider.isTrigger = false;
            Zombie.enabled = true;
            rotacion.enabled = true;
            this.enabled = false;
            dañador.GetComponent<dañoZombie>().Jugador = jugador;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

    }
}
