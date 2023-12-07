using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform canvasTransform;
    public float heartSpacing = 40f;
    public Vector2 initialHeartPosition = Vector2.zero;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Image[] heartsArray;

    private void Awake()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged.AddListener(UpdateHearts);
            InitializeHearts(playerHealth.maxHealth, playerHealth.currentHealth);
        }
    }

    private void InitializeHearts(int maxHealth, int currentHealth)
    {
        if (heartsArray != null)
        {
            foreach (var heart in heartsArray)
            {
                Destroy(heart.gameObject);
            }
        }

        heartsArray = new Image[maxHealth];

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heartObj = Instantiate(heartPrefab, canvasTransform);
            RectTransform heartRect = heartObj.GetComponent<RectTransform>();

            heartRect.anchoredPosition = new Vector2(initialHeartPosition.x + heartSpacing * i, initialHeartPosition.y);

            Image heartImage = heartObj.GetComponent<Image>();
            heartsArray[i] = heartImage;

            if (i < currentHealth)
                heartImage.sprite = fullHeart;
            else
                heartImage.sprite = emptyHeart;

            heartImage.enabled = i < maxHealth;
        }
    }

    public void UpdateHearts(int maxHealth, int currentHealth)
    {
        if (maxHealth != heartsArray.Length)
        {
            InitializeHearts(maxHealth, currentHealth);
        }

        for (int i = 0; i < heartsArray.Length; i++)
        {
            if (i < currentHealth)
                heartsArray[i].sprite = fullHeart;
            else
                heartsArray[i].sprite = emptyHeart;

            heartsArray[i].enabled = i < maxHealth;
        }
    }
}
