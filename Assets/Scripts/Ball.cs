using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private AudioSource TopSesi;
    private void OnTriggerEnter(Collider other)
    {
        TopSesi.Play();
        if (other.CompareTag("Basket"))
        {
            _GameManager.Basket(transform.position);
            TopSesi.Play();

        }
        else if (other.CompareTag("GameEnd"))
        {
            _GameManager.Kaybettin();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        TopSesi.Play();
    }
}
