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

    public void ExitGame()
    {
        Application.Quit(); //No sirve en editor
    }
}
