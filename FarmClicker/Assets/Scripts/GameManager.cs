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

        growSpeed = 1.0f;
        accelerationRatio = 1.0f;
        harvestRatio = 0.01f;
        cookRatio = 0.1f;

        category = 0;

        // crop이 2개라 가정
        select = new int[2];
        for (int i = 0; i < 2; i++)
            select[i] = 0;
    }

    public Crop[] crops;
    private int[][] cropCount;
    public int[][] CropCount
    {
        get { return cropCount; }
    }

    [SerializeField]
    private float growSpeed;
    public float GrowSpeed
    {
        get { return growSpeed; }
    }
    private float accelerationRatio;
    public float AccelerationRatio
    {
        get { return accelerationRatio; }
        set { accelerationRatio = value; }
    }
    private float harvestRatio;
    public float HarvestRatio
    {
        get { return harvestRatio; }
        set { harvestRatio = value; }
    }
    private float cookRatio;
    public float CookRatio
    {
        get { return cookRatio; }
        set { cookRatio = value; }
    }

    public Font mainFont;

    private int category;
    public int Category
    {
        get { return category; }
        set { category = value; }
    }

    private int[] select;
    public int[] Select
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
        public CropSprite[] cropSprites;
    }

    [System.Serializable]
    public class CropSprite
    {
        // 크기를 2로 고정하는 방법을 연구해야 함
        [SerializeField]
        private Sprite[] sprites = new Sprite[2];
        public Sprite[] Sprites
        {
            get { return sprites; }
        }
        [SerializeField]
        private float growTime = 1.0f;
        public float GrowTime
        {
            get { return growTime; }
        }

        public CropSprite()
        {
            sprites = new Sprite[2];
        }
    }
}
