using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static int life;
    private int maxLife = 3;

    public Text EnText;

    


    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject target = GameObject.FindGameObjectWithTag("Target");


    }

    // Update is called once per frame
    void Update()
    {
        EndGame();


    }

    void EndGame()
    {

       


    }

    void LifeCounter()
    {
        if (life == 0)
        {
            GameOver();
        }


    }
    void GameOver()
    {
        EnText.text = "Du har tabt";
    }


}
