using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaController : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadMinijuegoObstaculos()
    {
        SceneManager.LoadScene("MinijuegoObstaculos");
    }
    public void LoadInstruccionesObstaculos()
    {
        SceneManager.LoadScene("InstruccionesObstaculos");
    }

    public void LoadTablero()
    {
        SceneManager.LoadScene("PartyGame");
    }
    public void LoadLaberinto()
    {
        SceneManager.LoadScene("Laberinto");
    }

    public void LoadPong()
    {
        SceneManager.LoadScene("Pong");
    }

    public void LoadInstruccionesPong()
    {
        SceneManager.LoadScene("InstruccionesPong");
    }

    public void LoadDisparador()
    {
        SceneManager.LoadScene("Disparador");
    }

    public void LoadInstruccionesDisparador()
    {
        SceneManager.LoadScene("InstruccionesDisparador");
    }

    public void LoadInstruccionesLaberinto()
    {
        SceneManager.LoadScene("InstruccionesLaberinto");
    }

    public void ExitGame()
    {
        Application.Quit(); //No sirve en editor
    }
}
