using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperWeaponController : MonoBehaviour
{
    public float playerDamage = 50.0f;
    public float damageCooldown = 1.0f;

    private LineRenderer line;
    private bool canDamage;
    private Vector3 hitPoint;

    public LayerMask layers;

    private void Start()
    {
        canDamage = true;
        line = GetComponent<LineRenderer>();
        line.enabled = false;

       
    }

    private void Update()
    {
        // Hold left mouse click to fire weapon
        if (Input.GetMouseButton(0))
        {
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject hp = GameObject.FindGameObjectWithTag("GunHitPoint");
            hitPoint = new Vector3(hp.transform.position.x, hp.transform.position.y, -2);
            Vector3 point1 = new Vector3(worldpos.x - hp.transform.position.x, worldpos.y - hp.transform.position.y, -2);

            RaycastHit2D hit = Physics2D.Raycast(hitPoint, point1, Mathf.Infinity, 2313);
            Debug.Log(hit.transform.name);

            line.SetPosition(0, hitPoint);
            line.SetPosition(1, hit.point);
            line.enabled = true;

            if (canDamage)
            {
                if (hit.transform.tag == "Enemy")
                {

                    hit.transform.GetComponent<EnemyController>().TakeDamage(playerDamage);
                    canDamage = false;
                    StartCoroutine(DamageTimer());
                }
                else if (hit.transform.tag == "MiniBoss")
                {
                    hit.transform.GetComponent<EnemyController>().TakeDamage(playerDamage);
                    canDamage = false;
                    StartCoroutine(DamageTimer());
                }
                else if (hit.transform.tag == "MiniBoss2")
                {
                    hit.transform.GetComponent<EnemyController>().TakeDamage(playerDamage);
                    canDamage = false;
                    StartCoroutine(DamageTimer());
                }
                else if (hit.transform.tag == "tutorialEnemy")
                {
                    hit.transform.GetComponent<EnemyController>().TakeDamage(playerDamage);
                    canDamage = false;
                    StartCoroutine(DamageTimer());
                }
                else if (hit.transform.tag == "Boss")
                {
                    hit.transform.GetComponent<EnemyController>().TakeDamage(playerDamage);
                    canDamage = false;
                    StartCoroutine(DamageTimer());
                }
            }



        }
        else
        {
            line.enabled = false;
        }
    }

    private void FireWeapon()
    {
        
    }

    public void DamagePowerUp(float damage)
    {
        playerDamage += damage;
        StartCoroutine(destroyPowerUp(10, damage));
    }

    // Coroutine for removing power up
    IEnumerator destroyPowerUp(float seconds, float d) // parameter is how many seconds the powerup should last and the damage that was added
    {
        yield return new WaitForSecondsRealtime(seconds);
        playerDamage -= d;
    }

    IEnumerator DamageTimer() 
    {
        yield return new WaitForSecondsRealtime(damageCooldown);
        canDamage = true;
    }
}
