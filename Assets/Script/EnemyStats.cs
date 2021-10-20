using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float attackInterval;

    public float GetEnemyHealth()
    {
        return health;
    }

    public float GetEnemyAttackInterval()
    {
        return attackInterval;
    }

    public void CallResetTimer()
    {
        EnemyCombat.instance.ResetTimer();
        Debug.Log("Reset Timer");
    }

    public void EnableLeftParry()
    {
        PlayerController.instance.SetLeftParry(0);
        Debug.Log("Parry Left Now!");
    }

    public void DisableLeftParry()
    {
        PlayerController.instance.SetLeftParry(1);
        Debug.Log("Stopped Left");
    }

    public void EnableRightParry()
    {
        PlayerController.instance.SetRightParry(0);
        Debug.Log("Parry Right Now!");
    }

    public void DisableRightParry()
    {
        PlayerController.instance.SetRightParry(1);
        Debug.Log("Stopped Right");
    }
}
