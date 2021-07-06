using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IDamageable
{
    private int _health;
    public void TakeDamage(int damageAmount)
    {
        if (damageAmount < 0) throw new ArgumentOutOfRangeException(nameof(damageAmount));
        if(_health < 0) throw new ArgumentOutOfRangeException(nameof(_health));
        
        if (_health < damageAmount)
        {
            _health = _health < damageAmount ?  0 : _health - damageAmount;
        }
    }
}
