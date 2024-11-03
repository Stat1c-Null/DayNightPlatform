using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRockMan : Enemy
{
    /* public Transform[] PartrollingPoints;
     public float TargetP;*/


    // Update is called once per frame
    private void Update()
    {
        if (exploded) return;
        base.Update();

        /*if(transform.position == PartrollingPoints[TargetP].position)
        {
            IncreaseTargetPoint();


        }
          transform.position = Vector3.MoveTowards(transform.position, PartrollingPoints[0].position, speed * Time.deltaTime);
*/

        //aniamtions
        if (!IsHit)
        {
            if (speed > .01)
            {
                anim.SetFloat("Speed", 0.05f);


            }
            if (speed == 0)
            {
                anim.SetFloat("Speed", 0f);
            }
        }
        else if (IsHit)
        {
            anim.SetBool("IsHit", true);

        }

        CheckPlayerClose();
    }

    public float DistanceToExplode;
    void CheckPlayerClose()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= DistanceToExplode)
        {
            Attack();
        }
    }

    public void Damage()
    {
        StrongExplosion();
    }

    public void Attack()
    {
        StrongExplosion();
    }

    public void StrongExplosion()
    {
        StopAllCoroutines();
        StartCoroutine(ExplosionAnimation());
    }
    public float TimeToExplode;
    bool exploded;
    IEnumerator ExplosionAnimation()
    {
        exploded = true;
        isMoving = false;
        // Trigger an animation
        anim.Play("Attack");



        // Wait for the current frame to finish rendering

        yield return new WaitForSeconds(TimeToExplode);

        ExplodeCast();
    }

    public UnityEvent explode;
    public int explosionDamage = 2;

    public void ExplodeCast()
    {
        explode.Invoke();
        if (Vector3.Distance(transform.position, player.transform.position) <= DistanceToExplode)
        {
            print("IM BOTTTA BLOW");
            player.transform.GetComponent<PlayerHealth>().TakeDamage(explosionDamage);
        }
    }
}

