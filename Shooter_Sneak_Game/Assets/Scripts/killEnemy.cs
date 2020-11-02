using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killEnemy : MonoBehaviour
{
    public GameObject weapon;
    Animator animator;
    Vector3 weaponPos;

    private void Start()
    {
        animator = GetComponent<Animator>();
        weaponPos = weapon.transform.position;
    }
    

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "PlayerBullet")
        {
            print("Hit");
            animator.SetTrigger("Dead");
            //weaponPos.y = 0;
            weapon.AddComponent<BoxCollider>();
            weapon.AddComponent<Rigidbody>();
            //Destroy(weapon);
            //Destroy(gameObject);
        }
        
    }
}
