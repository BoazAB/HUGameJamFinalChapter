using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Collect : MonoBehaviour
{
    public FireScript fireScript;
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
    [SerializeField] private GameObject coalBox, waterBox, cooling, middle, furnace;
    private float distanceCoal;
    private float distanceFurnace;
    private float distanceWater;
    private float distanceCooling;
    private float distanceMiddle;

    void Start()
    {
        if (gameObject.CompareTag("p1"))
        {
            interact = KeyCode.E;

        }
        if (gameObject.CompareTag("p2"))
        {
            interact = KeyCode.RightControl;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distanceCoal = Vector3.Distance(gameObject.transform.position, coalBox.transform.position);
        distanceWater = Vector3.Distance(gameObject.transform.position, waterBox.transform.position);

        distanceFurnace = Vector3.Distance(gameObject.transform.position, furnace.transform.position);
        distanceCooling = Vector3.Distance(gameObject.transform.position, cooling.transform.position);

        distanceMiddle = Vector3.Distance(gameObject.transform.position, middle.transform.position);

        if (distanceCoal <= 100 && Input.GetKeyDown(interact) && !holding)
        {
            Instantiate(coal, gameObject.transform);
            holding = true;
        }
        if (distanceWater <= 100 && Input.GetKeyDown(interact) && !holding)
        {
            Instantiate(water, gameObject.transform);
            holding = true;
        }

        if (distanceMiddle <= 400 && Input.GetKeyDown(interact))
        {
            if (holding)
            {
                if (interact == KeyCode.E)
                {
                    foreach (Transform t in gameObject.transform)
                    {
                        if (t.CompareTag("water"))
                        {
                            t.transform.position = new Vector3(950, 444);
                            t.SetParent(middle.transform);
                            holding = false;
                            break;
                        }
                    }
                }
                if (interact == KeyCode.RightControl)
                {
                    foreach (Transform t in gameObject.transform)
                    {
                        if (t.CompareTag("coal"))
                        {
                            t.transform.position = new Vector3(950, 444);
                            t.SetParent(middle.transform);
                            holding = false;
                            break;
                        }
                    }
                }

            }
            if (!holding)
            {
                if (interact == KeyCode.E)
                {
                    foreach (Transform t in middle.transform)
                    {
                        if (t.CompareTag("coal"))
                        {
                            t.SetParent(gameObject.transform);
                            t.gameObject.transform.position = new Vector3(gameObject.transform.position.x, t.gameObject.transform.position.y);
                            holding = true;
                            break;
                        }
                    }
                }

                if (interact == KeyCode.RightControl)
                {
                    foreach (Transform t in middle.transform)
                    {
                        if (t.CompareTag("water"))
                        {
                            t.SetParent(gameObject.transform);
                            t.gameObject.transform.position = new Vector3(gameObject.transform.position.x, t.gameObject.transform.position.y);
                            holding = true;
                            break;
                        }
                    }
                }
            }
        }

        if (distanceFurnace <= 100 && Input.GetKeyDown(interact) && holding)
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
                        fireScript.SuplyCoal(30);
                        break;
                    }
                }
            }
            else
            {
                return;
            }
        }

        if (distanceCooling <= 100 && Input.GetKeyDown(interact) && holding)
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
                        fireScript.SuplyCoal(30);
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
}
