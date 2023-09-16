using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(AudioSource))]
public class ChuCha : MonoBehaviour
{
    EnemyMovement thisEnemy;
    AudioSource audioSource;
    [SerializeField] EnemyMovement otherEnemy;
    [SerializeField] Animator animator;
    [SerializeField] AudioClip audioClip;
    [SerializeField] FPC player;
    [SerializeField] float playerSlowdown;
    [SerializeField] float attackCooldown;

    float _attackCooldown;

    void Start()
    {
        thisEnemy = GetComponent<EnemyMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_attackCooldown > 0)
        {
            _attackCooldown -= Time.deltaTime;
        }
        else
        {
            player.speedModifier = 1;
            if ((transform.position - player.transform.position).magnitude < 1)
                Bite();
        }
    }

    private void Bite()
    {
        animator.Play("Attack");
        audioSource.PlayOneShot(audioClip);
        otherEnemy.isAgroed = true;
        player.speedModifier = playerSlowdown;
        _attackCooldown = attackCooldown;
    }
}


public class EnemyMovement {
    public bool isAgroed;
}

public class FPC:MonoBehaviour { 
    public float speedModifier;
}