using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject tempGM = new GameObject("GameManager");
                instance = tempGM.AddComponent<GameManager>();
                DontDestroyOnLoad(tempGM);
            }
            return instance;
        }
    }

    [System.Serializable]
    public enum Vegetable { test1, test2, test3 };
    private Vegetable select;
    public Vegetable Select
    {
        get { return select; }
        set { select = value; }
    }

    // plant에 해당하는 배열 -> 개수 넣기
    public int[] plantCount;
}
