using System.Collections.Generic;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{

    [SerializeField] private List<GameObject> mapSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(mapSection[Random.Range(0, mapSection.Count - 1)], new Vector3(3, 3.5f, 30), Quaternion.identity);
        }
    }
}
