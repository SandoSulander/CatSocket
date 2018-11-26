using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public int damage = 100;

    public GameControl gameControl;
    public LineRenderer lineRenderer;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && PauseMenu.GameIsPaused == false)
        {
            StartCoroutine(Shoot());
            FindObjectOfType<AudioManager>().Play("Lazer");
        }
    }


    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right *100);

        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;

    }


 
}

