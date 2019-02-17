using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
    //public static GameManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            GameObject tempGM = new GameObject("GameManager");
    //            instance = tempGM.AddComponent<GameManager>();
    //            DontDestroyOnLoad(tempGM);
    //        }
    //        return instance;
    //    }
    //}

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        plantCount = new int[plants.Length];
    }

    public Sprite[] plants;
    private int[] plantCount;
    public int[] PlantCount
    {
        get { return plantCount; }
    }

    public enum plantName { };

    public Font mainFont;

    private int select;
    public int Select
    {
        get { return select; }
        set { select = value; }
    }

    private bool inventoryFlag = false;
    public bool InventoryFlag
    {
        get { return inventoryFlag; }
        set { inventoryFlag = value; }
    }
}
