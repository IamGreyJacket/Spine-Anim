using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineAnimationController : MonoBehaviour
{
    [SerializeField]
    private SkeletonAnimation _targetSpine;
    [SerializeField, SpineAnimation]
    private string _cutsceneName;
    [SerializeField, SpineAnimation]
    private string _idleName;
    [SerializeField]
    private GameObject _buttonsHolder;
    private bool _isLoop = false;
    public void IsLoop(bool value) => _isLoop = value;

    private void Awake()
    {
        _buttonsHolder.SetActive(false);
    }

    public void AfterStartScreen()
    {
        _targetSpine.AnimationState.AddAnimation(0, _idleName, true, 0);
        _targetSpine.AnimationState.Complete += OnAnimationComplete;
#if UNITY_EDITOR
        for (int i = 0; i < _targetSpine.AnimationState.Tracks.Items.Length; i++)
        {
            Debug.Log($"TrackIndex {_targetSpine.AnimationState.Tracks.Items[i].TrackIndex} (i = {i}): " +
                $"Animation Attached = {_targetSpine.AnimationState.Tracks.Items[i].Animation.Name}");
        }
        //Debug.Log($"Tracks: {_targetSpine.AnimationState.Tracks.Items}");
        for (int i = 0; i < _targetSpine.AnimationState.Data.SkeletonData.Animations.Items.Length; i++)
        {
            Debug.Log($"Animation {i}: {_targetSpine.AnimationState.Data.SkeletonData.Animations.Items[i].Name}");
        }
        //Debug.Log($"Animations: {_targetSpine.AnimationState.Data.SkeletonData.Animations.Items}");
#endif
    }

    private void OnAnimationComplete(Spine.TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == _cutsceneName)
        {
            _buttonsHolder.SetActive(true);
        }
    }

    public void ChangeAnimation(string name)
    {
        if (name == _targetSpine.AnimationName) _targetSpine.AnimationState.SetAnimation(0, _idleName, _isLoop);
        else _targetSpine.AnimationState.SetAnimation(0, name, _isLoop);
    }
}
