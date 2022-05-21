using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyScript : MonoBehaviour
{

    [SerializeField]
    List<GameObject> enemies;
    [SerializeField]
    GameObject self;
    [SerializeField]
    GameObject laserBeam;
    [SerializeField]
    GameObject beam_L;
    [SerializeField]
    GameObject beam_R;
    [SerializeField]
    GameObject player;
    [SerializeField]
    float force;
    [SerializeField]
    float mass;
    [SerializeField]
    int health;
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    float returnDist;
    [SerializeField]
    float detectionDist;
    public Slider healthbar;

    [SerializeField]
    bool isAttacking;
    [SerializeField]
    bool isIdle;
    [SerializeField]
    bool isReturning;


    
    GameObject target;
    bool canShoot = true;

    private Vector3 contactPos;
    private Quaternion contactRot;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            target = FindClosestDists();
            if (target == null)
            {
                isAttacking = false;
            }
            else
            {
                isAttacking = true;
                isIdle = false;
            }

            if (isAttacking)
            {
                Attack(target);
            }
            else if (!isAttacking)
            {
                isReturning = ShouldReturn();
            }

            if (!isReturning && !isAttacking)
            {
                isIdle = true;
            }
        } else
        {

        }


    }

    private void FixedUpdate()
    {
        if (isReturning && ((player.transform.position - self.transform.position).magnitude > returnDist))
        {
            Vector3 direction = (player.transform.position - self.transform.position).normalized;
            isIdle = false;
            self.GetComponent<Rigidbody>().AddForce(direction, ForceMode.VelocityChange);
           
        } else if (((player.transform.position - self.transform.position).magnitude < returnDist) && !isAttacking)
        {
            self.transform.rotation = Quaternion.identity;
            self.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    
 
    void Attack(GameObject target)
    {
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - self.transform.position, Vector3.up);
        self.transform.rotation = rotation;
        
        if (canShoot) {
            StartCoroutine("WaitForShoot");
        }

    }

    private IEnumerator WaitForShoot()
    {
        Fire();
        canShoot = false;
        yield return new WaitForSeconds(1);
        canShoot = true;
    }

    GameObject FindClosestDists()
    {
        //Iterate through enemies and return the closest one
        float min = detectionDist;
        float distance;
        GameObject closest = null;
        foreach(GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                distance = (enemy.transform.position - self.transform.position).magnitude;
                if (distance <= min)
                {
                    closest = enemy;
                }
            }
        }

        if (closest == null)
        {
            return null;
        } else
        {
            return closest;
        }
    }

    bool ShouldReturn()
    {
        return (((player.transform.position - self.transform.position).magnitude) > returnDist);
    }

    private void Fire()
    {
        var transform = this.transform;
        var laserR = Instantiate(laserBeam, beam_R.transform.position, Quaternion.identity);
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(90, 0, 0);
        laserR.transform.rotation = transform.rotation * rot;
        var laserL = Instantiate(laserBeam, beam_L.transform.position, Quaternion.identity);
        laserL.transform.rotation = transform.rotation * rot;

    }


    private void CheckHealth()
    {
        if (health < 0)
        {
            Instantiate(explosion, contactPos, contactRot);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            healthbar.gameObject.SetActive(false);
            //Destroy(self);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "LaserEnemy")
        {
            health -= 1;
            healthbar.value = health;
            ContactPoint contact = collision.contacts[0];
            contactRot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            contactPos = contact.point;
            Destroy(collision.gameObject);
        }
    }
}
