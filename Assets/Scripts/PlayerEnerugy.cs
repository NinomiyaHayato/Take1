using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnerugy : TotalItem //�ۑ�
{
    int _healcount;
    // Start is called before the first frame update
    public override void Activate()
    {
        FindObjectOfType<PlayerHP>()._hp += 100; 
    }
}
