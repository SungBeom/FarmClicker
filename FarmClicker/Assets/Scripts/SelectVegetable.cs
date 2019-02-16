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
    }

    void ButtonClick()
    {
        GameManager.Instance.Select = plantIndex;
    }
}
