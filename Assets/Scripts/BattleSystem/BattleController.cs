using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleController : MonoBehaviour
{
    public Battler player;
    public Battler playerOponnent;
    public List<Tuple<AttackAbility,DefenseTarget>> listAaDt;
    void Start()
    {
        
    }
}
