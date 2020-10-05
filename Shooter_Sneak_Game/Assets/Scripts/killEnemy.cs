using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killEnemy : MonoBehaviour
{
    /*
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    */

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            print("Hit");
            //animator.SetTrigger("Dead");
            Destroy(gameObject);
        }
        
    }
}
