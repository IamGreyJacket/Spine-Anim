using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Spine.Unity;

public class SpineExperimentButton : Button
{
    [Header("Spine-related")]
    public SkeletonGraphic SpineUI;
    public Toggle RelatedToggle;
    [SpineAnimation]
    public string OnHighlightAnimation;
    [SpineSkin]
    public string[] OnSelectSkins;
    public string DefaultSkin;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }
}
