using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Spine.Unity;
using UnityEngine.Events;
using Spine;

public class SpineButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Spine-related")]
    public SkeletonGraphic SpineUI;
    public Toggle RelatedToggle;
    [SerializeField, SpineAnimation]
    private string _buttonIdleAnimation;
    [SerializeField, SpineAnimation]
    private string _onHighlightAnimation;
    [SpineSkin]
    public string[] OnSelectSkins;
    public string DefaultSkin { get; set; }

    private void Start()
    {
        DefaultSkin = SpineUI.initialSkinName;
    }

    //¬ызываетс€ через Button.OnClick(). Ќастраиваетс€ в инспекторе.
    public void OnClick()
    {
        RelatedToggle.isOn = !RelatedToggle.isOn;
    }

    public void OnToggle(bool value)
    {
        if (value) SelectButton();
        else DeselectButton();
    }

    public void SelectButton()
    {
        //активируем сразу 2 скина. OnSelectSkins
        //
        Skin newSkin = new Skin("new");
        for (int i = 0; i < OnSelectSkins.Length; i++)
        {
            newSkin.AddSkin(SpineUI.SkeletonData.FindSkin(OnSelectSkins[i]));
        }
        //
        SpineUI.Skeleton.SetSkin(newSkin);
        SpineUI.Skeleton.SetSlotsToSetupPose();
        Debug.Log(SpineUI.Skeleton.Skin.Name);
    }

    public void DeselectButton()
    {
        //оставл€ем автивированным лишь 1 скин DefaultSkin
        SpineUI.Skeleton.SetSkin(DefaultSkin);
        SpineUI.Skeleton.SetSlotsToSetupPose();
        Debug.Log(SpineUI.Skeleton.Skin.Name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //запускаем анимацию OnHighlightAnimation
        SpineUI.AnimationState.SetAnimation(0, _onHighlightAnimation, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //выключаем анимацию OnHighlightAnimation, переходим в IdleAnimation
        SpineUI.AnimationState.SetAnimation(0, _buttonIdleAnimation, true);
    }
}
