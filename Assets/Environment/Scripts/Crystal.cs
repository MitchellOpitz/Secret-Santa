using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int initialHealth = 5;  // Set initial health in the Unity Inspector
    private int currentHealth;

    public GameObject portalPrefab;

    void Start()
    {
        currentHealth = initialHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            BreakCrystal();
        }
    }

    void BreakCrystal()
    {
        // Add code here to handle the crystal breaking
        Debug.Log("Crystal has been broken!");
        // Code for crystal explosion animation
        // TO ADD LATER
        Invoke("ActivatePortalAndDestroy", 3f);
    }

    void ActivatePortalAndDestroy()
    {
        // Instantiate the portal prefab at the crystal's position
        Instantiate(portalPrefab, transform.position, Quaternion.identity);

        // Destroy the crystal GameObject
        Destroy(gameObject);
    }
}
