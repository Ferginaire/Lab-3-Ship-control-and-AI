using TMPro;
using UnityEngine;

/*
 * Generate asteroids withing a certain radius
 */
public class GenerateAsteroids : MonoBehaviour
{
    public int numberOfAsteroids;
    public int radius;
    public int speed;
    public GameObject asteroidPrefab;
    public Material asteroidCollEnter;
    public Material asteroidCollExit;
    public TextMeshProUGUI asteroidScoreUI;

    private GameObject asteroidGO;
    private Rigidbody _rb;
    private Asteroid _as;

    void Start()
    {   
        for(int i = 0; i < numberOfAsteroids; i++)
        {
            asteroidGO = Instantiate(asteroidPrefab);
            Transform tfm = asteroidGO.transform;

            // Add Asteroid script component
            _as = asteroidGO.AddComponent<Asteroid>();

            // Assign tag
            asteroidGO.tag = "asteroid";

            // Add Rigidbody component
            _rb = asteroidGO.AddComponent<Rigidbody>();
            _rb.useGravity = false;

            // Make collider into trigger
            _as.GetComponent<CapsuleCollider>().isTrigger = true;

            //Randomize asteroid's position, rotation and size
            tfm.SetParent(this.transform, false); //parent to AsteroidAnchor
            tfm.localPosition = Random.insideUnitSphere * radius;
            tfm.localRotation = Random.rotation;
            int size = Random.Range(10, 30);
            tfm.localScale = new Vector3(size, size, size);
            

            //Add a random force for each asteroid
            int x = Random.Range(-5, 5);
            int y = Random.Range(-5, 5);
            int z = Random.Range(-5, 5);
            asteroidGO.GetComponent<Rigidbody>().AddForce(new Vector3(x, y, z) * speed);

        }
    }


}
