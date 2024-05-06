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
        if (PlayerPrefs.HasKey("Time")){
            Inventory.Inventory.Add("highscore", PlayerPrefs.GetFloat("Time").ToString());
            Debug.Log("tijd" + PlayerPrefs.GetFloat("Time").ToString());
        }
        else{
            PlayerPrefs.SetFloat("Time", 0);
            Debug.Log("tijd" + PlayerPrefs.GetFloat("Time").ToString());

        }
        //saveSystems.MakeFiles();
        //saveSystems.ReadAllFiles();
        //saveSystems.LoadAmounts();

    }
    public void Save(float Amount){
        PlayerPrefs.SetFloat("Time", Amount);
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
