using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectInventoryBtn : MonoBehaviour
{
    public Transform seed;

    [Range(0, 2)]
    public int selected;
    int temp;

    RectTransform rt;
    Vector2 rtlr;
    float height;

    void Awake()
    {
        rt = seed.GetComponent<RectTransform>();
        height = 192f;
    }

    void Change()
    {
        seed.GetChild(temp).gameObject.SetActive(false);
        seed.GetChild(selected).gameObject.SetActive(true);
        temp = selected;

        rt.sizeDelta =
            new Vector2(rt.sizeDelta.x, Mathf.Round((GameManager.Instance.crops[0].cropSprites.Length + 0.5f) / 2.0f) * height);
    }

    public void Select(int num)
    {
        selected = num;
        Change();
    }
}
