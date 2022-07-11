using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupTEST : TotalItem
{
    [SerializeField] int _damage;
    // Start is called before the first frame update
    
    public override void Activate() //‰Û‘è
    {
        FindObjectOfType<PlayerWeapon>()._movepower = 4;
    }
}
