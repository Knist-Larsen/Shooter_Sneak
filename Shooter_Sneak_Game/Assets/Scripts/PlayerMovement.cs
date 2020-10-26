using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    public float speed;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //opretter bevægelsesvektor ud fra WASD eller piletaster. .normalized sørger for, at spilleren ikke går hurtigere, når man går skråt (fx trykker fx både W og D ned samtidig)
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        //kalder funktion, der får spilleren til at se mod cursoren
        if (pauseMenu.GameIsPaused == false)
        {
            LookAtMouse();
        }
    }

    private void FixedUpdate()
    {
        //bevæger spilleren ud fra den bevægelsesvektor, der blev lavet i update
        if (pauseMenu.GameIsPaused == false)
        {
            rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        }
    }

    void LookAtMouse()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    } 
}