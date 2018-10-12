using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Script : MonoBehaviour {

    public Transform firepoint2;
    public GameObject bulletFab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletFab, firepoint2.position, firepoint2.rotation);
    }
}
