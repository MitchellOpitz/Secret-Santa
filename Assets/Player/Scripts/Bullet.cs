using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;  // Set the damage value in the Unity Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided");
        CheckCrystalDamage(other);
    }

    private void CheckCrystalDamage(Collider2D collider)
    {
        if (collider.CompareTag("Crystal"))
        {
            Crystal crystal = collider.GetComponent<Crystal>();
            if (crystal != null)
            {
                crystal.TakeDamage(damage);
                Destroy(gameObject);  // Destroy the bullet on impact
            }
        }
    }
}
