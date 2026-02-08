using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            _GameManager.Basket();

        }
        else if (other.CompareTag("GameEnd"))
        {
            _GameManager.Kaybettin();
        }
    }
}
