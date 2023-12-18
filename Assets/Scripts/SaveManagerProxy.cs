using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManagerProxy : MonoBehaviour
{
    private SaveManager saveManager;

    private void Awake()
    {
        saveManager = SaveManager.Instance;
    }

    public void SaveButtonClicked()
    {
        saveManager.SavePlayerData(transform.position);
    }

    public void LoadButtonClicked()
    {
        Vector2 loadedPosition = saveManager.LoadPlayerData();
        transform.position = loadedPosition;
    }
}
