using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeLane : WalkingBaseclass
{
    public Walker walker;
    public float laneDistance;
    public float walkSpeed;
    public bool walkRight = true; 
    public AnimationCurve WalkSpeedCurve;
    public float timer;
    public Vector3 LocationAtTime;
    private bool IsCalled;
    public void  Update()
    {
        IsCalled = true;
    }
    public override void Invoke()
    {
        LocationAtTime = transform.position;
        StartCoroutine(changeLane());
    }
    public IEnumerator<WaitForNextFrameUnit> changeLane()
    {
        if (walkRight)
        {
            transform.position = new Vector3(LocationAtTime.x + (WalkSpeedCurve.Evaluate(timer) * laneDistance),0,0);
        }
        else
        {
            transform.position = new Vector3(LocationAtTime.x + -(WalkSpeedCurve.Evaluate(timer) * laneDistance),0,0);
        }
        timer += Time.deltaTime * walkSpeed;
        Debug.Log("KutError" + Time.deltaTime);
        if  (timer <= 1)
        {

            yield return new WaitForNextFrameUnit();
            StartCoroutine(changeLane());
        }
        else
        {
            timer = 0;
            walker.isWalking = false;
        }
    }

}