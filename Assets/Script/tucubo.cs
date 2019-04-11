using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class tucubo : MonoBehaviour
{
    DatabaseReference databaseReference;
    float inc = 0.01f;
    public float speed;
    
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ejemplounity.firebaseio.com/");
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        print("Ref Obtenida: " + databaseReference);

        //FirebaseDatabase.DefaultInstance.GetReference("xinc").ValueChanged += GestionarX;
        //FirebaseDatabase.DefaultInstance.GetReference("yinc").ValueChanged += GestionarY;
    }

    //public void GestionarX(object sender, ValueChangedEventArgs args)
    //{
    //    if (args.DatabaseError != null)
    //    {
    //        Debug.LogError(args.DatabaseError.Message);
    //        return;
    //    }
    //    //print(args.Snapshot.GetValue(true));
    //    var x = args.Snapshot.GetValue(true);
    //    print(x);
    //    print("GetX: " + x);
    //    transform.position = new Vector3((float)Convert.ToDouble(x),transform.position.y, 0);


    //}
    //public void GestionarY(object sender, ValueChangedEventArgs args)
    //{
    //    if (args.DatabaseError != null)
    //    {
    //        Debug.LogError(args.DatabaseError.Message);
    //        return;
    //    }
    //    //print(args.Snapshot.GetValue(true));
    //    var y = args.Snapshot.GetValue(true);
    //    print("GetY: " + y);
    //    transform.position = new Vector3(transform.position.x, (float)Convert.ToDouble(y), 0);
    //}
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
            MoverHorizontal(-inc);
        }
    }

    private void MoverHorizontal(float _inc)
    {
        transform.Translate(_inc, 0, 0);
        print("xinc: " + transform.position.x);
        databaseReference.Child("xinc").SetValueAsync(transform.position.x * Time.deltaTime * speed);

    }

    private void MoverVertical(float _inc)
    {
        transform.Translate(0, _inc, 0);
        print("yinc: " + transform.position.y);
        databaseReference.Child("yinc").SetValueAsync(transform.position.y * Time.deltaTime * speed);
    }
}
