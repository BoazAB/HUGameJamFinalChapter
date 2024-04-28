using UnityEngine;

public class MapTrigger : MonoBehaviour
{

    [SerializeField] private GameObject mapSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(mapSection, new Vector3(3, 3.5f, 30), Quaternion.identity);
        }
    }
}
