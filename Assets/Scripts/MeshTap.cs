using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;

public class MeshTap : MonoBehaviour, IMixedRealityFocusHandler, IMixedRealityPointerHandler
{
    MeshObservation observation;
    SpatialAwarenessMeshObject meshObject;

    public void SetValue(MixedRealitySpatialAwarenessEventData<SpatialAwarenessMeshObject> eventData)
    {
        if (observation == null)
            observation = FindObjectOfType<MeshObservation>();

        meshObject = eventData.SpatialObject;

        if (gameObject.GetComponent<BoxCollider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
            Debug.Log("Dection Plane");
        }


    }

    void IMixedRealityFocusHandler.OnFocusEnter(Microsoft.MixedReality.Toolkit.Input.FocusEventData eventData)
    {

    }

    void IMixedRealityFocusHandler.OnFocusExit(Microsoft.MixedReality.Toolkit.Input.FocusEventData eventData)
    {

    }

    void IMixedRealityPointerHandler.OnPointerDown(Microsoft.MixedReality.Toolkit.Input.MixedRealityPointerEventData eventData)
    {

    }

    void IMixedRealityPointerHandler.OnPointerDragged(Microsoft.MixedReality.Toolkit.Input.MixedRealityPointerEventData eventData)
    {

    }

    void IMixedRealityPointerHandler.OnPointerClicked(Microsoft.MixedReality.Toolkit.Input.MixedRealityPointerEventData eventData)
    {

    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {

    }
}