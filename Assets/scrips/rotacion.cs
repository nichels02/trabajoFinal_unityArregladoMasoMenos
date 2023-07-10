using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    [SerializeField] protected Vector3 angulos;


    private Quaternion qx = Quaternion.identity; //(0,0,0,1)
    private Quaternion qy = Quaternion.identity; //(0,0,0,1)
    private Quaternion qz = Quaternion.identity; //(0,0,0,1)


    [SerializeField] private Quaternion r = Quaternion.identity; //(0,0,0,1)
    private float anguloSen;
    private float anguloCos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotacion z-> x-> y
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.z * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.z * 0.5f);
        qz.Set(0, 0, anguloSen, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.y * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.y * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);


        r = qy * qx * qz;

        transform.rotation = r;
    }
}
