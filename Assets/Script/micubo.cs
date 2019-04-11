using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class micubo : MonoBehaviour
{
    float inc = 0.01f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoverVertical(inc);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoverVertical(-inc);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoverHorizontal(inc);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoverHorizontal(inc);
        }
    }

    private void MoverHorizontal(float _inc)
    {
        transform.Translate(_inc, 0, 0);

    }
    private void MoverVertical(float _inc)
    {
        transform.Translate(0, _inc, 0);
    }
}
