using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlantBtn : MonoBehaviour
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
        height = 248f;
    }

    void Change()
    {
        content.GetChild(temp).gameObject.SetActive(false);
        content.GetChild(selected).gameObject.SetActive(true);
        temp = selected;

        rt.sizeDelta =
            new Vector2(rt.sizeDelta.x, Mathf.Round((GameManager.Instance.crops[selected].cropSprites.Length + 0.5f) / 4.0f) * height + 48f);

        transform.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;

        GameManager.Instance.Category = selected;
    }

    public void Select(int num)
    {
        selected = num;
        Change();
    }
}
