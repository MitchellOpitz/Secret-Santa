using UnityEngine;

public class Portal : MonoBehaviour
{
    public string sceneToLoad;  // Set the scene to load in the Unity Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BF_SceneLoader sceneLoader = BF_SceneLoader.Instance;

            if (sceneLoader != null)
            {
                // Call the LoadSceneByName method from the BF_SceneLoader
                sceneLoader.LoadSceneByName(sceneToLoad);
            }
            else
            {
                Debug.LogError("BF_SceneLoader not found!");
            }
        }
    }
}
