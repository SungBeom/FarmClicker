using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPlant : MonoBehaviour
{
    Transform[] plantImage;
    Text test;//

    Transform inventory;

    int category;
    int[] index;

    enum GrowState { CanGrow, Growing, CanHarvest };
    GrowState[] growState;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);

        plantImage = new Transform[2];
        plantImage[0] = transform.Find("VegetableImage");
        plantImage[1] = transform.Find("FruitImage");
        plantImage[0].GetComponent<Image>().enabled = false;
        plantImage[1].GetComponent<Image>().enabled = false;

        test = GetComponentInChildren<Text>();//

        inventory = GameObject.Find("Canvas").transform.Find("InventoryView").Find("Viewport").Find("Content");

        index = new int[2];

        growState = new GrowState[2];
        growState[0] = GrowState.CanGrow;
        growState[1] = GrowState.CanGrow;
    }

    void ButtonClick()
    {
        category = FarmManager.Instance.Category;

        //  GrowState가 CanGrow상태일 때, Growing Coroutine 호출
        if (growState[category] == GrowState.CanGrow) StartCoroutine("Growing", category);

        // CanHarvest인 것을 전부 검사
        // CanGrow 상태라면 호출하지 않아도 됨 -> 개선 여지 있음
        for (int i = 0; i < plantImage.Length; i++)
        {
            if (growState[i] == GrowState.CanHarvest)
            {
                plantImage[i].GetComponent<Image>().sprite = null;
                plantImage[i].localScale = Vector3.one;
                plantImage[i].transform.position =
                    new Vector3(plantImage[i].transform.position.x, 1.1458333333f, plantImage[i].transform.position.z);
                //new Vector3(vegetableImage.transform.position.x, 1100f / Screen.height, vegetableImage.transform.position.z);
                plantImage[i].GetComponent<Image>().enabled = false;

                FarmManager.Instance.CropCount[i][index[i]]++;
                // 일정 확률로 대성공(재료가 1개가 아닌 2개가 얻어짐)
                if (Random.Range(1, 100) / 100f < FarmManager.Instance.HarvestRatio)
                {
                    Debug.Log("수확 대성공!");
                    FarmManager.Instance.CropCount[i][index[i]]++;
                }
                if (FarmManager.Instance.InventoryFlag)
                    inventory.transform.GetChild(i).GetChild(index[i]).GetComponentInChildren<Text>().text = "x" + FarmManager.Instance.CropCount[i][index[i]];
                growState[i] = GrowState.CanGrow;
            }
        }
    }

    IEnumerator Growing(int category)
    {
        growState[category] = GrowState.Growing;
        int growingCategory = category;
        index[growingCategory] = FarmManager.Instance.Select[growingCategory];

        plantImage[growingCategory].GetComponent<Image>().enabled = true;
        plantImage[growingCategory].GetComponent<Image>().sprite = FarmManager.Instance.crops[growingCategory].cropSprites[index[growingCategory]].Sprites[0];

        test.text = "Grow\n";//
        for (int i = 1; i < FarmManager.Instance.crops[growingCategory].cropSprites[index[growingCategory]].GrowTime; i++)
        {
            test.text += ".";//
            // 크기가 커지는 방식
            plantImage[growingCategory].localScale += new Vector3(0.1f, 0.1f, 0.1f);
            plantImage[growingCategory].Translate(0.0f, 20f / Screen.height, 0.0f);
            //vegetableImage.Translate(0.0f, 0.0104166667f/*20 / 1920(높이)*/, 0.0f);
            // AccelerationRatio를 이용해 식물이 자라는 속도를 증가시킴
            yield return new WaitForSeconds(FarmManager.Instance.GrowSpeed / FarmManager.Instance.AccelerationRatio);
        }
        plantImage[growingCategory].GetComponent<Image>().sprite = FarmManager.Instance.crops[growingCategory].cropSprites[index[growingCategory]].Sprites[1];
        test.text = "Test";//

        growState[growingCategory] = GrowState.CanHarvest;
    }
}
