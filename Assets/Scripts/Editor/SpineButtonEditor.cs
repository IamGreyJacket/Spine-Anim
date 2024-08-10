using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Spine.Unity;
using UnityEditor.UI;
using UnityEditor;

[CustomEditor(typeof(SpineExperimentButton))]
public class SpineButtonEditor : ButtonEditor
{
    public override void OnInspectorGUI()
    {
        SpineExperimentButton targetSpineButton = (SpineExperimentButton)target;

        base.OnInspectorGUI();

        targetSpineButton.SpineUI = (SkeletonGraphic)EditorGUILayout.ObjectField("Spine UI", targetSpineButton.SpineUI, typeof(SkeletonGraphic), true);
        targetSpineButton.RelatedToggle = (Toggle)EditorGUILayout.ObjectField("Related Toggle", targetSpineButton.RelatedToggle, typeof(Toggle), true);
        targetSpineButton.OnHighlightAnimation = EditorGUILayout.TextField("On Highlight Animation", "");
    }
}
