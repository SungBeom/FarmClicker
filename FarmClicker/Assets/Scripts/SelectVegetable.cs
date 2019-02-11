using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectVegetable : MonoBehaviour
{
    public GameManager.Vegetable vegetable;

    public void Select()
    {
        GameManager.Instance.Select = vegetable;
    }
}
