# 3D Heart puzzle game

<img src="https://github.com/user-attachments/assets/1291ecf9-4218-4079-a283-3fe43e06abe3" width="400"/>
<img src="https://github.com/user-attachments/assets/161f400c-360a-46cc-8945-2dc663b2b6ef" width="400"/>
<img src="https://github.com/user-attachments/assets/84e77fea-a38a-4a06-b474-792a8976d911" width="400"/>
<img src="https://github.com/user-attachments/assets/fa8cd559-b3af-48fd-91b9-3f46a6443570" width="400"/>
<img src="https://github.com/user-attachments/assets/3634bec1-129e-4f22-afa5-2377d7296235" width="400"/>
<img src="https://github.com/user-attachments/assets/b105a974-f5e4-4a57-85ff-30fb5c24c4fb" width="400"/>

---

https://github.com/user-attachments/assets/22b00229-c0b2-474a-82e1-c16e8aec54a8

## Overview
A 3D heart puzzle game created using unity and blender to help students figure out the heart parts making it fun and usefull at the same time.

---

## Table of contents
- [Blender process](#blender-process)
- [Unity process](#unity-process)
   - [GUI](#gui)
   - [Core game](#core-game)
- [Quick Preview](#quick-preview)
---

## Blender process
firstly we have to choses the right model to process it on blender using its features. I'm going to put the right steps I took to generate a Mesh-Divided heart model 
1. Import the right model
   - you can build a heart model in belnder or just select it from any library on google
   - open blender and import your model
2. Select the knife
   - start cutting off your heart model into multiple pieces
   - don't move the parts away, keep them united. you will need them as one unit in unity 
   - make the edges smooth and seamless (you can search to find the right way)
   
        <img src="https://github.com/user-attachments/assets/1291ecf9-4218-4079-a283-3fe43e06abe3" width="400"/>

3. Exprot your model
   - after finishing the whole work on blender, export you file into .fbx
   - keep your model in a safe place
  
        <img src="https://github.com/user-attachments/assets/161f400c-360a-46cc-8945-2dc663b2b6ef" width="400"/>

---

## Unity process
after preparing our model in blender, we will pass it to Unity to build our puzzle game. But before going on the core game, we have just to build a frindly GUI for the user. Here we go:
### GUI
1. Create a Canvas (Your Screen’s “Drawing Board”)
   - In Unity’s Hierarchy window:
   → Right-click → UI → Canvas.
   This is where all your buttons/text/images will live.

2. Add UI Elements (Buttons, Text, etc.)
   - For a button:
   → Right-click on the Canvas → UI → Button.
   → A Text object will auto-appear inside it. Click the button to rename the text (e.g., “Start Game”).

   - For text:
   → Right-click on the Canvas → UI → Text.
   → Type your message in the Text field (e.g., “Score: 0”).

3. Adjust Size & Position
   - Select your UI element (button/text) in the Hierarchy.
   
   - In the Inspector window:
   → Use the Rect Transform tool (the blue rectangle) to drag and resize it.
   → Or type exact numbers for Pos X, Pos Y, Width, and Height.

4. Make It Look Nice (Optional)
   - Change colors/fonts:
   → Select the UI element → In the Inspector, tweak:
   
      - Text Color, Font Style (for text).
      
      - Source Image (for custom button graphics).

5. Make Buttons DO Something
   - Create a new C# script (e.g., MenuManager.cs):
   → In Unity: Assets → Create → C# Script.
   → Double-click to open it in your code editor.

   - Add this code to the script:
      ``` bash
         using UnityEngine;  
         using UnityEngine.UI;  // Required for UI
         
         public class MenuManager : MonoBehaviour {
             public Button yourButtonName; // Assign in Unity Inspector

             void Start() {
                 // Make the button call a function when clicked
                 yourButtonName.onClick.AddListener(YourFunction);
             }
         
             void YourFunction() {
                 Debug.Log("Button clicked!"); 
                 // Add your action here (e.g., load a scene)
             }
         }
      ```
   - Link the script to your button:
   → Drag the script onto the Canvas or any GameObject.
   → Select the script in the Inspector → Drag your button into the yourButtonName slot.
6. Test It!
   - Press Play in Unity.
   - Click the button to see your message in the Console (or trigger your action).

       <img src="https://github.com/user-attachments/assets/84e77fea-a38a-4a06-b474-792a8976d911" width="400"/>
### Core game
after creating the GUI let's build the core game. we have to include the modle in unity. Our work is divided into 5 principles including: camera, drag & drop, snap, randomize and Timer. let's talk about each one of them: 
#### 1. Camera 
   ##### Role in Your Game:
   The camera is how players view and interact with the heart pieces. Since it’s a 3D puzzle, you’ll want players to see the heart from angles that make solving intuitive.
   ##### How to Use It:
   - Isometric View: Set the camera at a 45-degree angle to show all heart pieces clearly (like a chessboard view).
   - Zoom & Rotate: Let players rotate the heart or zoom in/out to inspect pieces (e.g., for intricate ventricle or atrium parts).
   - Focus on Selected Piece: When a player clicks a piece, smoothly move the camera closer to it.

      <img src="https://github.com/user-attachments/assets/141d5c5a-0558-4764-8999-174e26699481" width="400"/>

#### 2. Drag & Drop
   ##### Role in Your Game:
   Players need to drag heart pieces and place them correctly. This mechanic is the core of your puzzle!
   ##### How to Use It:
   - 3D Dragging: Use OnMouseDrag() or raycasting to let players click and drag pieces.
   - Visual Feedback: Highlight a piece when hovered (e.g., glow) to show it’s interactable.
     
      <img src="https://github.com/user-attachments/assets/3634bec1-129e-4f22-afa5-2377d7296235" width="400"/>

#### 3. Snap
   ##### Role in Your Game:
   When players place a heart piece near its correct spot, it should “snap” into place for a satisfying fit.
   ##### How to Use It:
   - Proximity Check: If a piece is close to its target position, snap it.
   - Rotation Alignment: Ensure the piece’s rotation matches the target (e.g., a ventricle fragment aligns with the heart’s chambers).

      ![SNAP.gif](https://github.com/user-attachments/assets/b66357b0-8da2-43c5-b071-752ba37aa287)

#### 4. Randomize
   ##### Role in Your Game:
   Shuffle the heart pieces at the start of each level to create fresh challenges.
   ##### How to Use It:
   - Random Positions: Spawn pieces in random locations around the heart.
   - Random Rotations: Rotate pieces randomly to increase difficulty.
#### 5. Timer
   ##### Role in Your Game:
   Add urgency! Players must solve the puzzle before time runs out (e.g., a "heartbeat" timer).
   ##### How to Use It:
   - Countdown UI: Display a timer bar or numeric counter.
   - Penalty/Reward: Lose time for wrong moves, gain time for correct snaps.

<img src="https://github.com/user-attachments/assets/b105a974-f5e4-4a57-85ff-30fb5c24c4fb" width="400"/>

---

## Quick Preview
   ### 1. Model segmentation
   ![knif tool](https://github.com/user-attachments/assets/1291ecf9-4218-4079-a283-3fe43e06abe3)
   ![heart parts](https://github.com/user-attachments/assets/161f400c-360a-46cc-8945-2dc663b2b6ef)
   ### 2. GUI desing
   ![GUI](https://github.com/user-attachments/assets/84e77fea-a38a-4a06-b474-792a8976d911)
   ### 3. camera, drag & drop, snap, randomize, timer
   ![core1](https://github.com/user-attachments/assets/3634bec1-129e-4f22-afa5-2377d7296235)
   ![code](https://github.com/user-attachments/assets/fa8cd559-b3af-48fd-91b9-3f46a6443570)
   ![core2](https://github.com/user-attachments/assets/b105a974-f5e4-4a57-85ff-30fb5c24c4fb)

   
---

## Submitted to:
- Dr. Tamer Basha
  All rights reserved © 2024 - Systems & Biomedical Engineering, Cairo University (Class 2028)
