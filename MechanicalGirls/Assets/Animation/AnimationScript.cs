using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public List<Sprite> IdleAnimation;
    public List<Sprite> FlyingAnimation;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextFrame(Sprite SpirteToChange,string Animation){
        List<Sprite> AnimationTypes = (Animation == "Idle" ? IdleAnimation : (Animation == "Flying" ? FlyingAnimation : null));
        SpirteToChange = AnimationTypes[index];
        Debug.Log("animatie" + SpirteToChange);
        if (index < AnimationTypes.Count -1){
            index ++; 
        } 
        else{
            index = 0;
        }
    }

}
