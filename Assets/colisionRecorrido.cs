using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionRecorrido : MonoBehaviour
{
    [SerializeField] GameObject elrecorrido;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "punto")
        {
            elrecorrido.GetComponent<recorridoDeZombie>().colisionRecorido();
        }
    }
}
