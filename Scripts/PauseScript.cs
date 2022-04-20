using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        gm.Resume();
        Destroy(gameObject);
    }
    public void MainMenu()
    {
        gm.MainMenu();
    }
}
