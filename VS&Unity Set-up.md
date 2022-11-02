# Unity \& Visual Studio Set-up
This development uses [Unity](https://unity.com/download) and [Visual Studio](https://visualstudio.microsoft.com/) as the development tools. Unity Pro is available in [Unity Student Plan](https://unity.com/products/unity-student).
## Version
After practical development tests, the following versions are available:\
Unity: ``2019.4.40f1`` \& ``2020.3.38f1``\
Visual Studio: ``Community 2019`` \& ``Community 2022``\
The version was used in this development is: ``Unity 2019.4.40f1`` and ``Visual Studio Community 2022``.
## Visual Studio Set-up

Be sure you install the following workloads:
- .NET desktop development (option)
- Desktop development with C++ (option)
- Universal Windows Platform (UWP) development
- Game development with Unity (if planning to use Unity)

Within the UWP workload, make sure the following components are included for installation:
- IntelliCode
- Windows 10 SDK version ``10.0.19041.0`` or ``10.0.18362.0``, or Windows 11 SDK
- USB Device Connectivity (required to deploy/debug to HoloLens over USB)
- C++ (v142) Universal Windows Platform tools (required when using Unity)

Note: Some of these workloads may be pre-installed if you've installed Unity first. Make sure you have all of these workloads for a successful deployment.\
![vs_installation](/Images/visual%20studio%20installation.PNG "visual studio installation")
## Unity Set-up
1. If you don't have any previous unity development experience, it is recommended that you learn basic unity development through the [Unity Learn](https://learn.unity.com/)
2. This section deals with setting up the Unity editor and importing MRTK(Mixed Reality Toolkit). Recommended reference is the official Microsoft tutorial: [Introduction to the Mixed Reality Toolkit-Set Up Your Project and Use Hand Interaction](https://learn.microsoft.com/en-us/training/modules/learn-mrtk-tutorials/).\
It is highly recommended to complete the first three tutorials on this page [[HoloLens 2 fundamentals: develop mixed reality applications](https://learn.microsoft.com/en-us/training/paths/beginner-hololens-2-tutorials/)] to learn about basic HoloLens development.

Note: After completing the tutorial, you can build and deploy the scene to a HoloLens device or to the HoloLens simulator. The tutorial of HoloLens Simulator could be find in this page [[Using the HoloLens Emulator](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/using-the-hololens-emulator)]
