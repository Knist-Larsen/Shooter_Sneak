using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public static Collision collision;
    private void OnCollisionEnter(Collision collision1)
    {
        if (this.tag == "PlayerBullet")
        {
            if (collision1.gameObject.tag == "Target")
            {
                GameManager.targetDead = true;
            }
        }
        if (this.tag == "Bullet")
        {
            if (collision1.gameObject.tag == "Player")
            {
                GameManager.life--;
            }
        }
        collision = collision1;
        Destroy(gameObject);
    }
}
