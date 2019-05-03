using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGameMode : MonoBehaviour
{
    public int selected;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        int temp = FarmManager.Instance.GameMode;
        FarmManager.Instance.GameMode = selected;

        transform.parent.GetChild(temp).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        Debug.Log(FarmManager.Instance.GameMode);
    }
}
