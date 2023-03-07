using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanManager : MonoBehaviour
{
    public Dictionary<int, List<StickmanController>> stickmansOnGame = new();

    [SerializeField] private List<StickmanController> stickmanList_level_1;
    [SerializeField] private List<StickmanController> stickmanList_level_2;
    [SerializeField] private List<StickmanController> stickmanList_level_3;
    [SerializeField] private List<StickmanController> stickmanList_level_4;
    [SerializeField] private List<StickmanController> stickmanList_level_5;
    [SerializeField] private List<StickmanController> stickmanList_level_6;

    private void Awake()
    {

        stickmansOnGame.Add(0, stickmanList_level_1);
        stickmansOnGame.Add(1, stickmanList_level_2);
        stickmansOnGame.Add(2, stickmanList_level_3);
        stickmansOnGame.Add(3, stickmanList_level_4);
        stickmansOnGame.Add(4, stickmanList_level_5);
        stickmansOnGame.Add(5, stickmanList_level_6);

    }

    #region EventManager

    private void OnEnable()
    {
        EventManager.E_StickmansManager += GetThis;
    }

    private void OnDisable()
    {
        EventManager.E_StickmansManager -= GetThis;
    }

    #endregion

    private StickmanManager GetThis()
    {
        return this;
    }

    public void AddObj(StickmanController stickman)
    {

        stickmansOnGame[stickman.level - 1].Add(stickman);

    }
    
    public void RemoveObj(StickmanController stickman)
    {

        stickmansOnGame[stickman.level - 1].Remove(stickman);

    }

}
