using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject HeroesMenu;
    public GameObject EquipmentMenu;
    public GameObject PetMenu;
    public GameObject AchievementMneu;
    private GameObject[] MenuArray = new GameObject[4];

    private Animator hMenuAnimator;
    private Animator eMenuAnimator;
    private Animator pMenuAnimator;

    private bool isPopUp;

    void Start()
    {
        //MenuArray = new GameObject [4];
        MenuArray[0] = HeroesMenu;
        MenuArray[1] = EquipmentMenu;
        MenuArray[2] = PetMenu;
        MenuArray[3] = AchievementMneu;
    }

    public void PopUpHeroesMenu(int id)
    {
        isPopUp = MenuArray[id].GetComponent<Animator>().GetBool("popUp");
        MenuArray[id].GetComponent<Animator>().SetBool("popUp", !isPopUp);

        for (int i = 0; i < MenuArray.Length; i++)
            if (i != id)
                MenuArray[i].GetComponent<Animator>().SetBool("popUp", false);

    }


}
