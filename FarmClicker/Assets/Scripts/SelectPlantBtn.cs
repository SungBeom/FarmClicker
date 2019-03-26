using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlantBtn : MonoBehaviour
{
    public Transform seed;

    [Range(0, 2)]
    public int selected;
    int temp;

    void Change()
    {
        seed.GetChild(temp).gameObject.SetActive(false);
        seed.GetChild(selected).gameObject.SetActive(true);
        temp = selected;

        GameManager.Instance.Category = selected;
    }

    public void Select(int num)
    {
        selected = num;
        Change();
    }
}
