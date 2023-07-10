using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recorrido : MonoBehaviour
{
    public listas.grafo<Vector3> Grafo = new listas.grafo<Vector3>();
    public listas.grafo<Vector3> Grafo2 = new listas.grafo<Vector3>();
    [SerializeField] GameObject prefab;
    [SerializeField] Vector3[] Vectores = new Vector3[5];
    [SerializeField] Vector3[] Vectores2 = new Vector3[5];

    private void Awake()
    {
        Vectores[0] = new Vector3(-580, 140, -536);
        Vectores[1] = new Vector3(-540, 140, -536);
        Vectores[2] = new Vector3(-540, 140, -421);
        Vectores[3] = new Vector3(-540, 158.6f, -421);
        Vectores[4] = new Vector3(-540, 158.6f, -411.7f);

        Vectores2[0] = new Vector3(-645.2f, 140, -239.58f);
        Vectores2[1] = new Vector3(-645.2f, 140, -203.9f);
        Vectores2[2] = new Vector3(-604.56f, 140, -203.9f);
        Vectores2[3] = new Vector3(-604.56f, 156.98f, -203.9f);
        Vectores2[4] = new Vector3(-594.31f, 156.98f, -203.9f);
        for (int i = 0; i < Vectores.Length; i++)
        {
            Grafo.add(Vectores[i]);
        }
        for (int i = 0; i < Vectores2.Length; i++)
        {
            Grafo2.add(Vectores2[i]);
        }

        /*
        Grafo.add(new Vector3(10, 0, -9));
        Grafo.add(new Vector3(10, 0, 3));
        Grafo.add(new Vector3(10, 7, 3));
        Grafo.add(new Vector3(-3, 7, 3));
        */
        for (int i = 0; i < Vectores.Length - 1; i++)
        {
            Grafo.asignarEspecial(i + 1);
            Grafo.asignarEspecial2(i + 2);
            Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
        }

        for (int i = 0; i < Vectores2.Length - 1; i++)
        {
            Grafo2.asignarEspecial(i + 1);
            Grafo2.asignarEspecial2(i + 2);
            Grafo2.Tmp.Lista.AddNodeEnd(Grafo2.createConexion(Grafo2.Tmp2));
        }
        /*
        Grafo.asignarEspecial(1);
        Grafo.asignarEspecial2(2);
        Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
        Grafo.asignarEspecial(2);
        Grafo.asignarEspecial2(3);
        Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
        Grafo.asignarEspecial(3);
        Grafo.asignarEspecial2(4);
        Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
        */
        Grafo.asignarEspecial(1);
        Grafo2.asignarEspecial(1);

        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Instantiate(prefab, Grafo2.Tmp.Valor, transform.rotation);
        for (int i = 0; i < Vectores.Length - 1; i++)
        {
            Grafo.asignarEspecialConexion();
            Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        }
        for (int i = 0; i < Vectores2.Length - 1; i++)
        {
            Grafo2.asignarEspecialConexion();
            Instantiate(prefab, Grafo2.Tmp.Valor, transform.rotation);
        }

        /*
        Grafo.asignarEspecial(1);
        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Grafo.asignarEspecialConexion();
        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Grafo.asignarEspecialConexion();
        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Grafo.asignarEspecialConexion();
        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Grafo.asignarEspecial(1);
        */
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "punto")
        {
            if (Grafo.Tmp.Lista.Head != null)
            {
                Grafo.asignarEspecialConexion();
                myRigidbody.velocity = (Grafo.Tmp.Valor - transform.position).normalized * velocity;
            }
            /*
            else
            {
                myRigidbody.useGravity = true;
                codigo.enabled = true;
                this.enabled = false;
            }
            
        }
    }
    */
}

