using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menufunciones : MonoBehaviour
{
    public void EmpezarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }


    public void Salir()
    {
        Application.Quit();
        Debug.Log("Aqui se cierra el programa");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("creditos");
    }

}
