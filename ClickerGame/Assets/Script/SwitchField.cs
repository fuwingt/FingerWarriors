using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchField : MonoBehaviour
{
    public Text status;
    private GlobalManager _globalManager;
    private GameObject[] FieldArray;
    private GameObject ExtraField;
    private GameObject hero;

    private bool isSelectingField = false;



    // Use this for initialization
    void Start()
    {
        _globalManager = GameObject.Find("GlobalManager").gameObject.GetComponent<GlobalManager>();
        FieldArray = GlobalManager.FieldArray;
        ExtraField = GameObject.Find("ExtraField");

    }

    // Update is called once per frame
    void Update()
    {
        if (isSelectingField == true)
        {
            SwitchHero();
        }
    }

    /* Join(Select) button will trigger the SwitchStatus(Join) function */
    public void SwitchStatus()
    {
        if (hero == null) return;
        isSelectingField = true;
        // Show arrow logo
        for (int i = 0; i < FieldArray.Length; i++)
            FieldArray[i].GetComponent<Field>().activateLogo();
    }

    private void SwitchHero()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "FrontField" || hit.collider.gameObject.tag == "BackField")
                {
                    if (hit.collider.transform.childCount == 0)
                    {
                        // Join
                        hero.SetActive(true);
                        if (hero.transform.parent.tag == "FrontField" || hero.transform.parent.tag == "BackField")
                            hero.transform.parent.GetComponent<Field>().deactivateSkillButton();
                        hero.transform.SetParent(hit.collider.gameObject.transform);

                        hit.collider.GetComponent<Field>().activateSkillButton();
                    }
                    else if (hit.collider.transform.childCount == 1)
                    {
                        // Replace
                        hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                        hit.collider.transform.GetChild(0).SetParent(ExtraField.transform);

                        hero.SetActive(true);
                        hero.transform.parent.GetComponent<Field>().deactivateSkillButton();
                        hero.transform.SetParent(hit.collider.gameObject.transform);

                        hit.collider.GetComponent<Field>().activateSkillButton();

                    }
                }
                else
                {
                    // Hide the arrow and then return
                }
            }
            isSelectingField = false;
            // Hide arrow logo
            for (int i = 0; i < FieldArray.Length; i++)
                FieldArray[i].GetComponent<Field>().activateLogo();
        }
    }

    public void QuitField()
    {
        if (hero == null) return;
        hero.SetActive(false);
        hero.transform.parent.GetComponent<Field>().deactivateSkillButton();

        hero.transform.SetParent(ExtraField.transform);
    }
    public void setHero(GameObject hero)
    {
        this.hero = hero;
    }
}
