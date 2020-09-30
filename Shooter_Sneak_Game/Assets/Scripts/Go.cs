using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour
{
    public GameObject panel;
    public void closeOverview()
    {
        panel.SetActive(false);
    }

}
