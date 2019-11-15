using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meelee : MonoBehaviour
{
    public float damage = 10f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public float delay = .5f;

    public Camera fpsCam;
    public GameObject impactEffect;

    public Animator animator;

    [SerializeField]
    private float range = 3f;

    private float windUp;
    bool didHit = false;

    void Start()
    {
        windUp = delay;
    }

    // Update is called once per frame
    void Update()
    {

        windUp -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            if (windUp <= 0f && !didHit)
            {
                Hit();
                didHit = true;
                windUp = delay;
            }

        }
        if (windUp == delay)
            didHit = false;
    }


    void Hit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
