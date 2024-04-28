using UnityEngine;

public class MapMove : MonoBehaviour
{

    public void Update()
    {
        Move();

    }
    public void Move()
    {
        transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}