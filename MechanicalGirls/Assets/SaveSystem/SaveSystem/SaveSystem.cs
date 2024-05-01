
using UnityEngine;
using System.IO;

using UnityEditor;
using System.Collections.Generic;
using System.Globalization;

[CreateAssetMenu]
public class SaveSystems : ScriptableObject
{
    public List<int> amounts;

    public InventoryHolder Inventory;
    // Start is called before the first frame update
    void Start()
    {
        //MakeFiles("Amount");

        //ReadAllFiles();
    }
    public void LoadAmounts()
    {
        var FilePath = "/Amount" + "Amount" + ".txt";
        //return int.Parse(File.ReadAllText(Application.dataPath + FilePath));
        using (var sr = new StreamReader(Application.dataPath + FilePath)) {
            for (int i = 1; i <= Inventory.ObtainableItems.Count;)
            {
                string higghscore = sr.ReadLine();
                Debug.Log("Item" + higghscore);
                Inventory.LoadIntoInventory(Inventory.ObtainableItems[i - 1], higghscore);
                i++;
            }

        }

    }
    public void MakeAllFiles()
    {
        for(int i = 0; i <= Inventory.ObtainableItems.Capacity; i++)
        {
            Debug.Log("Werkt");
            MakeFiles(Inventory.ObtainableItems[i]);
        }
    }
    public void ReadAllFiles()
    {
        for(int i = 0; i <= Inventory.ObtainableItems.Capacity; i++)
        {
            Debug.Log(ReadFiles("Amount", i));

        }
    }
    public void Save(int Amount, string name)
    {
        var FilePath = "/Amount" + name + ".txt";
        if(!File.Exists(Application.dataPath + FilePath))
        {
            File.WriteAllText(Application.dataPath + FilePath, "" + Amount);
        }
        else
        {
            using (var Writer = new StreamWriter(Application.dataPath + FilePath, false))
            {
                Writer.WriteLine(Amount);
                Debug.Log(Application.dataPath+ FilePath);
            }
        }
    }
    public void QuickSave()
    {
        for (int i = 1; i <= Inventory.ObtainableItems.Count; i++)
        {
            Debug.Log(Inventory.ObtainableItems[i - 1] + Inventory.Inventory[Inventory.ObtainableItems[i - 1]]);
        }
        var FilePath = "/Amount" + "Amount" + ".txt";
        //Writer.WriteLine(Amount);
        Debug.Log(Application.dataPath+ FilePath);
        using (var sr = new StreamWriter(Application.dataPath + FilePath, false)) {
            Debug.Log("JapaneseCalendar");
            for (int i = 1; i <= Inventory.ObtainableItems.Count; i++)
            {
                Debug.Log(Inventory.ObtainableItems[i - 1] + Inventory.Inventory[Inventory.ObtainableItems[i - 1]]);
                sr.WriteLine(Inventory.Inventory[Inventory.ObtainableItems[i - 1]]);
            }
        }
        Debug.Log("ALGEMAAKT");
        
        Inventory.names.Clear();
        Inventory.Amounts.Clear();
    }
    public void MakeFiles(string name)
    {
        Debug.Log("hiergekomen");
        var FilePath = "/Amount" + "Amount" + ".txt";

        if(!File.Exists(Application.dataPath + FilePath))
        {
            //File.WriteAllLines(Application.dataPath + FilePath, "0");
            File.Create(Application.dataPath + FilePath);
        }
        else
        {
            
            //using (var sr = new StreamWriter(Application.dataPath + FilePath)) {
             //   for (int i = 1; i <= Inventory.ObtainableItems.Capacity; i++)
               //     sr.WriteLine("" + Inventory.ObtainableItems.Capacity);
            //}
            //Debug.Log("ALGEMAAKT");
            
        }
    }
    public int ReadFiles(string name, int line)
    {
        var FilePath = "/Amount" + name + ".txt";
        //return int.Parse(File.ReadAllText(Application.dataPath + FilePath));
        using (var sr = new StreamReader(Application.dataPath + FilePath)) {
            for (int i = 1; i < line; i++)
                sr.ReadLine();
            return int.Parse(sr.ReadLine());
        }

    }
}
