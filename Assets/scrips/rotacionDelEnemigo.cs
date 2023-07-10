using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionDelEnemigo : rotacion
{
    [SerializeField] private GameObject jugador;

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
        float anguloRadianes = Mathf.Atan2(jugador.transform.position.z - transform.position.z, jugador.transform.position.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
        angulos.y = anguloGrados * -1;

    }
}
