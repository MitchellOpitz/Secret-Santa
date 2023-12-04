using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float fireballSpeed = 10f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Update()
    {
        if (playerInputActions.Player.Shoot.ReadValue<float>() > 0.5f)
        {
            ShootMouse();
        }
        else if (Mathf.Abs(playerInputActions.Player.Shoot.ReadValue<Vector2>().magnitude) > 0.5f)
        {
            ShootController();
        }
    }

    public void ShootMouse()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 fireballDirection = (mousePosition - transform.position).normalized;

            Shoot(fireballDirection);
            Debug.Log("Shooting via mouse.");
        }
    }

    void ShootController()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            Vector2 fireballDirection = playerInputActions.Player.Shoot.ReadValue<Vector2>().normalized;

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
