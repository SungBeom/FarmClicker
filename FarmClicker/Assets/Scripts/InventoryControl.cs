using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    public Transform plantList;
    Text[] plantCount;

    void Awake()
    {
        plantCount = plantList.GetComponentsInChildren<Text>();
    }

    void OnEnable()
    {
        for (int i = 0; i < GameManager.Instance.plantCount.Length; i++)
        {
            Debug.Log(GameManager.Instance.plantCount[i]);
            plantCount[i].GetComponentInChildren<Text>().text = "x" + GameManager.Instance.plantCount[i];
        }
    }
}
