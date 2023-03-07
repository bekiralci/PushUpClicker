using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemSizeUp : ButtonBase
{

    List<GameObject> mats;

    private int lastRoadIndex;

    public override void OnClickButton()
    {
        UnlockNewMats();
    }

    private void UnlockNewMats()
    {
        mats[lastRoadIndex + 1].SetActive(true);
        lastRoadIndex++;
    }

}
