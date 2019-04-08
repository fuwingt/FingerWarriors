using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rah : Pet
{
    public Rah()
    {
        name = "Rah";
        level = 0;
        price = 100;
        priceRate = 1.5f;
        skillBuffRate = 1.5f;
        description = "Fire Attack x " + skillBuffRate;
    }

    public override void PetEffectOn()
    {
        for (int i = 0; i < FieldArray.Length; i++)
        {
            // If there are any hero on field
            if (FieldArray[i].transform.childCount == 1)
            {
                // If the element of hero is Fire
                if (FieldArray[i].transform.GetChild(0).GetComponent<Hero>().getElement() == Character.Element.Fire)
                {
                    FieldArray[i].transform.GetChild(0).GetComponent<Hero>().setPowerRatio(skillBuffRate);
                }
            }
        }
    }

    public override void PetEffectOff()
    {
        for (int i = 0; i < FieldArray.Length; i++)
        {
            // If there are any hero on field
            if (FieldArray[i].transform.childCount == 1)
            {
                // If the element of hero is Fire
                if (FieldArray[i].transform.GetChild(0).GetComponent<Hero>().getElement() == Character.Element.Fire)
                {
                    FieldArray[i].transform.GetChild(0).GetComponent<Hero>().setPowerRatio(1f);
                }
            }
        }
    }
}
