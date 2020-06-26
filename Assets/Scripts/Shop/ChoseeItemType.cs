using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseeItemType : MonoBehaviour
{
    public Button PaperButton;
    public Button AbilityButton;
    public Button BackGroundButton;
    private ScrollCases _scrolCases;
    public GameObject[] buttons = new GameObject[3];
    public RectTransform[] LastElementsOfCase = new RectTransform[3];

    private void Start()
    {
        PaperButton.onClick.AddListener(() => ChooseType(0));
        AbilityButton.onClick.AddListener(() => ChooseType(1));
        BackGroundButton.onClick.AddListener(() => ChooseType(2));
        _scrolCases = FindObjectOfType<ScrollCases>();
    }


    private void ChooseType(int type)
    {
        for(int i = 0; i < buttons.Length; i++)
        {

            if (type != i)
            {
                buttons[i].SetActive(false);
            }
            else
            {
                buttons[i].SetActive(true);
            }
        }


        _scrolCases.SetCase(buttons[type] , -LastElementsOfCase[type].transform.position.x);
    }
}
