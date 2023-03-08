using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemAddStickman : ButtonBase
{

    [SerializeField] private StickmanPlacer stickmanPlacer;

    private void AddStickman()
    {
        if (CheckAmount() && EventManager.E_StickmansManager.Invoke().stickmansOnGame[0].Count != stickmanPlacer.maxStickmanCount)
        {
            StickmanController obj = EventManager.E_ObjectPool?.Invoke().GetPooledObject(0);
            stickmanPlacer.SetTransform(obj.obj_Main, obj.level);

            UpdateCost();
            UpdateText();
        }
    }
    public override void OnClickButton()
    {
        AddStickman();
    }

}
