using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    private float hitForce = 400f;

    public Camera fpsCam;
    public GameObject impact;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }

    public void Shoot()
    {
        RaycastHit hit;

        // Raycast from position of the camera to the direction of th ray
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            Target tar = hit.transform.GetComponent<Target>();

            if (tar != null)
            {
                tar.Damage(damage);
                hit.rigidbody.AddForce(-hit.normal * hitForce);

            }

            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
