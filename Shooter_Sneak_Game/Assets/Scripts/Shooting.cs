using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public Vector3 bulletScale = new Vector3(1,1,1);


    // Update is called once per frame
    void Update()
    {
        //hvis venstre-musetast trykkes, så kaldes shoot-funktionen
        if (Input.GetButtonDown("Fire1"))
        {
            if (pauseMenu.GameIsPaused == false)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        //der instantieres et nyt bullet objekt med en rigidbody og en kraft
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);
        bullet.transform.localScale = bulletScale;
    }

}
