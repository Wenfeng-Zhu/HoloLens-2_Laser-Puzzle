using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeshVisibleSetting : MonoBehaviour
{
    public GameObject EnvMeshInfor;
    private bool visible = false;
    public void setVisible()
    {
        var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();
        TextMeshPro text = EnvMeshInfor.GetComponent<TextMeshPro>();
        if (visible)
        {
            observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.None;
            text.text = "OFF";
            visible = false;
        }
        else
        {
            observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.Occlusion;
            text.text = "ON";
            visible = true;
        }

    }
}
