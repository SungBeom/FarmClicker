using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFood : MonoBehaviour
{
    public Text foodCount;

    private int addCount;
    public int AddCount
    {
        get { return addCount; }
        set { addCount = value; }
    }

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        int count;
        int.TryParse(foodCount.text.Substring(1), out count);

        count += addCount;
        foodCount.text = "x" + count.ToString();

        // Test용 코드
        GameManager.Instance.CropCount[0][0]--;
        GameManager.Instance.CropCount[0][1]--;
    }
}
