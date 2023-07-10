using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma : MonoBehaviour
{
    [SerializeField]string queArma;
    bool canDetect = true;
    public string QueArma
    {
        get { return queArma; }
        set { queArma = value; }
    }
    public bool CanDetect
    {
        get { return canDetect; }
        set { canDetect = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
