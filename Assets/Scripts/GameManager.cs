using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Platform;
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
