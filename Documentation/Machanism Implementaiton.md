# Machanism Implementation
Here you can find the relevant technical descriptions of the project implementation.
## Collider and Rigidbody
Collider and Rigibody are Unity Script APIs that give objects physical interaction. You can check the offical documetation to see some details: [[Scripting API: Collider](https://docs.unity3d.com/2020.3/Documentation/ScriptReference/Collider.html)], [[Scripting API: Rigibody](https://docs.unity3d.com/2020.3/Documentation/ScriptReference/Rigidbody.html)]\
It is worth noting that since the mirror is the main object of manipulation, only rigid body components are added to it and set it to the kinematic.

![Rigidbody](/Images/Rigidbody.PNG "Rigidbody")

## Hand Interaction
### Manipulation
Abaout the basic hand interaction you could find as well in tutorial [[Introduction to the Mixed Reality Toolkit-Set Up Your Project and Use Hand Interaction](https://learn.microsoft.com/en-us/training/modules/learn-mrtk-tutorials/)].\
To use the object manipulator, first add the ``ObjectManipulator`` script component to a GameObject. Make sure to also add a collider to the object, matching its grabbable bounds.\
To make the object respond to near articulated hand input, add the ``NearInteractionGrabbable`` script as well.\
As well as this, manipulation can be constrained by adding manipulation ``constraint`` components to the object. These are special components that work with manipulation and change the manipulation behaviour in some way. Subsequent ``BoundsControl`` components depend on this.

![ObjectManipulation](/Images/ObjectManipulation.PNG "ObjectManipulation")
``BoundsControl`` components could be trun on and off through script with `enabled` property.
```C#
gameObject.GetComponent<ObjectManipulator>().enabled = true/false
```
### BoundsControl
![BoundsControl](/Images/mrtk_boundscontrol_main.png "BoundsControl")
The ``BoundsControl`` script provides basic functionality for transforming objects in mixed reality. A bounds control will show a box around the hologram to indicate that it can be interacted with. Handles on the corners and edges of the box allow scaling, rotating or translating the object. The bounds control also reacts to user input. On HoloLens 2, for example, the bounds control responds to finger proximity, providing visual feedback to help perceive the distance from the object.\
In this project, this component is used for scaling and shape customization of mirror objects and wall objects in admin mode.\
For its Activation behavior. There are several options to activate the bounds control interface.
![boundscontrol_activation.png](/Images/boundscontrol_activation.png "boundscontrol_activation.png")
- Activate On Start: Bounds control becomes visible once the scene is started.
- Activate By Proximity: Bounds control becomes visible when an articulated hand is close to the object.
- Activate By Pointer: Bounds control becomes visible when it is targeted by a hand-ray pointer.
- Activate By Proximity and Pointer: Bounds control becomes visible when it is targeted by a hand-ray pointer or an articulated hand is close to the object.
- Activate Manually: Bounds control does not become visible automatically

You can manually activate it through a script by accessing the ``boundsControl.Active`` property.\
For example:
```C#
gameObject.GetComponent<BoundsControl>().BoundsControlActivation = Microsoft.MixedReality.Toolkit.UI.BoundsControlTypes.BoundsControlActivationType.ActivateByProximityAndPointer;
```
You can assign BoundsControl script to an object with collider, using AddComponent<>()
```C#
private BoundsControl boundsControl;
boundsControl = gameObject.AddComponent<BoundsControl>();
```
But in this project, BoundsControl component is pre-added to the game object and turned on and off by the enabled property in admin mode.
```C#
gameObject.GetComponent<BoundsControl>().enabled = true/false;
```
You can also check documentation [[Bounds control — MRTK2](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/ux-building-blocks/bounds-control?view=mrtkunity-2022-05#inspector-properties)]
### UI Element
![ui](/Images/ui.png "ui")

About the creatation of UI element with MRTK, these documentations are recommanded: [[Buttons — MRTK2](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/ux-building-blocks/button?view=mrtkunity-2022-05)], [[Hand menu — MRTK2](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/ux-building-blocks/hand-menu?view=mrtkunity-2022-05)], [[Interactable — MRTK2](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/ux-building-blocks/interactable?view=mrtkunity-2022-05)], [[Near menu — MRTK2](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/ux-building-blocks/near-menu?view=mrtkunity-2022-05)], [[Object collection — MRTK2](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/ux-building-blocks/object-collection?view=mrtkunity-2022-05)]\
Through these documentations and tutorials, you can customize the visual, auditory, and interactive effects of UI elements. For example, in `Package/Mixed Reality Toolkits Standard Assets/Aduio` you can find some provided audio assets. You can add them to your buttons with `PressableButtonHoloLens2` and `Audio Source` components.\
![audio](/Images/Audio.PNG "audio")

This project is mainly based on **Near Menu**.\
The core function of UI elements, on the other hand, is the binding of click events. It could be set in `Button Config Helper` Cpmponent.
![click](/Images/click_event.PNG "click")

In this project, a empty Object named ``System Controler`` is used to do some global management, like some global functions and Object Binding. It will be discussed in next section.


