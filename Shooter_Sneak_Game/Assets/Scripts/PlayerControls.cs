using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;

    public float speed;
    private float mouseX;
    private float mouseY;
    private Vector3 worldpos;
    private float cameraDif;



    // Start is called before the first frame update
    void Start()
    {
     
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move()
    {

        //Bevægelse ved WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal * speed, 0, vertical * speed);
        rb.AddForce(move);

        //Retningen player ser i
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        worldpos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, mouseY));
        Vector3 lookDirection = new Vector3(worldpos.x, player.transform.position.y, worldpos.z);
        player.transform.LookAt(lookDirection);


    }
}
