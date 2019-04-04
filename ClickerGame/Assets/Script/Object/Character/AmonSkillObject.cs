using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmonSkillObject : MonoBehaviour
{

    private float result;
    void activateSkill()
    {
        GlobalManager.currentEnemy.GetComponent<Monster>().BeingAttacked(result);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void setResult(float result)
    {
        this.result = result;
    }
}
