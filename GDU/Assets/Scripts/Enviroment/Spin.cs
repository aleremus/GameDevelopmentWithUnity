using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] Vector3 rotationDirection;
    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDirection.normalized, rotationSpeed * Time.deltaTime, Space.World);
        
    }



}
