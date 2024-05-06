
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Collect : MonoBehaviour
{
    KeyCode interact;
    bool holding;

    bool coalActive;
    bool waterActive;

    bool furnaceActive;
    bool coolingActive;

    [SerializeField]
    GameObject coal;

    [SerializeField]
    GameObject water;

    GameObject heldItem;
    GameObject spawnItem;


    void Start()
    {
        if (gameObject.CompareTag("p1"))
        {
            interact = KeyCode.E;
        }
        if (gameObject.CompareTag("p2"))
        {
            interact = KeyCode.LeftControl;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (coalActive && Input.GetKeyDown(interact) && !holding || waterActive && Input.GetKeyDown(interact) && !holding)
        {
            Instantiate(spawnItem, gameObject.transform);
            holding = true;
        }

        if (furnaceActive && Input.GetKeyDown(interact) && holding)
        {
            if (GetComponentInChildren<Transform>().CompareTag("coal") == CompareTag("coal"))
            {
                foreach (Transform t in gameObject.transform)
                {
                    if (t.CompareTag("coal"))
                    {
                        Destroy(t.gameObject);
                        holding = false;
                        print("fueled");
                        break;
                    }
                }
            }
            else
            {
                return;
            }
        }
        if (coolingActive && Input.GetKeyDown(interact) && holding)
        {
            if (GetComponentInChildren<Transform>().CompareTag("water") == CompareTag("water"))
            {
                foreach (Transform t in gameObject.transform)
                {
                    if (t.CompareTag("water"))
                    {
                        Destroy(t.gameObject);
                        holding = false;
                        print("cooled");
                        break;
                    }
                }
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coalCrate"))
        {
            coalActive = true;
            spawnItem = coal;
        }
        if (collision.CompareTag("waterCrate"))
        {
            waterActive = true;
            spawnItem = water;
        }
        if (collision.CompareTag("furnace"))
        {
            furnaceActive = true;
        }
        if (collision.CompareTag("cooling"))
        {
            coolingActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("coalCrate"))
        {
            coalActive = false;
        }
        if (collision.CompareTag("waterCrate"))
        {
            waterActive = false;
        }
        if (collision.CompareTag("furnace"))
        {
            furnaceActive = false;
        }
        if (collision.CompareTag("cooling"))
        {
            coolingActive = false;
        }
    }
}
