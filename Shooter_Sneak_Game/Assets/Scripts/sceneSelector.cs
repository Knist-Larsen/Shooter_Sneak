using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneSelector : MonoBehaviour
{
    public int loadLvl;
    public Button btn;
    public bool fortsæt = false;
    public bool hovedmenu = false;
    public bool indstillinger = false;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        if (fortsæt == true)
        {
            Destroy(panel);
        }
        SceneManager.LoadScene(loadLvl);
    }
}
