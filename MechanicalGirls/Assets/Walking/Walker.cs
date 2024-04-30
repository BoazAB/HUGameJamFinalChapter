using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public WalkingBaseclass Walk1;
    public WalkingBaseclass Walk2;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Walk1.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Walk2.Invoke();
        }
    }
}
