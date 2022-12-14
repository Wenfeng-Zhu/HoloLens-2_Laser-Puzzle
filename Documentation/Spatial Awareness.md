# Spatial Awareness
The Spatial Awareness system provides real-world environmental awareness in mixed reality applications. This system provides scanning of the device for the real environment, making it possible for virtual objects to interact with real objects.

There is a tutorial on spatial awareness, which can be found in Microsoft  documentation: [[Spatial awareness getting started — MRTK2](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/spatial-awareness/spatial-awareness-getting-started?view=mrtkunity-2022-05#enable-the-spatial-awareness-system)]. In this documentation, some additional explanations for this project will be provided.
## Enable the spatial awareness system
About enabling spatial awareness, the default configuration file is not editable.

![SDK_Profile](/Images/SDK%20Profile.PNG "SDK_Profile")

You can click the `clone` button to generate a customized profile, the profiles will be put defautly in this path: `Asset/MixedRealityToolKit.Generated/CustomProfiles`, of course you can select any path as the destination folder.

![new_Profile](/Images/new_Profile.PNG "new_Profile")

It's the same in Spatial Awareness Setting. You should clone `DefaultMixedRealitySpatialAwarenessSystemProfile` file to edit it.

## Register observers

Spatial Observers are generally platform specific components that act as the provider for surfacing various types of mesh data from a platform specific endpoint (i.e HoloLens).
In this project you should register a new spatial observer:

![new_Observer](/Images/new_observer.PNG "new_Observer")

Choose type as `Microsoft.MixedReality.Toolkit.WindowsMixedReality.SpatialAwareness --> WindowsMixedRealitySpatialMeshObserver` and clone the profile file.

![mesh_Observer](/Images/mesh_observer.PNG "mesh_Observer")

You can also check Microsoft documentation [[Configuring mesh observers for device — MRTK2](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/spatial-awareness/configuring-spatial-awareness-mesh-observer?view=mrtkunity-2022-05)]

What you need to pay attention to in this project is: Change **Display Option** to `Occlusion`, three observers generated by default are included. Mixed Reality Toolkit reserves layer 31 by default for use by Spatial Awareness observers.\
There are choices regarding the spatial layer, related to the `Raycast` class.
```C#
public static bool Raycast (Vector3 origin, Vector3 direction, float maxDistance= Mathf.Infinity, int layerMask= DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction= QueryTriggerInteraction.UseGlobal);
```
You may optionally provide a LayerMask, to filter out any Colliders you aren't interested in generating collisions with.\
You can edit layers setting in **Edit->Project Settings-> Tags and Layers**. If you didn't enter any layerMask, that means ray will interact with all layers except for `Builtin Layer 2: Ignore Raycast`.

![layers](/Images/layers.PNG "layers")

## ToDo: Calling the spatial awareness system via code
Mesh Observers can be configured via code, it includes these features:
- Accessing mesh observers
- Starting and stopping mesh observation
- Starting and stopping all mesh observation
- Enumerating and accessing the meshes
- Showing and hiding the spatial mesh
- Registering for mesh observation events

Through `IMixedRealitySpatialAwarenessMeshObserver` Interface, Observers targeting specific real objects can be generated in the future to enable further expansion of virtual-reality interaction capabilities.
