using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 구조 변경 예정
public class ClickCropSeed : MonoBehaviour
{
    SelectCrop seedBtn;
    bool findSeedBtn;

    void OnEnable()
    {
        if (!findSeedBtn && transform.Find("SeedBtn1") != null)
        {
            findSeedBtn = true;
            seedBtn = transform.Find("SeedBtn1").GetComponent<SelectCrop>();
        }
        if (findSeedBtn)
        {
            // Debug.Log("good");
            seedBtn.ButtonClick();
        }
    }

    void OnDisable()
    {
        Debug.Log("SeedBtn" + GameManager.Instance.Select);
        if (transform.Find("SeedBtn" + GameManager.Instance.Select) != null)
        {
            Debug.Log(GameManager.Instance.Select);
            transform.Find("SeedBtn" + GameManager.Instance.Select).GetComponent<SelectCrop>().RemoveFocus();
        }
    }
}
