using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class XRText : Text
{
    //ũ�Ⱑ ����Ǿ��� �� ȣ��Ǵ� �Լ� ������ �ִ� ����
    public Action onChangedSize;

    public override void CalculateLayoutInputVertical()
    {
        base.CalculateLayoutInputVertical();
        if(onChangedSize != null)
        {
            onChangedSize();
        }
    }

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();
        if (onChangedSize != null)
        {
            onChangedSize();
        }
    }
}
