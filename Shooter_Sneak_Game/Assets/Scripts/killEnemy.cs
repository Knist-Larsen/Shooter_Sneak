using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class killEnemy : MonoBehaviour
{
    public GameObject weapon;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "PlayerBullet")
        {
            print("Hit");
            animator.SetTrigger("Dead");
            weapon.AddComponent<BoxCollider>();
            weapon.AddComponent<Rigidbody>();
            Destroy(gameObject.GetComponent<NavMeshAgent>());
            Destroy(gameObject.GetComponent<enemyController>());
            Destroy(gameObject.GetComponent<CapsuleCollider>());
        }
        
    }
}
