using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaController : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("Instrucciones");
    }
    public void ExitGame()
    {
        Application.Quit(); //No sirve en editor
    }
}
