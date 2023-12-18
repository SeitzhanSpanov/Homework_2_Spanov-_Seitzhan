using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobController : MonoBehaviour, Iplayer
{
    public event Action OnKilled;
    public event Action OnlevelComplete;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _JumpButton;
    [SerializeField] private float _JumpForce;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteBob;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _dampingSpeed;
 public void MakeDamage()
    {
        _rb.AddForce(Vector2.up * _JumpForce);
        GetComponent<Collider2D>().isTrigger = true;
        OnKilled?.Invoke();
        enabled = false;
    }
    
  
    void Update()
    {
        CharacterMovment();
    }
    private void FixedUpdate()
    {
        _camera.transform.position = Vector3.Lerp(new Vector3(_camera.transform.position.x,_camera.transform.position.y,-1), transform.position,Time.deltaTime * _dampingSpeed);  
    }
    private void CharacterMovment()
    {
        float InputDir = Input.GetAxis("Horizontal");
        _spriteBob.flipX = InputDir < 0;

        _animator.SetFloat("MoveSpeed", Mathf.Abs(InputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + InputDir, transform.position.y, 0), Time.deltaTime * _moveSpeed);
        if (Input.GetKeyDown(_JumpButton))
        {
            _rb.AddForce(Vector2.up * _JumpForce);
        }
    }
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
        Vector3 loadedPosition = saveManager.LoadPlayerData();
        transform.position = loadedPosition;
    }
}
[Serializable]
public class PlayerData
{
    public float playerPositionX;
    public float playerPositionY;
    
}