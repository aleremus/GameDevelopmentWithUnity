using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Position => transform.position;
    private int _currentHealth;
    [SerializeField] int maxHP;
    [SerializeField] float randomEventInterval = 2;
    [SerializeField] Vector2Int damageRange;
    [SerializeField] GameObject upForwardRightPoint;
    [SerializeField] GameObject downBackwardLeftPoint;
    // Update is called once per frame

    private void Start()
    {
        _currentHealth = maxHP;
        StartCoroutine(RandomEvent());
    }
    void Update()
    {
        
    }

    IEnumerator RandomEvent()
    {
        while (_currentHealth > 0)
        {
            yield return new WaitForSeconds(randomEventInterval);
            transform.position = Teleport();
            ReceiveDamage(Random.Range(damageRange.x, damageRange.y + 1));
        }
    }

    public void ReceiveDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            Debug.Log("Player have taken " + damage + " damage!");
            _currentHealth -= damage;
            if (_currentHealth <= 0)
                Die();
        }
        
        
    }

    private void Die()
    {
        Debug.Log("Player is Dead");
    }

    private Vector3 Teleport()
    {
        return new Vector3(
            Random.Range(upForwardRightPoint.transform.position.x, downBackwardLeftPoint.transform.position.x),
            Random.Range(upForwardRightPoint.transform.position.y, downBackwardLeftPoint.transform.position.y),
            Random.Range(upForwardRightPoint.transform.position.z, downBackwardLeftPoint.transform.position.z));
    }
}
