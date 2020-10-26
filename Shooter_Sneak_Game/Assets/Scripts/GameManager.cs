using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
    private int life;
    private int maxLife = 3;

    public Text EnText;

    

=======
    public GameObject Heart1, Heart2, Heart3;
    [SerializeField]
    public static int life;
    public static bool targetDead = false;
    public GameObject gameOverMenu;
    public GameObject vindMenu;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        life = maxLife;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject target = GameObject.FindGameObjectWithTag("Target");


=======
        life = 3;
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(true);
        gameOverMenu.SetActive(false);
        vindMenu.SetActive(false);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            GameOver();
=======
            GameVon();
            targetDead = false;
            print("Target er død og level blev unloadet");
>>>>>>> Stashed changes
        }


    }
    void GameOver()
    {
<<<<<<< Updated upstream
        EnText.text = "Du har tabt";
=======
        gameOverMenu.SetActive(true);
        pauseMenu.GameIsPaused = true;
    }

    void GameVon()
    {
        vindMenu.SetActive(true);
        pauseMenu.GameIsPaused = true;
>>>>>>> Stashed changes
    }


}
