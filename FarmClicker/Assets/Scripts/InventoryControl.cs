using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    public Transform plantList;

    void OnEnable()
    {
        if (GameManager.Instance.InventoryFlag)
        {
            for (int i = 0; i < GameManager.Instance.plants.Length; i++)
                plantList.GetChild(i).GetComponentInChildren<Text>().text = "x" + GameManager.Instance.PlantCount[i];
        }
    }
}
