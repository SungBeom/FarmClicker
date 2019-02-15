using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFood : MonoBehaviour
{
    public Text foodCount;
    int addCount;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);
        int.TryParse(gameObject.GetComponentInChildren<Text>().text.Substring(1), out addCount);
    }

    void ButtonClick()
    {
        int count;
        int.TryParse(foodCount.text.Substring(1), out count);

        count += addCount;
        foodCount.text = "x" + count.ToString();

        // Test용 코드
        GameManager.Instance.plantCount[0]--;
        GameManager.Instance.plantCount[1]--;
    }
}
