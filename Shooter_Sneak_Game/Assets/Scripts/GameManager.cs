﻿using System;
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
    private int maxLife = 3;
    public Text EnText;
    public static bool targetDead = false;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(true);
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
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(0);
            targetDead = false;
            print("Target er død og level blev unloadet");
        }

    }


    
    void GameOver()
    {
        EnText.text = "GameOver";
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);

    }


}
