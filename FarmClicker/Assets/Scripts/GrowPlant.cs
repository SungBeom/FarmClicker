using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPlant : MonoBehaviour
{
    Text test;
    Image testImage;
    Transform image;

    int num;

    bool canGrow;
    // 수확 가능 여부를 나타내는 변수도 필요
    enum GrowState { CanGrow, Growing, CanHarvest };
    GrowState growState;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);
        test = GetComponentInChildren<Text>();
        // testImage = transform.parent.Find("Button1").Find("Image").GetComponent<Image>();
        testImage = GetComponentInChildren<Image>();
        image = transform.Find("Image");
        num = 2;    // test 용
        image.GetComponent<Image>().enabled = false;
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Test" + num + "-1");

        canGrow = true;//
        growState = GrowState.CanGrow;
    }

    void ButtonClick()
    {
        if (growState == GrowState.CanGrow) StartCoroutine("Growing");
        else if (growState == GrowState.CanHarvest)
        {
            Debug.Log("Harvest!");
            image.GetComponent<Image>().sprite = null;
            image.localScale = Vector3.one;
            image.transform.position = new Vector3(image.transform.position.x, 1.1458333333f, image.transform.position.z);
            image.GetComponent<Image>().enabled = false;

            growState = GrowState.CanGrow;
        }
    }

    IEnumerator Growing()
    {
        Debug.Log(image.transform.position.y);
        canGrow = false;//
        growState = GrowState.Growing;
        image.GetComponent<Image>().enabled = true;
        Debug.Log("Test" + GameManager.Instance.Select + "-1");
        num = (int)GameManager.Instance.Select + 1;
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Test" + num + "-1");

        test.text = "Grow\n";
        for (int i = 1; i <= 5; i++)
        {
            test.text += ".";
            //if (i == 1) testImage.sprite = Resources.Load<Sprite>("Test1");//
            //else if (i == 3) testImage.sprite = Resources.Load<Sprite>("Test2");//
            //else if (i == 5) testImage.sprite = Resources.Load<Sprite>("Test3");//
            image.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            image.Translate(0.0f, 0.0104166667f/*2 / 1920(높이)*/, 0.0f);
            yield return new WaitForSeconds(1.0f);
        }
        // testImage.sprite = Resources.Load<Sprite>("Test");
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Test" + num + "-2");
        test.text = "Test";
        canGrow = true;//
        growState = GrowState.CanHarvest;
    }
}
