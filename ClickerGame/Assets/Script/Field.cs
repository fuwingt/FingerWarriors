using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    [Header("Skill Related")]
    public GameObject SkillButton;
    public GameObject BorderImage;
    public GameObject Image_icon;

    [Header("Logo")]
    public Sprite ArrowLogo;
    public int ID;
    public float fieldBuff = 1;

    private Hero hero;

    void Update()
    {
        if (transform.childCount != 0)
        {
            transform.GetChild(0).GetComponent<Hero>().fieldBuff = fieldBuff;
        }
    }

    //  Call from switch field
    public void activateLogo(bool isRaycastTarget)
    {
        Animator animator = gameObject.GetComponent<Animator>();
        GetComponent<Image>().raycastTarget = isRaycastTarget;
        bool isLogoShowUp = animator.GetBool("isLogoShowUp");
        animator.SetBool("isLogoShowUp", !isLogoShowUp);
    }


    public void activateSkillButton()
    {
        hero = transform.GetComponentInChildren<Hero>();
        Image_icon.GetComponent<Image>().sprite = hero.Icon;
        SkillButton.SetActive(true);
        SkillButton.GetComponent<SkillButton>().hero = hero;
        BorderImage.GetComponent<Image>().sprite = hero.ElementBorder;

    }

    public void deactivateSkillButton()
    {
        SkillButton.SetActive(false);
    }
}
