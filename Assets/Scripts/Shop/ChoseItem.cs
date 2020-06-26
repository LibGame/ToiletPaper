using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseItem : MonoBehaviour
{
    public GameObject BuyTablePref;
    [SerializeField]
    private string _price;
    [SerializeField]
    private string _discription;
    [SerializeField]
    private GameObject _canvas;
    [SerializeField]
    private Image img;
    public int ItemId;
    public enum TypeOfCase {ability = 0 , backGround = 1 , papers = 2 , donate = 4 }
    public TypeOfCase typeOfCase = TypeOfCase.ability;
    private Vector3 _startScale;

    private void Start()
    {
        _startScale = transform.localScale;
    }
    
    public void ChoosenItem()
    {
        Instantiate(BuyTablePref, BuyTablePref.transform.position, Quaternion.identity);
        BuyTable tab = FindObjectOfType<BuyTable>();
        tab.SetSettings(_price, _discription, img.sprite, ItemId);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trigger")
        {
            _startScale = transform.localScale;

            if(typeOfCase == TypeOfCase.backGround)
            {
                
                transform.localScale = new Vector3(1.4f, 2.3f, transform.localScale.z);
            }
            else if (typeOfCase == TypeOfCase.papers)
            {
                transform.localScale = new Vector3(1.8f, 1.8f, transform.localScale.z);
            }
            else if (typeOfCase == TypeOfCase.donate)
            {

                transform.localScale = new Vector3(1.8f, 1.8f, transform.localScale.z);
            }
            else if (typeOfCase == TypeOfCase.ability)
            {

                transform.localScale = new Vector3(1.2f, 1.2f, transform.localScale.z);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = _startScale;
    }

}
