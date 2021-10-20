using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance {get; private set;}

    [Header("Variables")]
    public float highscore;
    public TMP_Text scoreText;

    [Header("Debugger")]
    private bool canParryLeft;
    private bool canParryRight;
    private int parryCount;

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
        highscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = highscore.ToString();
    }

    public void TryLeftParry()
    {
        if (canParryLeft)
        {
            highscore++;
            //Debug.Log("Parried Left");
        }
        else
        {
            highscore--;
            //Debug.Log("Failed Left Parry");
        }
    }

    public void TryRightParry()
    {
        if (canParryRight)
        {
            highscore++;
            //Debug.Log("Parried Right");
        }
        else
        {
            highscore--;
            //Debug.Log("Failed Right Parry");
        }
    }

    public void SetLeftParry(int enabled) // enabled == 0 is true, 1 is false;
    {
        if(enabled == 0)
        {
            canParryLeft = true;
        }
        else
        {
            canParryLeft = false;
        }
    }

    public void SetRightParry(int enabled) // enabled == 0 is true, 1 is false;
    {
        if(enabled == 0)
        {
            canParryRight = true;
        }
        else
        {
            canParryRight = false;
        }
    }

}
