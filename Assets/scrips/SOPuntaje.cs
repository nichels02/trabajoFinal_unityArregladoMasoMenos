using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Ordenamiento", menuName = "ScriptableObjets/Ordenamiento",order =0)]
public class SOPuntaje : ScriptableObject
{
    public int[] listaPuntajes = new int[10];
    int x=0;
    public void add(int value, int time)
    {
        int calculatepuntaje = (int)value / time;
        if (x < 10)
        {
            listaPuntajes[x] = calculatepuntaje;
            x++;
        }
        else
        {
            if(calculatepuntaje > listaPuntajes[0])
            {
                listaPuntajes[0] = calculatepuntaje;
            }
        }
        Burbuja();
    }
    void Burbuja()
    {
        int tmp;
        for(int i =0; i< listaPuntajes.Length - 1; i++)
        {
            for (int j = 0; j < listaPuntajes.Length -i-1; j++)
            {
                if(listaPuntajes[j] > listaPuntajes[j + 1])
                {
                    tmp = listaPuntajes[j];
                    listaPuntajes[j] = listaPuntajes[j + 1];
                    listaPuntajes[j+1] =tmp;
                }
            }
        }
    }
    public int[] Returm()
    {
        return listaPuntajes;
    }
    
}
