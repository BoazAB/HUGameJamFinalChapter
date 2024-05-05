using UnityEngine;

public class BorderStop : PlayerMove
{

    [SerializeField] RectTransform Players, Player2, borderLeft, borderRight;


    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindWithTag("Player").GetComponent<RectTransform>();
        borderLeft = GameObject.Find("border").GetComponent<RectTransform>();
        borderRight = GameObject.Find("border").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Players.position.x >= borderRight.position.x)
        {
            horizontalInput = 0;
        }
        if (Players.position.x <= borderLeft.position.x)
        {
            horizontalInput = 0;
        }
        if (Player2.position.x >= borderRight.position.x)
        {
            horizontalInput = 0;
        }
        if (Player2.position.x <= borderLeft.position.x)
        {
            horizontalInput = 0;
        }
    }
}
