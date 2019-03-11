using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCrop : MonoBehaviour
{
    private int plantIndex;
    public int PlantIndex
    {
        set { plantIndex = value; }
    }

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);
        GetComponent<Image>().color = Color.grey;
    }

    // public 임시 추가
    public void ButtonClick()
    {
        int temp = GameManager.Instance.Select;
        GameManager.Instance.Select = plantIndex;

        transform.parent.GetChild(temp).GetComponent<Image>().color = Color.grey;
        GetComponent<Image>().color = Color.white;
    }

    // 임시 추가
    public void RemoveFocus()
    {
        GetComponent<Image>().color = Color.grey;
    }
}
