using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _points;
    [SerializeField] private Rigidbody2D _rb;
    public event Action<int> OnPop;
    private void OnMouseDown()
    {
       _animator.SetTrigger("Pop");
        OnPop?.Invoke(_points);
        Destroy(gameObject, 0.1f);
      
    }
public void Init(float speed)
    {
        _rb.gravityScale = speed;
    }
}
