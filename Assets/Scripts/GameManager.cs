using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Platform;
    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;
    [SerializeField] private int AtilmasiGerekenTop;
    int BasketCount;

    void Start()
    {
        for (int i= 0; i< AtilmasiGerekenTop; i++)
        {
            if(i < AtilmasiGerekenTop)
            {
                GorevGorselleri[i].gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(Platform.transform.position.x > -1.1)
            Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x -0.05f,
             Platform.transform.position.y, Platform.transform.position.z), 0.50f);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            if(Platform.transform.position.x < 1.1)
            Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x +0.05f,
             Platform.transform.position.y, Platform.transform.position.z), 0.50f);
        }
    }
    public void Basket()
    {
        BasketCount++;
        GorevGorselleri[BasketCount - 1].sprite = GorevTamamSprite;

        if(BasketCount == AtilmasiGerekenTop)
        {
            Debug.Log("Görev Tamamlandi");
        }
    }

    public void Kaybettin()
    {
        Debug.Log("Kaybettin");
    }
}
