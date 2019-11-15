using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public bool destructable = true;

    public GameObject destroyedVer;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        if (destructable == false)
        {
            Destroy(gameObject);
        }

        if (destructable == true)
        {
            Instantiate(destroyedVer, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
