using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rah : Pet
{
    public Rah()
    {
        name = "Rah";
        level = 1;
        price = 100;
        priceRate = 1.5f;
        skillBuffRate = 1.5f;
    }

    public override void PetEffectOn()
    {
        for (int i = 0; i < _globalManager.FieldArray.Length; i++)
        {
            // If there are any hero on field
            if (_globalManager.FieldArray[i].transform.childCount == 1)
            {
                // If the element of hero is Fire
                if (_globalManager.FieldArray[i].transform.GetChild(0).GetComponent<Hero>().getElement() == Character.Element.Fire)
                {
                    _globalManager.FieldArray[i].transform.GetChild(0).GetComponent<Hero>().setExtraPowerRatio(skillBuffRate);
                }
            }
        }
    }

    public override void PetEffectOff()
    {
        for (int i = 0; i < _globalManager.FieldArray.Length; i++)
        {
            // If there are any hero on field
            if (_globalManager.FieldArray[i].transform.childCount == 1)
            {
                // If the element of hero is Fire
                if (_globalManager.FieldArray[i].transform.GetChild(0).GetComponent<Hero>().getElement() == Character.Element.Fire)
                {
                    _globalManager.FieldArray[i].transform.GetChild(0).GetComponent<Hero>().setExtraPowerRatio(1f);
                }
            }
        }
    }
}
