using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{

    // Start is called before the first frame update
    public SaveSystems saveSystems;
    public InventoryHolder Inventory;
    void Start()
    {
        saveSystems.MakeFiles();
        //saveSystems.ReadAllFiles();
        saveSystems.LoadAmounts();
    }
    public IEnumerator<WaitForSeconds> AutoSave()
    {
        yield return new WaitForSeconds(6);
//        Inventory.startQuickSave();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnApplicationQuit()
    {
        Inventory.startQuickSave();
    }
}
