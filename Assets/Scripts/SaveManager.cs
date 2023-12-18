
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;
    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(SaveManager).Name;
                    instance = obj.AddComponent<SaveManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    private string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, "Loading file.json");
    }

    public void SavePlayerData(Vector2 position)
    {
        PlayerData data = new PlayerData();
        data.playerPositionX = position.x;
        data.playerPositionY = position.y;

        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, jsonData);
        Debug.Log("Player data saved!");
    }

    public Vector2 LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);

            Debug.Log("Player data loaded!");
            return new Vector2(data.playerPositionX, data.playerPositionY);
        }
        else
        {
            Debug.LogWarning("No saved player data found!");
            return Vector2.zero;
        }
    }

}
