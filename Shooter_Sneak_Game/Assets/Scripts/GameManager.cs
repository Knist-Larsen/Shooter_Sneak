using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject Heart1, Heart2, Heart3;
    [SerializeField]
    public static int life;
    public Text EnText;

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

    }


    
    void GameOver()
    {
        EnText.text = "GameOver";
    }


}
