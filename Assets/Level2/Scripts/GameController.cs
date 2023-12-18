using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private TMP_Text _counter;
    [SerializeField] private int _carsCount;
    [SerializeField] private float _spawnDelay;
    private int _totalScore;

    public void StartGame(Button button)
    {
        button.gameObject.SetActive(false);
        LoadGameProgress();
        StartCoroutine(Spawncars(_spawnDelay));

    }
    private void OnPop(int points)
    {
        _totalScore += points;
        _counter.text = _totalScore.ToString();
    }
    private IEnumerator Spawncars(float _spawnDelay)
    {
        for (int i = 0; i < _carsCount; i++)
        {
            var car = Instantiate(_car);
            car.Init(Random.Range(-0.1f, -0.8f));
            car.transform.position = new Vector3(Random.Range(-2f, 2f), -6f, 0);
            car.OnPop += OnPop;
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
    private void SaveGameProgress()
    {
        GameProgress progress = new GameProgress(_totalScore);
        string jsonData = JsonUtility.ToJson(progress);
        PlayerPrefs.SetString("GameProgress", jsonData);
        PlayerPrefs.Save();
    }

    private void LoadGameProgress()
    {
        if (PlayerPrefs.HasKey("GameProgress"))
        {
            string jsonData = PlayerPrefs.GetString("GameProgress");
            GameProgress progress = JsonUtility.FromJson<GameProgress>(jsonData);
            _totalScore = progress.totalScore;
            _counter.text = _totalScore.ToString();
            
        }
        else
        {
   
            _totalScore = 0;
        }
    }
    private void OnApplicationQuit()
    {
        SaveGameProgress(); 
    }

    
    public void SaveProgressManually()
    {
        SaveGameProgress();
    }
}
    [System.Serializable]
    public class GameProgress
    {
        public int totalScore;
    

        public GameProgress(int score)
        {
            totalScore = score;
        }
    }


