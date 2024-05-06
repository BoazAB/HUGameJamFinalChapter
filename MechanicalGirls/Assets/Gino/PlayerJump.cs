using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float Scaling;
    public KeyCode JumpKey;
    public bool Jumping;
    public Vector3 locationAtTime;
    public AnimationCurve JumpCurve;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(JumpKey) && Jumping == false){
            locationAtTime = gameObject.transform.position;
        }
    }
    public IEnumerator<WaitForNextFrameUnit> Jump(){
        time += Time.deltaTime;
        Jumping = true;
        gameObject.transform.Translate(new Vector3 (locationAtTime.x ,locationAtTime.y + JumpCurve.Evaluate(time) * Scaling, locationAtTime.z));
        yield return new WaitForNextFrameUnit();

        if(time >= JumpCurve.length){
            Jumping = false;
            time = 0;
        }
        else{
            StartCoroutine(Jump());
        }
    }
}
