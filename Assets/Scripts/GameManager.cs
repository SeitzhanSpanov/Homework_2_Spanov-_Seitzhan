using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private BobController _bobController;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _winScreen;
    private void OnEnable()
    {
        _bobController.OnKilled += _bobController_OnKilled;

    }   


    private void OnDisable()
    {
        _bobController.OnKilled -= _bobController_OnKilled;
    }

    private void _bobController_OnKilled()
    {
        _endScreen.SetActive(true);
    }
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
   public void LvLComplete()
    {
        _winScreen.SetActive(true);
        _bobController.enabled = false;
    }
}


