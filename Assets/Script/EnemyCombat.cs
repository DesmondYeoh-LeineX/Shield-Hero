using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public static EnemyCombat instance {get; private set;}

    [Header("Variables")]
    public List<GameObject> EnemyMobs = new List<GameObject>();
    private Animator enemyAnim;


    [Header("Debugger")]
    private GameObject currentMob;
    private EnemyStats enemyStats;
    private float timeRemaining;
    private bool timerRunning;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMob = EnemyMobs[0];
        enemyAnim = currentMob.GetComponent<Animator>();
        enemyStats = currentMob.GetComponent<EnemyStats>();
        timeRemaining = enemyStats.GetEnemyAttackInterval();
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        AttackTimer();
    }

    void AttackTimer()
    {
        if(timerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timerRunning = false;
                Attack();
            }
        }
    }

    void Attack()
    {
        int rand = Random.Range(0, 2);
        //Debug.Log(rand);
        if(rand == 0) // Left
        {
            enemyAnim.SetTrigger("LeftAttack");
            //Attack left
        }
        else 
        {
            enemyAnim.SetTrigger("RightAttack");
            //attack Right
        }
    }

    public void ResetTimer()
    {
        timeRemaining = enemyStats.GetEnemyAttackInterval();
        timerRunning = true;
    }

}
