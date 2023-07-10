using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controladorTiempo : MonoBehaviour
{
    [SerializeField] TMP_Text tiempo;
    [SerializeField] int minutos = 0;
    [SerializeField] int segundos = 0;
    int segundosTotales;
    float calculador=0;

    public int SegundosTotales
    {
        get { return segundosTotales; }
        set { segundosTotales = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calculador += Time.deltaTime;
        if(calculador > 1)
        {
            calculador = 0;
            segundos += 1;
            if (segundos < 10)
            {
                if (minutos < 10)
                {
                    tiempo.text = "0" + minutos + ":0" + segundos;
                }
                else
                {
                    tiempo.text = minutos + ":0" + segundos;
                }
            }
            else
            {
                if (minutos < 10)
                {
                    tiempo.text = "0" + minutos + ":" + segundos;
                }
                else
                {
                    tiempo.text = minutos + ":" + segundos;
                }
            }
        }
        if (segundos >= 60)
        {
            segundos = 0;
            minutos += 1;
            if (minutos < 10)
            {
                tiempo.text = "0" + minutos + ":00";
            }
            else
            {
                tiempo.text = minutos + ":00";
            }
        }

    }
}
