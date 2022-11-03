# Game Objects
Here is introductions of game objects in Laser Puzzle game. The releated technical details you can find in [Machanism Implematation]()

## Laser Pointer
![LaserPointer](/Images/Laser_Pointer.PNG "LaserPointer")

A laser pointer that emits rays of a specified colour and width. They can be manipulated(change position.) only in admin mode.
## Mirror
![Mirror](/Images/Mirror.PNG "Mirror")

A 3D flat square, manipulable, colliding body with physical characteristics. Shape-customisable shape in admin mode. The core feature is the reflective laser.

## Wall
![Wall](/Images/Wall.PNG "Wall")

3D squishy, non-manipulable, colliding bodies with physical characteristics. Can be manipulated and shape-customisable in admin mode. As a general obstruction to non-reflective lasers.

## CheckPoint
![CheckPoint](/Images/CheckPoint.PNG "CheckPoint")
![CheckPoint_active](/Images/CheckPoint_active.PNG "CheckPoint_active")

Indicator with detection function. When the laser shots on the corresponding indicator, it changes from gray to the corresponding color.

## System Menu
![System Menu](/Images/System_menu.PNG "System Menu")\
UI Object. Used to switch on/off administrator mode and increase/decrease the number of mirrors and walls(The minimum number of mirrors and walls is 4 and 3, the maximum is 10). The number can be changed only in the admin mode.