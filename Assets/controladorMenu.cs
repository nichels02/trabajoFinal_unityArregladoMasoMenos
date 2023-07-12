using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class controladorMenu : MonoBehaviour
{
    [SerializeField] SOPuntaje puntajeSO;
    [SerializeField] TMP_Text[] text;
    void Start()
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = "Score " + (10 - i) +" : " + puntajeSO.Returm()[i];
        }
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CambioDeEscena()
    {
        SceneManager.LoadScene("juego");
    }
}
