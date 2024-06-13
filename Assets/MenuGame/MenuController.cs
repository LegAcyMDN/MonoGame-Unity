using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelType { None, Main, Credits, Options, }

public class MenuController : MonoBehaviour
{
    [SerializeField] private List<MenuPanel> panelsList = new List<MenuPanel>();

    private Dictionary<PanelType, MenuPanel> panelsDict = new Dictionary<PanelType, MenuPanel>();

    private GameManager manager;

    private void Start()
    {
        manager = GameManager.instance;

        foreach (var panel in panelsList)
        {
            if (panel) { panelsDict.Add(panel.GetPanelType(), panel); }
        }

        OpenOnePanel(PanelType.Main, false);
    }

    private void OpenOnePanel(PanelType otherType, bool animer)
    {
        foreach (var panel in panelsList) { panel.ChangeState(animer, false); }
        if (otherType != PanelType.None) { panelsDict[otherType].ChangeState(animer, true); }
    }

    public void OpenPanel(PanelType otherType)
    { OpenOnePanel(otherType, true); }

    public void JouerScene(int sceneJouer)
    { manager.JouerScene(sceneJouer); }

    public void Quitter()
    { manager.Quitter(); }
}