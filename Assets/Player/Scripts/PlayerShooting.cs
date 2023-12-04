using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float fireballSpeed = 10f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            ShootMouse();
        }
        else if ((Mathf.Abs(Input.GetAxis("Fire1")) > 0.1f || Mathf.Abs(Input.GetAxis("Fire2")) > 0.1f) && Time.time > nextFireTime)
        {
            ShootController();
        }
    }

    void ShootMouse()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 fireballDirection = (mousePosition - transform.position).normalized;

            Shoot(fireballDirection);
        }
    }

    void ShootController()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            Vector2 fireballDirection = new Vector2(Input.GetAxis("Fire1"), Input.GetAxis("Fire2")).normalized;

            Shoot(fireballDirection);
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.velocity = direction * fireballSpeed;
    }
}
