using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputController : MonoBehaviour
{
    public GameObject _globalManager;
    public GameObject Field1;
    public GameObject Field2;
    public GameObject Field3;
    public GameObject Field4;
    public GameObject Field5;
    public GameObject Field6;
    private GameObject[] FieldArray = new GameObject[6];
    void Start()
    {
        FieldArray[0] = Field1;
        FieldArray[1] = Field2;
        FieldArray[2] = Field3;
        FieldArray[3] = Field4;
        FieldArray[4] = Field5;
        FieldArray[5] = Field6;
    }

    public void Click()
    {
        /* To record that how many times the player clicked */
        _globalManager.GetComponent<GlobalManager>().clickCount++;
        for (int i = 0; i < FieldArray.Length; i++)
        {
            if (FieldArray[i].transform.childCount != 0)
            {
                FieldArray[i].GetComponentInChildren<Hero>().Attack(GlobalManager.currentEnemy);
            }
        }



    }


}
