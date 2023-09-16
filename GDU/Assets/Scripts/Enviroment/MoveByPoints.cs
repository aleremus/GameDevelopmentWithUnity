using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> pointsOfMovement;
    [SerializeField] private float movementSpeed;
    private int _nextPoint = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if ((transform.position - pointsOfMovement[_nextPoint].position).magnitude <= 0.1f)
        {
            _nextPoint = (_nextPoint + 1) % pointsOfMovement.Count;
        }
        transform.Translate((pointsOfMovement[_nextPoint].position - transform.position).normalized * Time.deltaTime * movementSpeed, Space.World);
    }
}
