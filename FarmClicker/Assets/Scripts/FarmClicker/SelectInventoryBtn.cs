using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectInventoryBtn : MonoBehaviour
{
    public Transform content;

    [Range(0, 2)]
    public int selected;
    int temp;

    RectTransform rt;
    float height;

    void Awake()
    {
        rt = content.GetComponent<RectTransform>();
        height = 192f;
    }

    void Change()
    {
        content.GetChild(temp).gameObject.SetActive(false);
        content.GetChild(selected).gameObject.SetActive(true);
        temp = selected;

        rt.sizeDelta =
            new Vector2(rt.sizeDelta.x, Mathf.Round((FarmManager.Instance.crops[selected].cropSprites.Length + 0.5f) / 2.0f) * height);

        transform.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
    }

    public void Select(int num)
    {
        selected = num;
        Change();
    }
}
