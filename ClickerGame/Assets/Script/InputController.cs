using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputController : MonoBehaviour
{
    //public GameObject globalManager;
    [Header("Field")]
    public GameObject Field1;
    public GameObject Field2;
    public GameObject Field3;
    public GameObject Field4;
    public GameObject Field5;
    public GameObject Field6;

    [Header("Combo related")]
    public GameObject comboObject;
    public GameObject comboText;
    public GameObject comboDamageBuffText;


    [HideInInspector] public bool isInCombo;
    private GameObject[] FieldArray;
    private Animator comboObjectAnimator;
    private float timeDuration;
    private int combo;
    private float comboDamageBuff;
    private float criticalChance;
    private float criticalRate;
    private bool isCritical;


    void Start()
    {
        FieldArray = GlobalManager.FieldArray;
        comboObjectAnimator = comboObject.GetComponent<Animator>();
        combo = 0;
        comboDamageBuff = 1;
        criticalChance = 5;
        criticalRate = 1.5f;
    }

    void Update()
    {
        if (combo > 0)
        {
            comboText.GetComponent<TextMesh>().text = "Combo x " + combo;
            comboDamageBuffText.GetComponent<TextMesh>().text = "Damage x " + comboDamageBuff.ToString("F2");
        }
        if (isInCombo) CountCombo();
    }

    public void Click()
    {
        float totalDamage = 0;
        for (int i = 0; i < FieldArray.Length; i++)
        {
            if (FieldArray[i].transform.childCount != 0)
            {
                totalDamage += FieldArray[i].GetComponentInChildren<Hero>().Attack(GlobalManager.currentEnemy);
            }
        }
        // Combo Buff * attack
        totalDamage = CriticalChance(totalDamage *= comboDamageBuff);
        // Do damage
        if (totalDamage != 0) GlobalManager.currentEnemy.GetComponent<Monster>().BeingAttacked(totalDamage, isCritical);
        /* To record that how many times the player clicked */
        GlobalManager.tapCount++;
        /* Start combo */
        timeDuration = 2;
        isInCombo = true;
        if (++combo % 25 == 0) comboDamageBuff *= 1.05f;

    }

    private float CriticalChance(float result)
    {
        float randValue = Random.Range(0, 100);
        if (randValue <= criticalChance)
        {
            // do critical attack
            result *= criticalRate;
            isCritical = true;
        }
        else
            isCritical = false;

        return result;
    }

    private void CountCombo()
    {
        timeDuration -= Time.deltaTime;
        if (timeDuration < 0)
        {
            isInCombo = false;
            combo = 0;
            comboDamageBuff = 1;
        }
        //  Animation
        comboObjectAnimator.SetBool("isInCombo", isInCombo);
    }

    public float getCriticalChance()
    {
        return criticalChance;
    }

    public float getCriticalRate()
    {
        return criticalRate;
    }

    public void setCriticalChance(float criticalChance)
    {
        this.criticalChance = criticalChance;
    }

    public void setCriticalRate(float criticalRate)
    {
        this.criticalRate = criticalRate;
    }


}
