
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("---LEVEL OBJELERI---")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Pota;
    [SerializeField] private GameObject PotaBuyume;
    [SerializeField] private GameObject[] OzellikOlusmaNoktalari;
    [SerializeField] private AudioSource[] Sesler;
    [SerializeField] private ParticleSystem[] Efektler;
    SceneManager scene;

    [Header("---UI OBJELERI---")]
    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;
    [SerializeField] private int AtilmasiGerekenTop;
    [SerializeField] private GameObject[] Panels;
    [SerializeField] private TextMeshProUGUI LevelText;
    int BasketCount;
    float ParmakPozX;

    void Start()
    {
        LevelText.text = "LEVEL : "+SceneManager.GetActiveScene().name;
        for (int i= 0; i< AtilmasiGerekenTop; i++)
        {
            if(i < AtilmasiGerekenTop)
            {
                GorevGorselleri[i].gameObject.SetActive(true);
            }
        }
        //Invoke("Ozellikolussun", 3f);
    }

void Ozellikolussun()
    {
        int RandomSayi = Random.Range (0, OzellikOlusmaNoktalari.Length-1);
        PotaBuyume.transform.position = OzellikOlusmaNoktalari[RandomSayi].transform.position;
        PotaBuyume.SetActive(true);
    }
    void Update()
    {
        if(Time.timeScale!=0)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10)); 
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                    ParmakPozX = TouchPosition.x - Platform.transform.position.x;
                    break;
                    case TouchPhase.Moved:
                    if (TouchPosition.x - ParmakPozX > -1.1 && TouchPosition.x - ParmakPozX < 1.1)
                        {
                            Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3
                            (TouchPosition.x - ParmakPozX,
                            Platform.transform.position.y, Platform.transform.position.z), 5f);
                        }
                    break;
                }
            }
        }
    }
    public void Basket(Vector3 Poz)
    {
        BasketCount++;
        GorevGorselleri[BasketCount - 1].sprite = GorevTamamSprite;
        Efektler[0].transform.position = Poz;
        Efektler[0].gameObject.SetActive(true);
        Sesler[4].Play();

        if(BasketCount == AtilmasiGerekenTop)
        {
            Kazandin();
        }
        if (BasketCount ==1)
        {
            Ozellikolussun();
        }
    }

void Kazandin()
    {
        Panels[1].SetActive(true);
        Sesler[2].Play();
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        Time.timeScale = 0;
    }

    public void Kaybettin()
    {
        Panels[2].SetActive(true);
        Sesler[1].Play();
        Time.timeScale = 0;
    }
    

    public void PotaBuyut()
    {
        Efektler[1].transform.position = Pota.transform.position;
        Efektler[1].gameObject.SetActive(true);
        Sesler[0].Play();
        Pota.transform.localScale = new Vector3(55f, 55f, 55f);
    }

public void ButonIslemleri(string Deger)
    {
        switch(Deger)
        {
            case "Pause":
            Time.timeScale = 0;
            Panels[0].SetActive(true);
            break;
            case "Resume":
            Time.timeScale = 1;
            Panels[0].SetActive(false);
            break;
            case "Try Again":
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
            // Panels[0].SetActive(false);
            break;
            case "Next":
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            Time.timeScale = 1;
            break;
            case "Settings":
            // Ayarlar panelini duzelt
            break;
            case "Quit":
            Application.Quit(); //emin misin panelini yarada bilersen, RunControl oyun tutoriallarina bax
            break;
        }
    }
}
