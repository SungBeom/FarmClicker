using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPlant : MonoBehaviour
{
    Transform vegetableImage;
    Text test;//

    int index;

    enum GrowState { CanGrow, Growing, CanHarvest };
    GrowState growState;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);

        vegetableImage = transform.Find("Image");
        vegetableImage.GetComponent<Image>().enabled = false;
        test = GetComponentInChildren<Text>();//

        growState = GrowState.CanGrow;
    }

    void ButtonClick()
    {
        if (growState == GrowState.CanGrow) StartCoroutine("Growing");
        else if (growState == GrowState.CanHarvest)
        {
            vegetableImage.GetComponent<Image>().sprite = null;
            vegetableImage.localScale = Vector3.one;
            // 상대적인 수치로 고쳐야 함
            vegetableImage.transform.position =
                new Vector3(vegetableImage.transform.position.x, 1100f / Screen.height, vegetableImage.transform.position.z);
            //new Vector3(vegetableImage.transform.position.x, 1.1458333333f, vegetableImage.transform.position.z);
            vegetableImage.GetComponent<Image>().enabled = false;

            GameManager.Instance.PlantCount[index]++;
            growState = GrowState.CanGrow;
        }
    }

    IEnumerator Growing()
    {
        growState = GrowState.Growing;
        index = GameManager.Instance.Select;

        vegetableImage.GetComponent<Image>().enabled = true;
        vegetableImage.GetComponent<Image>().sprite = GameManager.Instance.plants[index];

        test.text = "Grow\n";//
        for (int i = 1; i < 5; i++)
        {
            test.text += ".";//
            // 크기가 커지는 방식
            vegetableImage.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            vegetableImage.Translate(0.0f, 20f / Screen.height, 0.0f);
            //vegetableImage.Translate(0.0f, 0.0104166667f/*20 / 1920(높이)*/, 0.0f);
            yield return new WaitForSeconds(1.0f);
        }
        //수확 완료된 sprite 넣기(이차원 배열 사용)
        vegetableImage.GetComponent<Image>().sprite = GameManager.Instance.plants[index];
        test.text = "Test";//

        growState = GrowState.CanHarvest;
    }
}
