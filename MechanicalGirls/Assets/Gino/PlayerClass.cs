using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics;


public class PlayerClass : MonoBehaviour
{
    public TextMeshProUGUI stopwatchText;
    public InventoryHolder Inventory;
    public int health;
    [SerializeField] GameObject[] hearts;

    public void TakeDamage(int damage)
    {
        health -= damage;

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
            if (Stopwatch.time > Inventory.saveSystems.ReadFiles("Amount"))
            {
                SceneManager.LoadScene("Death");
                Inventory.Pickup("Highscore", Stopwatch.time.ToString());
                Inventory.saveSystems.QuickSave();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
