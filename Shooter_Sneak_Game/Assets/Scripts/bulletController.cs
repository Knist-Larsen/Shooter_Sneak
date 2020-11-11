using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public static Collision collision;

    // OnCollisionEnter bliver kaldt når to objecter kolidere
    private void OnCollisionEnter(Collision collision1)
    {
        // Tjekker om kuglen bliver skudt af spilleren
        if (this.tag == "PlayerBullet")
        {
            // Tjekker om kuglen rammer "Target"
            if (collision1.gameObject.tag == "Target")
            {
                // Fortæller Gamemanageren at Target er død
                GameManager.targetDead = true;
                Debug.Log("Enemy Hit");
            }
        }
        // Tjekker om kuglen bliver skudt af Fjenden
        if (this.tag == "Bullet")
        {
            // Tjekker om kuglen rammer spilleren
            if (collision1.gameObject.tag == "Player")
            {
                // Fortæller Gamemanageren at spilleren har midstet et liv
                GameManager.life--;
            }
        }
        collision = collision1;

        // Fjerner kuglen fra Scenen
        Destroy(gameObject);
    }
}
