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
        // cropCount 는 카테고리가 2개, 16개의 작물이라고 가정
        cropCount = new int[2][];

        for (int i = 0; i < 2; i++)
            cropCount[i] = new int[16];
        //cropCount = new int[crops[0].cropSprites.Length];

        category = 0;
    }

    public Crop[] crops;
    private int[][] cropCount;
    public int[][] CropCount
    {
        get { return cropCount; }
    }

    public enum plantName { };

    public Font mainFont;

    private int category;
    public int Category
    {
        get { return category; }
        set { category = value; }
    }

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

    [System.Serializable]
    public class Crop
    {
        public Sprite[] cropSprites;
    }
}
