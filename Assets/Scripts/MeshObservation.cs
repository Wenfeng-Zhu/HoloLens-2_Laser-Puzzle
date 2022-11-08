using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using SpatialAwarenessHandler = Microsoft.MixedReality.Toolkit.SpatialAwareness.IMixedRealitySpatialAwarenessObservationHandler<Microsoft.MixedReality.Toolkit.SpatialAwareness.SpatialAwarenessMeshObject>;
using TMPro;

public class MeshObservation : MonoBehaviour, SpatialAwarenessHandler
{
    public GameObject obj;
    private TextMeshPro text;
    private void OnEnable()
    {
        text = obj.GetComponent<TextMeshPro>();
        text.text = "On enable";
        CoreServices.SpatialAwarenessSystem.RegisterHandler<SpatialAwarenessHandler>(this);
    }

    private void OnDisable()
    {
        CoreServices.SpatialAwarenessSystem.UnregisterHandler<SpatialAwarenessHandler>(this);
    }

    public virtual void OnObservationAdded(MixedRealitySpatialAwarenessEventData<SpatialAwarenessMeshObject> eventData)
    {

    }
    public virtual void OnObservationUpdated(MixedRealitySpatialAwarenessEventData<SpatialAwarenessMeshObject> eventData)
    {
        text = obj.GetComponent<TextMeshPro>();
        text.text = "On updating";
        Collider collider =  eventData.SpatialObject.Collider;
        if (eventData.selectedObject.gameObject.GetComponent<MeshTap>() == null)
        {
            MeshTap m = eventData.SpatialObject.GameObject.AddComponent<MeshTap>();
            m.SetValue(eventData);
        }
        else
        {
            text.text = collider.ToString();
        }

    }
    public virtual void OnObservationRemoved(MixedRealitySpatialAwarenessEventData<SpatialAwarenessMeshObject> eventData)
    {

    }


}
