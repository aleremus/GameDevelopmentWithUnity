using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool active;
    [SerializeField] GameObject body;
    private bool _previousState;
    [SerializeField] float angle = 90;
    [SerializeField] float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (body.transform.rotation.eulerAngles.y < angle || body.transform.rotation.eulerAngles.y > 180)
            {
                body.transform.Rotate(Vector3.up * speed * Time.deltaTime);
            }
/*
            float y = Mathf.Clamp(body.transform.rotation.y + Time.deltaTime * speed, 0, angle);
            body.transform.rotation = new Quaternion(0,
                y,
               0,
                body.transform.rotation.w);*/
        }
        else
        {
            if (body.transform.rotation.eulerAngles.y > 0 && body.transform.rotation.eulerAngles.y < 180)
            {
                Debug.Log(body.transform.rotation.eulerAngles.y);
                body.transform.Rotate(Vector3.down * speed * Time.deltaTime);
            }
            /*float y = Mathf.Clamp(body.transform.rotation.y - Time.deltaTime * speed, 0, angle);
            body.transform.rotation = new Quaternion(0,
                y,
                0,
                body.transform.rotation.w);*/
        }

        if (_previousState == active)
            return;
        else
        {
            _previousState = active;
            if (active) Open();
            else Close();
        }
    }

    void Close()
    {
        //body.transform.Rotate(Vector3.up, 90);
    }

    void Open()
    {
        //body.transform.Rotate(Vector3.up, -90);

    }
}
