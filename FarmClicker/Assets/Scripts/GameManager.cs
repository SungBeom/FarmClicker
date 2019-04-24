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
        // cropCount 는 카테고리가 2개, 16개의 작물
        cropCount = new int[crops.Length][];
        for (int i = 0; i < 2; i++)
            cropCount[i] = new int[crops[i].cropSprites.Length];

        // foodCount, goldAmount를 전체 GM에서 받아옴

        // automaticFoodCount는 전체 GM에 있거나, 전체 GM에서 받아오는 구도

        growSpeed = 1.0f;
        accelerationRatio = 1.0f;
        harvestRatio = 0.01f;
        cookRatio = 0.1f;

        // crop이 2개
        select = new int[crops.Length];
        for (int i = 0; i < select.Length; i++)
            select[i] = 0;

        StartCoroutine("AutomaticFarming");
    }

    public Crop[] crops;
    private int[][] cropCount;
    public int[][] CropCount
    {
        get { return cropCount; }
    }

    private ulong foodCount;
    public ulong FoodCount
    {
        get { return foodCount; }
        set { foodCount = value; }
    }

    private ulong goldAmount;
    public ulong GoldAmount
    {
        get { return goldAmount; }
        set { goldAmount = value; }
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

    public int automaticFoodCount = 1;
    public float foodGenerationCycle = 10f;

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

    // test를 위한 코드, 실제 뷰로 대체하거나 구조 변경 요망
    public Text foodText;

    IEnumerator AutomaticFarming()
    {
        int count;

        while (true)
        {
            yield return new WaitForSeconds(foodGenerationCycle);

            int.TryParse(foodText.text.Substring(1), out count);
            foodCount += (ulong)(automaticFoodCount);
            foodText.text = "x" + foodCount.ToString();
        }
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
