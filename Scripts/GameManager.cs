using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    //Garbage Spawning
    public GameObject garbage;
    public GameObject recycling;
    [HideInInspector]
    public int garbageOnScreen;
    float dropRate = 3;
    //Score Keeping
    [HideInInspector]
    public int score;
    public TMP_Text scoreDis;
    //Game Management
    GameObject player;
    bool pause = false;
    bool endGame = false;
    public GameObject pauseMenu;
    public GameObject endScreen;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        scoreDis.text = score.ToString();

        if (score == 10 && endGame == false)
        {
            GameEnd();
        }
        if(endGame == false)
        {
            //Drop Timer Cooldown
            if (dropRate > 0)
            {
                dropRate -= Time.deltaTime;
            }

            if (Input.GetAxisRaw("Pause") == 1 && pause == false)
            {
                Pause();
            }
        }

        if (dropRate <= 0 && garbageOnScreen < 3)
        {
            //Where to drop
            float dropPosX = UnityEngine.Random.Range(-7.5f, 0f);
            Vector2 dropPos = new Vector2(dropPosX, 5.5f);

            //What to drop
            int item = UnityEngine.Random.Range(1, 3);

            if (item == 1)
            {
                Instantiate(garbage, dropPos, Quaternion.identity);
            }
            else Instantiate(recycling, dropPos, Quaternion.identity);

            dropRate = 3;
            garbageOnScreen += 1;
        }
    }
    private void GameEnd()
    {
        endGame = true;

        if (player)
        {
            Destroy(player);
        }
        else return;

        AudioManager am = FindObjectOfType<AudioManager>();
        Sound theme = Array.Find(am.sounds, Sound => Sound.name == "Theme");
        theme.volume = 0;
        Instantiate(endScreen, endScreen.transform.position, Quaternion.identity);

        am.Play("EndTheme");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        Destroy(pauseMenu);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Pause()
    {
        pause = true;
        Instantiate(pauseMenu, pauseMenu.transform.position, Quaternion.identity);
    }
}
