# Mechanism Implementation
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
Through these documentations and tutorials, you can customize the visual, auditory, and interactive effects of UI elements. For example, in `Package/Mixed Reality Toolkits Standard Assets/Aduio` you can find some provided audio assets. You can add them to your buttons with `PressableButtonHoloLens2` and `Audio Source` components.

![audio](/Images/Audio.PNG "audio")

This project is mainly based on **Near Menu**.\
The core function of UI elements, on the other hand, is the binding of click events. It could be set in `Button Config Helper` Cpmponent.
![click](/Images/click_event.PNG "click")

In this project, a empty Object named ``System Controller`` is used to do some global management, like some global functions and Object Binding. It will be discussed in next section.

## System Controller
In laser puzzles, virtual walls, laser pointers, and checkpoints are not manipulable objects for the player. However, after the program is running, it is necessary to adjust the position and change the number and shape of mirrors and walls according to the real environment in order to design different puzzles based on the real environment.\
Therefore, an admin-mode switch has been added to the UI menu to give the player the right to adjust these objects.\
![systemController](/Images/systemController.PNG "systemController")
### Admin Mode
The core of admin mode is changing the activation state of these child components in these objects: `ObjectManipulator`, `BoundsControl`. For iterating over the specified objects, the approach used here is to add a tag to the object, e.g:
![tag](/Images/tag.PNG "tag")
```C#
private GameObject[] mirrors;
private bool adminState = false;
mirrors = GameObject.FindGameObjectsWithTag("Mirror");
foreach (GameObject mirror in mirrors)
{
    mirror.GetComponent<BoundsControl>().enabled = !adminState;
}
```
### Change of Objects-Number
For changing the number of objects, the current solution is to prefabricate objects and set them to inactive by default, and change the active status of the corresponding number to increase or decrease through the admin mode. They are `Edit Mirrors` and `Edit Walls` in the image above. Since Unity cannot actively detect objects that are set to inactive, such object bindings are good for helping Unity locate these objects.

![systemController_part](/Images/systemController_part.PNG "systemController_part")

These two are used to bind the number of objects in the UI menu and to warn when an operation is violated(When admin mode is not enabled or the number of objects exceeds the limit).

Note: The current solution has a limit on the number, i.e., the maximum number depends on the number of prefabricated objects, and the objects may be increased or decreased in the future using initial generation, but the performance resource usage still needs to be tested.

## Laser Mechanism
This feature is built based on [Ray - Scripting API - Unity - Manual](https://docs.unity3d.com/ScriptReference/Ray.html) and [Scripting API: Physics.Raycast - Unity - Manual](https://docs.unity3d.com/ScriptReference/Physics.Raycast.html), [Scripting API: RaycastHit - Unity - Manual](https://docs.unity3d.com/ScriptReference/RaycastHit.html) these three APIs in Unity.

1.  **Ray** is an infinite line starting at origin and going in some direction.
```C#
//The origin point and direction of the ray.
Ray ray = new Ray(origin, direction);
```
2. **RayCaset** used to detect the hit between ray and all colliders in the Scene.
```C#
public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);
```
Casts a ray, from point origin, in direction direction, of length maxDistance, against all colliders in the Scene. You may optionally provide a LayerMask, to filter out any Colliders you aren't interested in generating collisions with. Specifying queryTriggerInteraction allows you to control whether or not Trigger colliders generate a hit, or whether to use the global Physics.queriesHitTriggers setting.

The API documentation gives these methods:
```C#
public static bool Raycast(Ray ray, RaycastHit hitInfo, float distance, int layerMask);

public static bool Raycast(Ray ray, float distance, int layerMask);

public static bool Raycast(Vector3 origin, Vector3 direction, float distance, int layerMask);

public static bool Raycast(Vector3 origin, Vector3 direction, RaycastHit , float distance , int layerMask );
```
3. **RaycastHit** class is a structured data object that is returned when a ray hits an object during a raycast. Some of the properties of the RaycastHit include collider, distance, rigidbody, and transform.
```C#
//create a RaycastHit object to receive the information returned from collision
RaycastHit hit;
//Physics.Raycast method returns a boolean vaule about if it hits something
//the collision information has been saved in [hit] when the collision happened
Physics.Raycast(ray, out hit, 30)
```
4. **Reflection Mechanism**,  After obtaining the collision information through ``RaycastHit``, we can simulate the reflection effect by verifying the tag of the collision object and emit a new ray through the normal direction of the collision angle.
```C#
//Used to save all currently collision point locations.
List<Vector3> laserIndices = new List<Vector3>();

void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
{
    //LineRenderer laser is a Renderer for rendering ray's visual effects
    laserIndices.Add(pos);
    Ray ray = new Ray(pos, dir);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 30))
    {
        CheckHit(hit, dir, laser);
    }
    else
    {
        laserIndices.Add(ray.GetPoint(30));
        UpdateLaser();
    }
}
//Verify collision information
void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
{
    if (hitInfo.collider.gameObject.tag == "Mirror")
    {
        Vector3 pos = hitInfo.point;
        Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);
        //emit a new ray
        CastRay(pos, dir, laser);
    }
}

void UpdateLaser()
{
    int count = 0;
    laser.positionCount = laserIndices.Count;
    foreach (Vector3 idx in laserIndices)
    {
        laser.SetPosition(count, idx);
        count++;
    }
}

```
5. **Frame Update**. Since there are movable objects, such as mirrors, the laser mechanism needs to be updated and detected at each frame. So this project creates a script called `ShootLaser` and adds it to the `LaserPointer` object to achieve automatic emission , detection and updates of lasers.
```C#
public class ShootLaser : MonoBehaviour
{
    public Material material;
    LaserBeam beam;

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Laser Beam-"+gameObject.name));
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material, gameObject.name);
        
    }
}
```
``LaserBeam Class`` is used to execute the **Laser-Mechanism** I disscussed above. And use the `Destroy` function to make sure we always have only one LaserBeam object.

## Checkpoint
The mechanism  of CheckPoint is actually the same as the above-mentioned ray collision detection. Through the collision information to get the object of collision, and re-set its color.
```C#
//When the corresponding checkpoint matches with the laser.
 if(hitInfo.collider.gameObject.tag == "CheckPoint-Laser Pointer-1" && this.pointerName =="Laser Pointer-1")
{
    hitInfo.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    laserIndices.Add(hitInfo.point);
    UpdateLaser();
}
```
For collision detection, there are in fact more possibilities that can be further expanded in the future.
