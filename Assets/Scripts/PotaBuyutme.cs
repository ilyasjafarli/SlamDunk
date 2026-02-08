using UnityEngine;
using UnityEngine.UI;
using System.Collections;  
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Time;
    [SerializeField] private int StartTime;
    [SerializeField] private GameManager _GameManager;

    void Start()
    {
        StartCoroutine(TimeStart());
    }

    IEnumerator TimeStart ()
    {
        Time.text = StartTime.ToString();
        while(true)
        {
            yield return new WaitForSeconds(1f);
            StartTime--;
            Time.text = StartTime.ToString();
            if (StartTime == 0)
            {
                gameObject.SetActive(false);
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            gameObject.SetActive(false);
            _GameManager.PotaBuyut();
        }
    }
}
