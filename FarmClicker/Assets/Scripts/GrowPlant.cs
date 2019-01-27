using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPlant : MonoBehaviour
{
    Text test;
    Image testImage;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);
        test = GetComponentInChildren<Text>();
        testImage = transform.parent.Find("Button1").Find("Image").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClick()
    {
        StartCoroutine("Growing");
    }

    IEnumerator Growing()
    {
        test.text = "Grow\n";
        for (int i = 1; i <= 5; i++)
        {
            test.text += ".";
            if (i == 1) testImage.sprite = Resources.Load<Sprite>("Test1");//
            else if (i == 3) testImage.sprite = Resources.Load<Sprite>("Test2");//
            else if (i == 5) testImage.sprite = Resources.Load<Sprite>("Test3");//
            yield return new WaitForSeconds(1.0f);
        }
        testImage.sprite = Resources.Load<Sprite>("Test");
        test.text = "Test";
    }
}
