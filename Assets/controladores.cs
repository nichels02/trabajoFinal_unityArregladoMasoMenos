using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladores : MonoBehaviour
{
    [SerializeField] GameObject generarZombies;
    public GameObject grafo;
    [SerializeField] GameObject rondas;
    // Start is called before the first frame update
    private void Awake()
    {
        Instantiate(generarZombies);
        Instantiate(grafo);
        Instantiate(rondas);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
