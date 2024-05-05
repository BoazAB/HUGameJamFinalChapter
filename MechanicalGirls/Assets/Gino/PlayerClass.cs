using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;


public class PlayerClass : MonoBehaviour
{
    public Walker walker;
    public TextMeshProUGUI stopwatchText;
    public InventoryHolder Inventory;
    public int health;
    [SerializeField] GameObject[] hearts;
    public Stun stun;
    public SaveHandler saveHandler;
    public float Duration = 1;
    public void TakeDamage(int damage, bool Stunned)
    {
        health -= damage;
        if(Stunned == false){
            StartCoroutine(StunMapAndPlayer());      
        }

        if (health == 1)
        {
            hearts[1].SetActive(false);
            Destroy(hearts[1]);
        }
        if (health == 2)
        {
            Destroy(hearts[2]);
        }
        if (health == 0)
        {
            Destroy(hearts[0]);
            SceneManager.LoadScene("Death");
            if (Stopwatch.time > PlayerPrefs.GetFloat("highscore"))
            {
                SceneManager.LoadScene("Death");
                PlayerPrefs.SetFloat("Time",Stopwatch.time);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1, false);
            Destroy(other.gameObject);
        }
    }
    public IEnumerator<WaitForSeconds> StunMapAndPlayer()
    {
        Stun.hoi.stunMapsAndPlayer(walker);

        yield return new WaitForSeconds(Duration);

        Stun.hoi.unStunMapsAndPlayer(walker);
    }
}
