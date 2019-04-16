using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("MenuButton")]
    public GameObject HeroesMenu;
    public GameObject EquipmentMenu;
    public GameObject PetMenu;
    public GameObject AchievementMneu;
    [Header("Others")]
    public GameObject isFarmingButton;
    public GlobalManager globalManager;
    public MonsterManager monsterManager;

    /*  Variables  */
    private GameObject[] MenuArray = new GameObject[4];

    private bool isPopUp;

    void Start()
    {
        MenuArray[0] = HeroesMenu;
        MenuArray[1] = EquipmentMenu;
        MenuArray[2] = PetMenu;
        MenuArray[3] = AchievementMneu;
    }

    void Update()
    {
        if (monsterManager.isFarming)
            isFarmingButton.SetActive(true);
        else
            isFarmingButton.SetActive(false);

    }

    public void PopUpHeroesMenu(int id)
    {
        isPopUp = MenuArray[id].GetComponent<Animator>().GetBool("popUp");
        MenuArray[id].GetComponent<Animator>().SetBool("popUp", !isPopUp);

        for (int i = 0; i < MenuArray.Length; i++)
            if (i != id)
                MenuArray[i].GetComponent<Animator>().SetBool("popUp", false);

    }

    public void GoToBossStage()
    {
        if (monsterManager.isFarming)
        {
            globalManager.stage++;
            monsterManager.isFarming = !monsterManager.isFarming;
            monsterManager.NextMonster();
            monsterManager.EntryBossStage(monsterManager.isBossStage = true);
        }
    }


}
