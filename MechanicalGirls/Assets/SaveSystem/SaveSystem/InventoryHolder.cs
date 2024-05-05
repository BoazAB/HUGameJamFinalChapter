using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryHolder : ScriptableObject
{
    public List<string> names;
    public List<int> Amounts;
    public Dictionary<string, string> Inventory = new Dictionary<string, string>();
    public List<String> ObtainableItems = new List<string>();
    public SaveSystems saveSystems;
    private void Start() 
    {
    }
    public void LoadIntoInventory(string name, string time)
    {
        Debug.Log("yo werkt echt niet man");
        if(Inventory.ContainsKey(name) == false){
            Inventory.Add(name, time);
        }
        else{
            Inventory[name] = time;
            Debug.Log("yo werkt niet man" + time);
        }
    }
    public void Pickup(string Names, string amount)
    {
        if (Inventory.ContainsKey(Names) == false){
            Inventory.Add(Names, amount);
        }
        else{
            Inventory[Names] = amount;
            Debug.Log(Names + Inventory[Names]);
        }

        Debug.Log("werkt");
    }
    public void startQuickSave()
    {

        //saveSystems.QuickSave();
    }
}
