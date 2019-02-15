using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int[] plantCount;

    public Font mainFont;

    [System.Serializable]
    public enum Vegetable { test1, test2, test3 };
    private Vegetable select;
    public Vegetable Select
    {
        get { return select; }
        set { select = value; }
    }
}
