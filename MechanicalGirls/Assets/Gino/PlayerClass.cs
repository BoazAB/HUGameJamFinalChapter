using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public int health;
    [SerializeField] GameObject[] hearts;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }
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
        }
    }
}
