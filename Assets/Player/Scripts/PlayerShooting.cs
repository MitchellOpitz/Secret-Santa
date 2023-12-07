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
        float mouseButton = playerInputActions.Player.ShootMouse.ReadValue<float>();
        Vector2 joystickDirection = playerInputActions.Player.ShootJoystick.ReadValue<Vector2>();

        bool mouseButtonDown = mouseButton > 0.5f;
        bool joystickMoved = Mathf.Abs(joystickDirection.magnitude) > 0.5f;

        if (mouseButtonDown)
        {
            ShootMouse();
        }
        else if (joystickMoved)
        {
            ShootController(joystickDirection);
        }
    }

    void ShootMouse()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 fireballDirection = (mousePosition - transform.position) * 100;
            fireballDirection = fireballDirection.normalized;

            Shoot(fireballDirection);
        }
    }

    void ShootController(Vector2 direction)
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Vector2 fireballDirection = direction * 100;
            fireballDirection = fireballDirection.normalized;
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
