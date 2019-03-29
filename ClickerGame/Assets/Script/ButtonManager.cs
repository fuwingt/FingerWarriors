using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject HeroesMenu;

    public GameObject EquipmentMenu;

    public void PopUpHeroesMenu()
    {
        if (HeroesMenu != null)
        {
            Animator hMenuAnimator = HeroesMenu.GetComponent<Animator>();
            Animator EMenuAnimator = EquipmentMenu.GetComponent<Animator>();

            if (hMenuAnimator != null)
            {
                bool isPopUp = hMenuAnimator.GetBool("popUp");
                hMenuAnimator.SetBool("popUp", !isPopUp);
                EMenuAnimator.SetBool("popUp", false);
            }
        }
    }

    public void PopUpEquipmentMenu()
    {
        if (EquipmentMenu != null)
        {
            Animator hMenuAnimator = HeroesMenu.GetComponent<Animator>();
            Animator EMenuAnimator = EquipmentMenu.GetComponent<Animator>();
            if (EMenuAnimator != null)
            {
                bool isPopUp = EMenuAnimator.GetBool("popUp");
                EMenuAnimator.SetBool("popUp", !isPopUp);
                hMenuAnimator.SetBool("popUp", false);

            }
        }
    }
}
