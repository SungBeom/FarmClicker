using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCookBtn : MonoBehaviour
{
    public Transform content;

    [Range(0, 2)]
    public int selected;
    int temp;

    RectTransform rt;
    float height;

    int[] recipeCount;

    void Awake()
    {
        rt = content.GetComponent<RectTransform>();
        height = 192f;

        recipeCount = new int[2];
        recipeCount[0] = rt.GetChild(0).childCount;
        recipeCount[1] = rt.GetChild(1).childCount;

        rt.sizeDelta =
            new Vector2(rt.sizeDelta.x, recipeCount[0] * height);
    }

    void Change()
    {
        content.GetChild(temp).gameObject.SetActive(false);
        content.GetChild(selected).gameObject.SetActive(true);
        temp = selected;

        rt.sizeDelta =
            new Vector2(rt.sizeDelta.x, recipeCount[selected] * height);

        transform.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
    }

    public void Select(int num)
    {
        selected = num;
        Change();
    }
}
