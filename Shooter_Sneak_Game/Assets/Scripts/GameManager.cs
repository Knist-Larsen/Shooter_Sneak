using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject Heart1, Heart2, Heart3;
    [SerializeField]
    public static int life;
    public static bool targetDead = false;
    public GameObject gameOverMenu;
    public GameObject vindMenu;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(true);
        gameOverMenu.SetActive(false);
        vindMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (life > 3)
            life = 3;
        switch (life)
        {
            case 3:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                break;
            case 2:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                break;
            case 1:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
            case 0:
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                GameOver();
                break;
        }

        if (targetDead == true)
        {
            GameVon();
            targetDead = false;
            print("Target er død og level blev unloadet");
        }
        
    }

    void GameOver()
    {
        gameOverMenu.SetActive(true);
        pauseMenu.GameIsPaused = true;
    }

    void GameVon()
    {
        vindMenu.SetActive(true);
        pauseMenu.GameIsPaused = true;
    }
}
