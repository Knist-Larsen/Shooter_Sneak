using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneSelector : MonoBehaviour
{
    public bool retry = false;
    public int loadLvl;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        if (retry == false)
        {
            SceneManager.LoadScene(loadLvl);
            print("Nu loades level med indeks " + loadLvl);
        }
        else
        {
            
        }
    }
}
