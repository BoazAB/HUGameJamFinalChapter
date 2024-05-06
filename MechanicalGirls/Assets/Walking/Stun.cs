using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Stun
{
    public static Stun hoi;
    public List<MapMove> MapMoves = new List<MapMove>();
    private Stun()
    {

    }
    public static Stun Creation()
    {
        if(hoi == null){
            hoi = new Stun();
        }
        return hoi;
    }
    public void stunMapsAndPlayer(Walker walker){     
        walker.Stunned = true;
        ForLoop(0);
    }
    public void unStunMapsAndPlayer(Walker walker){
        walker.Stunned = false;
        ForLoop(-1);
    }
    public void ForLoop(int speed){
        for (int i = 0; i < Stun.hoi.MapMoves.Count; i ++){
            Stun.hoi.MapMoves[i].spee = speed;
        }
    }
}
