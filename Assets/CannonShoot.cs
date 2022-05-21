using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public GameObject laserBeam;
    public GameObject weaponHead;
    public GameObject turret;
    public GameObject player;
    public float detectDistance;
    public float distToPlayer;
    bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = (player.transform.position - turret.transform.position).magnitude;
        if (distToPlayer < detectDistance)
        {
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - turret.transform.position, Vector3.up);
            turret.transform.rotation = rotation;

            if (canShoot)
            {
                canShoot = false;
                StartCoroutine("Shoot");
            }
        }
    }

    IEnumerator Shoot()
    {
        
        Fire();
        yield return new WaitForSeconds(1);
        canShoot = true;
    }


    private void Fire()
    {
        var transform = this.transform;
        var laser = Instantiate(laserBeam, weaponHead.transform.position, Quaternion.identity);
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(90, 0, 0);
        laser.transform.rotation = transform.rotation * rot;
        

    }
}
