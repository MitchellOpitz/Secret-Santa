using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int initialHealth = 5;  // Set initial health in the Unity Inspector
    private int currentHealth;

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
        Destroy(gameObject);  // Destroy the crystal GameObject, you can customize this action
    }
}
