using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;

    void Start()
    {
        Behaviour halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        } 
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Behaviour halo = (Behaviour)GetComponent("Halo");
            halo.enabled = false;
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(4);
            Behaviour halo = (Behaviour)GetComponent("Halo");
            halo.enabled = true;
        }
    }

    void OnDrawGizmoSelected()
    {
        if(AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
