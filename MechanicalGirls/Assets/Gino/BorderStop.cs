using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderStop : MonoBehaviour
{
    public PlayerMove Player1Move, Player2Move;
    [SerializeField] RectTransform Player1, Player2, borderLeft, borderRight;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void WaitPlease(){
        if (Player1.position.x >= borderRight.position.x && Player1Move.horizontalInput == 1)
        {
            Player1Move.horizontalInput = 0;
        }
        if (Player1.position.x <= borderLeft.position.x && Player1Move.horizontalInput == -1)
        {
            Player1Move.horizontalInput = 0;
        }
        if (Player2.position.x >= borderRight.position.x && Player2Move.horizontalInput == 1)
        {
            Player2Move.horizontalInput = 0;
        }
        if (Player2.position.x <= borderLeft.position.x && Player2Move.horizontalInput == -1)
        {
            Player2Move.horizontalInput = 0;
        }
    }
    public void WaitPleaseXLeft(){

    }
}

