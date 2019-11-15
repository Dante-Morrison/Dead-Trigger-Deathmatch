using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float maxAmmo = 10f;
    public float currentAmmo;

    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public GameObject ThrowPoint;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo != 0)
        {
            ThrowGrenade();
            currentAmmo--;
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, ThrowPoint.transform.position, ThrowPoint.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(ThrowPoint.transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
