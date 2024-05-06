using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public bool Stunned = false;
    public int lane = 2;
    public bool isWalking;
    public WalkingBaseclass Walk1;
    public WalkingBaseclass Walk2;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        WalkingBaseclass walkers = (Input.GetKeyDown(KeyCode.Q)? Walk1 : (Input.GetKeyDown(KeyCode.P)? Walk2 : null));
        if (walkers != null && isWalking == false && Stunned == false)
        {
            if(walkers == Walk1){
                if(lane > 1){
                    lane --;
                    Walk1.Invoke();
                    isWalking = true;
                }

            }
            else{
                if(lane < 3){
                    lane++;
                    Walk2.Invoke();
                    isWalking = true;
                }

            }

        }
    }
}
