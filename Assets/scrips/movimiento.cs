using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class movimiento : rotacion
{
    [Header("Datos de Movimiento y Rotacion")]
    [SerializeField] float velocidad;
    [SerializeField] Rigidbody myRigidbody;
    [SerializeField] GameObject jugador;
    [SerializeField] TMP_Text puntaje;
    [SerializeField] int elpuntaje;
    Vector2 inputMovement;
    Vector2 Vector;

    [Header("Disparar")]
    listas.pila<string> listaDeArmas = new listas.pila<string>();
    [SerializeField] GameObject generadorDeBala;
    [SerializeField] GameObject generadorDeBalaEscoprta1;
    [SerializeField] GameObject generadorDeBalaEscoprta2;
    [SerializeField] GameObject Bala;
    [SerializeField] float tiempoDeRecargas;
    bool estaEnRecarga = false;
    float tiempo;


    [Header("Cantidad Balas")]
    [SerializeField] TMP_Text textoBalas;
    [Header("vida")]
    [SerializeField] Image[] corazones = new Image[10];
    int vida = 100;
    bool EstaSiendoatacado = true;
    [SerializeField] SOPuntaje puntajesAddDate;
    [SerializeField] controladorTiempo timeController;

    public int Vida
    {
        get { return vida; }
        set { vida = value; }
    }
    public int ELPuntaje
    {
        get { return elpuntaje; }
        set { elpuntaje = value; }
    }




    // Start is called before the first frame update
    void Start()
    {
        listaDeArmas.Add("pistolaPrincipal",10,10,1,2);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo <= listaDeArmas.Head.TiempoMax)
        {
            tiempo += Time.deltaTime;
        }
        if (estaEnRecarga == true)
        {
            if (tiempoDeRecargas < 2)
            {
                tiempoDeRecargas += Time.deltaTime;
            }
            else
            {
                Recargar();
            }
        }




    }

    public void actualizarPuntaje()
    {
        if (elpuntaje < 10)
        {
            puntaje.text = "00000" + elpuntaje;
        }
        else if (elpuntaje < 100)
        {
            puntaje.text = "0000" + elpuntaje;
        }
        else if (elpuntaje < 1000)
        {
            puntaje.text = "000" + elpuntaje;
        }
        else if (elpuntaje < 10000)
        {
            puntaje.text = "00" + elpuntaje;
        }
        else if (elpuntaje < 100000)
        {
            puntaje.text = "0" + elpuntaje;
        }
        else
        {
            puntaje.text = "" + elpuntaje;
        }
    }
    public void Mouse(InputAction.CallbackContext value)
    {
        pausa();
        mouseEstatico();
    }

    public void pausa()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void mouseEstatico()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {

            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Movement()
    {
        myRigidbody.velocity = transform.right * inputMovement.x * velocidad + transform.forward * inputMovement.y * velocidad;

    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
        inputMovement = inputMovement.normalized;
        myRigidbody.velocity = transform.right * inputMovement.x * velocidad + transform.forward * inputMovement.y * velocidad;

    }

 
    public void OnRotation(InputAction.CallbackContext value)
    {
        Vector2 inputRotation = value.ReadValue<Vector2>();
        Vector.x = angulos.x;
        Vector.y = angulos.y;
        //inputMovement.y = Mathf.Clamp(inputMovement.y, -0.4f, 0.5f);
        angulos.x = Mathf.Clamp(angulos.x, -50, 50);
        if (Vector != inputRotation)
        {
            angulos.x -= inputRotation.y / 20;
            angulos.y += inputRotation.x / 8;
            Movement();
        }
        
    }

    public void Disparar(InputAction.CallbackContext value)
    {
        if(Time.timeScale == 1f)
        {
            float valor = value.ReadValue<float>();
            if (listaDeArmas.Head.Valor == "pistolaPrincipal")
            {
                if (tiempo > 1)
                {
                    if (valor == 1)
                    {
                        if (listaDeArmas.Head.CantidadDeBalas > 0)
                        {
                            GameObject bala1 = Instantiate(Bala, transform.position, generadorDeBala.transform.rotation);
                            bala1.GetComponent<bala>().Jugador = jugador;
                            bala1.GetComponent<bala>().Daño = listaDeArmas.Head.Daño;
                            listaDeArmas.Head.CantidadDeBalas -= 1;
                            tiempo = 0;
                            if (listaDeArmas.Head.CantidadDeBalas <= 0)
                            {
                                if (estaEnRecarga == false)
                                {
                                    tiempoDeRecargas = 0;
                                    estaEnRecarga = true;
                                }
                            }
                        }


                        textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ ?";

                    }
                }
            }
            else if (listaDeArmas.Head.Valor == "metralleta")
            {
                if (tiempo > listaDeArmas.Head.TiempoMax)
                {
                    if (valor == 1)
                    {
                        if (listaDeArmas.Head.CantidadDeBalas > 0)
                        {
                            GameObject bala1 = Instantiate(Bala, transform.position, generadorDeBala.transform.rotation);
                            bala1.GetComponent<bala>().Daño = listaDeArmas.Head.Daño;
                            bala1.GetComponent<bala>().Jugador = jugador;
                            listaDeArmas.Head.CantidadDeBalas -= 1;
                            tiempo = 0;
                            textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
                            if (listaDeArmas.Head.CantidadDeBalas <= 0 && listaDeArmas.Head.CantidadDeBalasTotales <= 0)
                            {
                                listaDeArmas.remove();
                                if (listaDeArmas.Head.Valor == "pistolaPrincipal")
                                {
                                    textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ ?";
                                }
                                else
                                {
                                    textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
                                }
                            }
                            else if (listaDeArmas.Head.CantidadDeBalas <= 0)
                            {
                                if (estaEnRecarga == false)
                                {
                                    tiempoDeRecargas = 0;
                                    estaEnRecarga = true;
                                }
                            }
                        }
                    }
                }
            }
            else if (listaDeArmas.Head.Valor == "escopeta")
            {
                if (tiempo > listaDeArmas.Head.TiempoMax)
                {
                    if (valor == 1)
                    {
                        if (listaDeArmas.Head.CantidadDeBalas > 0)
                        {
                            GameObject bala1 = Instantiate(Bala, transform.position, generadorDeBalaEscoprta1.transform.rotation);
                            bala1.GetComponent<bala>().Daño = listaDeArmas.Head.Daño;
                            bala1.GetComponent<bala>().Jugador = jugador;
                            GameObject bala2 = Instantiate(Bala, transform.position, generadorDeBalaEscoprta2.transform.rotation);
                            bala2.GetComponent<bala>().Daño = listaDeArmas.Head.Daño;
                            bala2.GetComponent<bala>().Jugador = jugador;
                            listaDeArmas.Head.CantidadDeBalas -= 2;
                            tiempo = 0;
                            textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
                            if (listaDeArmas.Head.CantidadDeBalas <= 0 && listaDeArmas.Head.CantidadDeBalasTotales <= 0)
                            {
                                listaDeArmas.remove();
                                if (listaDeArmas.Head.Valor == "pistolaPrincipal")
                                {
                                    textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ ?";
                                }
                                else
                                {
                                    textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
                                }
                            }
                            else if (listaDeArmas.Head.CantidadDeBalas <= 0)
                            {
                                if (estaEnRecarga == false)
                                {
                                    tiempoDeRecargas = 0;
                                    estaEnRecarga = true;
                                }
                            }

                        }
                    }
                }
            }


            /*
            if (CantidadBala > 0 & tiempo>1)
            {
                if (valor == 1)
                {

                    Instantiate(Bala, generadorDeBala.transform.position, generadorDeBala.transform.rotation);
                    CantidadBala -= 1;
                    tiempo = 0;
                }
            }
            */
        }

    }

    public void Recargar()
    {

        estaEnRecarga = false;
        if(listaDeArmas.Head.Valor == "pistolaPrincipal")
        {
            listaDeArmas.Head.CantidadDeBalas = listaDeArmas.Head.CantidadDeBalasCargador;
            textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ ?";
        }
        else
        {
            listaDeArmas.Head.CantidadDeBalas = listaDeArmas.Head.CantidadDeBalasCargador;
            listaDeArmas.Head.CantidadDeBalasTotales -= listaDeArmas.Head.CantidadDeBalasCargador;
            textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
        }
        tiempo = 0;
    }

    public void cambiarVida(int restarVida)
    {
        vida -= restarVida;
        int x = (int)Mathf.Ceil(vida / 10);
        if (EstaSiendoatacado == true)
        {
            Destroy(corazones[x].gameObject);
            EstaSiendoatacado = false;
        }
        else
        {
            EstaSiendoatacado = true;
        }
        Debug.Log(vida);

        if (vida <= 0)
        {
            puntajesAddDate.add(elpuntaje,timeController.SegundosTotales);
            SceneManager.LoadScene("menu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "arma")
        {
            string arma = other.GetComponent<arma>().QueArma;
            Destroy(other.gameObject);
            if(arma == "metralleta" && other.GetComponent<arma>().CanDetect == true)
            {
                listaDeArmas.Add2(arma,30,30,300, 0.2f,5);
                textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
            }
            else if(arma == "escopeta" && other.GetComponent<arma>().CanDetect == true)
            {
                listaDeArmas.Add2(arma, 8, 8, 64, 2,20);
                textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
            }
            if (other.GetComponent<arma>().CanDetect == true)
            {
                other.GetComponent<arma>().CanDetect = false;
            }
        }
    }
}
