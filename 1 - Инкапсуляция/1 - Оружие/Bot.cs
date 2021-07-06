using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot
{
    private readonly Weapon _weaponInHands;

    public Bot(Weapon weapon)
    {
        _weaponInHands = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (_weaponInHands == null) throw new NullReferenceException(nameof(_weaponInHands));
        
        _weaponInHands.FireIfHasBullets(player);
    }
}
