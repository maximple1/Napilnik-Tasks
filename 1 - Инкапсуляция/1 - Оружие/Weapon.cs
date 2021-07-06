using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    private readonly int _damage;

    private readonly int _maxBulletsInClip;
    private int _maxBulletsInTotal;
    private int _bulletsInTotal;
    private int _totalBullets;
    private bool HasBulletsInClip => _totalBullets <= 0;
    private bool HasBulletsInTotal => _bulletsInTotal <= 0;


    public Weapon(int damage, int maxBulletsInTotal, int maxBulletsInClip, int totalBullets)
    {
        _damage = damage;
        _maxBulletsInClip = totalBullets >= maxBulletsInClip ? maxBulletsInClip : totalBullets;
        _maxBulletsInTotal = maxBulletsInTotal;
        _totalBullets = totalBullets > maxBulletsInClip ? totalBullets - maxBulletsInClip : 0;
        
    }
    private void ShootBullet()
    {
        _totalBullets --;
    }

    private void Reload()
    {
        if (_bulletsInTotal < _maxBulletsInClip)
        {
            _bulletsInTotal = 0;
            _totalBullets += _bulletsInTotal;
        }
        else
        {
            _bulletsInTotal -= (_maxBulletsInClip - _totalBullets);
            _totalBullets = _maxBulletsInClip;
        }
       
    }
    public void FireIfHasBullets(IDamageable target)
    {
        if (!HasBulletsInClip)
        {
            if (HasBulletsInTotal)
            {
                Reload();
            }
        }
        else
        {
            target.TakeDamage(_damage);
            ShootBullet();   
        }
    }
}