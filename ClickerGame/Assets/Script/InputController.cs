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

    private GameObject[] FieldArray;
    void Start()
    {
        FieldArray = GlobalManager.FieldArray;
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
