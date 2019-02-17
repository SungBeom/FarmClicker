using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectVegetable : MonoBehaviour
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

    void ButtonClick()
    {
        int temp = GameManager.Instance.Select;
        GameManager.Instance.Select = plantIndex;

        transform.parent.GetChild(temp).GetComponent<Image>().color = Color.grey;
        GetComponent<Image>().color = Color.white;
    }
}
