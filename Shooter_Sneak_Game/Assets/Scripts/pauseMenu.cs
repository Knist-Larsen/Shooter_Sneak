using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public Button fortsætBtn;
    public Button hoveMenuBtn;
    public Button settingsBtn;

    public int hovedmenuBuildIndex;
    public int settingsBuildIndex;

    private void Start()
    {

        fortsætBtn.onClick.AddListener(FortsætBtn);
        hoveMenuBtn.onClick.AddListener(HovedmenuBtn);
        settingsBtn.onClick.AddListener(SettingsBtn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Pauseknappen
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() // Fortsætter spillet
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() // Pauser Spillet
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void FortsætBtn() // Fortsætknappens funktioner
    {
        Resume();
    }

    void HovedmenuBtn() // Hovedmenuknappens funktioner
    {
        SceneManager.LoadScene(hovedmenuBuildIndex);
    }

    void SettingsBtn() // Instillingerknappens funktioner
    {
        SceneManager.LoadScene(settingsBuildIndex);
    }
}
