using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
public class MenuPanel : MonoBehaviour
{
    [SerializeField] private PanelType type;

    [SerializeField] private float animationTemps;

    [SerializeField] private AnimationCurve animCurve = new AnimationCurve();

    private bool state;

    private Canvas canvas;

    private CanvasGroup group;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        group = GetComponent<CanvasGroup>();
    }

    private void UpdateState(bool animer)
    { 
        StopAllCoroutines();
        if (animer) {StartCoroutine(Animation(state));} 
        else {canvas.enabled = state;}
    }

    private IEnumerator Animation(bool anotherState)
    {
        canvas.enabled = true; 

        float temps = anotherState ? 0 : 1; //ternaire si vrai temps = 0, si faut temps = 1
        float target = anotherState ? 1 : 0; //ternaire inverse
        int factor = anotherState ? 1 : -1;

        while(true) 
        {
            yield return null;
            temps += Time.deltaTime * factor / animationTemps;
            group.alpha = animCurve.Evaluate(temps);

            if ((state && temps >= target) || (!state && temps <= target))
            {group.alpha = target; break;}
        }

        canvas.enabled = anotherState;
    }

    public void ChangeState(bool animer)
    { state = !state; UpdateState(animer); }

    public void ChangeState(bool animer, bool otherState)
    { state = otherState; UpdateState(animer); }

    #region Getter
    public PanelType GetPanelType() { return type; }
    #endregion
}
