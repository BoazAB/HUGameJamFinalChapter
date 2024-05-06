using Unity.VisualScripting;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public int spee = -1;
    public void Start()
    {
        Stun.Creation();
        Stun.hoi.MapMoves.Add(this);
    }
    public void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.position += new Vector3(0, 0, spee) * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Stun.hoi.MapMoves.Remove(this);
            Destroy(gameObject);
        }
    }
}