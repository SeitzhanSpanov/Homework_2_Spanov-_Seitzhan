using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    protected virtual void KillPlayer(Iplayer player)
    {
        player.MakeDamage();
    }
    public virtual void PlayAnimation(string name)
    {

        if (_animator)
        {
            _animator.Play(name, 0, 0);
        }
        else
        {
            Debug.LogError($"{this} Animator is null");
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Iplayer>() is Iplayer player)
            {
            KillPlayer(player);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Iplayer>() is Iplayer player)
        {
            KillPlayer(player);
        }
    }
}

