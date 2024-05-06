using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public PlayerClass playerClass;
    public Walker walker;
    public float time;
    public float KaputTime = 30;
    public float DamageInterval;
    public bool Kaput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= KaputTime){
            if(Kaput == false){
                Kaput = true;
                Stun.hoi.stunMapsAndPlayer(walker);
                playerClass.TakeDamage(1, true);
                StartCoroutine(DamageWhileStunned());
            }
        }
        else{
            time += Time.deltaTime;
        }
    }
    public IEnumerator<WaitForSeconds> DamageWhileStunned(){
        yield return new WaitForSeconds(DamageInterval);
        if(Kaput == true){
            playerClass.TakeDamage(1, true);
            StartCoroutine(DamageWhileStunned());
        }
    }
}
