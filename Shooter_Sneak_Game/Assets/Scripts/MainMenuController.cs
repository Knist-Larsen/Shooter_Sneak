using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    Button thisBtn;
    public GameObject thisPanel;
    public GameObject nextPanel;
    public bool QuitBtn;

    // Start is called before the first frame update
    void Start()
    {
        thisBtn = this.gameObject.GetComponent<Button>();
        if (QuitBtn == true)
        {
            thisBtn.onClick.AddListener(Quit);
        }
        else
        {
            thisBtn.onClick.AddListener(ThisBtn);
        }
    }

    void ThisBtn()
    {
        thisPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
    void Quit()
    {
        Application.Quit();
    }
}
