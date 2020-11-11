using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    public float cameraOffset;

    // Update is called once per frame
    void Update()
    {
        // Kameraet bliver sat til spillerens position, og rykket tilbage af "cameraOffset" størrelsen
        Vector3 playerPos = player.position;
        playerPos.y += cameraOffset;
        this.transform.position = playerPos;
    }
}
