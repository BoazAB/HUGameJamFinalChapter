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

    public float Duration;
    public void Activate(){
        //StartCoroutine(StunMapAndPlayer());
    }

}
