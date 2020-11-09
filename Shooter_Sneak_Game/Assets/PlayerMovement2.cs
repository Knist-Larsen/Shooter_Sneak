using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    Vector3 move;
    public float speed;
    GameObject player;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        controller = gameObject.AddComponent<CharacterController>(); // Tilføjer en CharacterController til spilleren
    }

    // Update is called once per frame
    void Update()
    {
        //opretter bevægelsesvektor ud fra WASD eller piletaster. .normalized sørger for, at spilleren ikke går hurtigere, når man går skråt (fx trykker fx både W og D ned samtidig)
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (pauseMenu.GameIsPaused == false)
        {
            LookAtMouse();
        }
    }

    private void FixedUpdate()
    {
        if (pauseMenu.GameIsPaused == false)
        {
            if (controller.isGrounded && move.y < 0f)
            {
                move.y = 0f;
            }
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
