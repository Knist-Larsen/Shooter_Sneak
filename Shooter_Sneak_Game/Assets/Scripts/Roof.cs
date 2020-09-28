using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{

    public GameObject roof = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            roof.SetActive(false);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")

        {
            roof.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
