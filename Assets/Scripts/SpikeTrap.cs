using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SpikeTrap : Trap
{
       
    private bool _isTrapActive = false;

    protected override void KillPlayer(Iplayer player)
    {
        if (_isTrapActive)
        {
            base.KillPlayer(player);
        }
        
    }

    public override void PlayAnimation(string name)
    {
        if (!_isTrapActive)
        {
            base.PlayAnimation(name);
            _isTrapActive = true;
        }
       
    }
}
