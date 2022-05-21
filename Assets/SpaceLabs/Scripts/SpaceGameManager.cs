using UnityEngine;
using TMPro;

/// <summary>
/// This class implements the Singleton pattern.
/// This GameManager basically acts like a sports umpire.
/// </summary>

public class SpaceGameManager : MonoBehaviour
{
    public static SpaceGameManager _instance;
    public TextMeshProUGUI ballState;

    public enum BallState
    {
        AtPlayer,
        AtRest,
        AtEnemy,
        AtHome
    }
    public BallState bstate;

    public GameObject spaceBall;
    public GameObject[] homeGoals;

    public int radius;

    #region Singleton
    public static SpaceGameManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;

        // Uncomment when changing scenes
        //DontDestroyOnLoad(this.gameObject);
    }

    #endregion
    void Start()
    {
        SetupSpaceBall();
        SetupHomeGoals();
    }

    void Update(){
        ballState.text = bstate.ToString();

        if(bstate == BallState.AtHome){
            // Reset Ball
            SetupSpaceBall();
            bstate = BallState.AtRest;
        }
    }

    // Randomly place space ball in a certain radius from the origin
    void SetupSpaceBall()
    {
        spaceBall.transform.position = Random.insideUnitSphere * radius;
    }

    // Randomly place home goals in a certain radius from the origin
    void SetupHomeGoals()
    {
        for (int i = 0; i <= homeGoals.Length - 1; i++)
        {
            homeGoals[i].transform.localPosition = Random.insideUnitSphere * radius;
            homeGoals[i].transform.localRotation = Random.rotation;
        }
    }
}
