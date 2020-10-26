using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        pauseMenu.GameIsPaused = true;
    }


    public void closeOverview()
    {
        panel.SetActive(false);
        pauseMenu.GameIsPaused = false;
    }

}
