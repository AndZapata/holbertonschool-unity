# 0x05. Unity - Assets: Models, Textures

## Holberton school project

| Task | Description |
| --- | --- |
| 0. Primitive player | Create a new Scene called Level01. Create a capsule GameObject called Player which will be a placeholder for this project |
| 1. Primitive prototype | In the Level01 scene, create a layout of floating platforms of different sizes and positions using only Unity Cube GameObjects |
| 2. Pole position | At the end point of the platforms, create a placeholder cylinder GameObject called WinFlag to designate the end of the path. Do not make WinFlag a child of any object. Later we will add scripting for when the Player reaches the WinFlag |
| 3. Jump man | Create a new folder called Scripts. Inside that folder, create a new C# script called PlayerController and attach it to Player |
| 4. Camera ready | Position the Main Camera at an offset behind the player |
| 5. Steady cam | In the Scripts folder, create a new C# script called CameraController that allows the camera to follow the player. The script should also allow the player to rotate the camera on their own by moving the mouse, either by just moving the mouse or holding down right-click and dragging the mouse to move the camera |
| 6. Falling up | Currently if the player falls off a platform, it falls infinitely. Edit the PlayerController and CameraController scripts so that if the player falls from a platform and can’t get to another platform, the player instead falls from the top of the screen onto the start position, causing the player to need to start from the beginning again |
| 7. Time trial | Create a new Canvas and UI Text element that displays a timer on screen |
| 8. Clock's ticking | Create a script called Timer and attach to the Player. Timer should have a public Text variable called Timer Text for the TimerText Text object |
| 9. Finish line | Create a script called WinTrigger and attach to WinFlag |
| 10. The sky's the limit | In the Unity Asset Store, find Farland Skies - Cloudy Crown, a free set of skyboxes. Add them to a folder called Skyboxes in the Assets/Materials folder in your 0x05-unity-assets project |
| 11. The great outdoors | Replace your cube placeholders with the 3D models. The 3D models need mesh colliders otherwise the player cannot jump on them. Make sure the player can jump and move between platforms, that the distance and the player’s jump are reasonable, and that the player can reach the end from the starting point |
| 12. Environmental awareness | From the Nature Pack asset package in your Models folder, add trees, rocks, flowers, etc. to the platforms as you like. Organize your objects in your Hierarchy using empty GameObjects |
| 13. What's left of the flag | Download this flag model. Place it in the Models directory. Add Flag to your scene and make it a child of the WinFlag GameObject. The pole of the flag should be positioned inside WinFlag‘s collider. Resize or reposition the collider if necessary |
| 14. (Sea)horse race | Place it in a new directory called Textures |
| 15. Under development | Create three builds of Level01 in a directory called Builds |

### Credits

[Skyboxes: Farland Skies - Cloudy Crown](https://assetstore.unity.com/packages/2d/textures-materials/sky/farland-skies-cloudy-crown-60004)
[Models: Kenney's Nature Pack Extended](https://kenney.nl/assets/nature-pack-extended)
