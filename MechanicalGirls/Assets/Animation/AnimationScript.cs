using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AnimationScript : MonoBehaviour
{
    public int frameInBetween;
    public int frameIndex;
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
    public void nextFrame(UnityEngine.UI.Image SpirteToChange,string Animation){
        List<Sprite> AnimationTypes = (Animation == "Idle" ? IdleAnimation : (Animation == "Flying" ? FlyingAnimation : null));
        SpirteToChange.sprite = AnimationTypes[index];
        Debug.Log("animatie" + SpirteToChange);
        frameIndex ++;
        if (index < AnimationTypes.Count -1){
            if (frameIndex == frameInBetween){
                index ++;       
            }

        } 
        else{
            index = 0;
        }
        if (frameIndex >= frameInBetween){
            frameIndex = 0;
        }
    }

}
