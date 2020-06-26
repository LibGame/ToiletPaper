using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCases : MonoBehaviour
{
    public GameObject Case;
    private Vector3 screenPoint, offset;
    private float _lockedYPos = 2;
    public Transform target;
    private float endPos = -18f;
    public RectTransform rect;

    private void Start()
    {
        _lockedYPos = rect.transform.position.y;
    }

    void Update()
    {
        if (Case.transform.position.x > 0)
            Case.transform.position = Vector3.MoveTowards(Case.transform.position, new Vector3(0f, Case.transform.position.y, Case.transform.position.z) , Time.deltaTime * 10);
        else if (Case.transform.position.x < endPos)
            Case.transform.position = Vector3.MoveTowards(Case.transform.position, new Vector3(-5f, Case.transform.position.y, Case.transform.position.z), Time.deltaTime * 10);

    }

    public void SetCase(GameObject _case , float lastPos)
    {
        Case = _case;
        endPos = lastPos;
    }

    private void OnMouseDown()
    {
        offset = Case.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y, Input.mousePosition.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = _lockedYPos;
        Case.transform.position = curPosition;
    }
}
