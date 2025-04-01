<h1 align="center"> Editor Tool Examples </h1> 
<p align="center">
  Project Files
  <br>
  <img src="https://img.shields.io/badge/Unity-6000.0.33f1-lightgrey" />
  <img src="https://img.shields.io/badge/Render Pipeline-Universal 3D-orange" />
</p>

This repository inlcudes editor tool demos for TAMK Games Academy Spring 2025

Author: Lassi Ahonen

## 00-Attributes
Includes demo for two custom attributes that affect how serialized properties are drawn in the inspector.

[Demo Files](/EditorToolDemo/Assets/Demo/00-Attributes)

[Demo Scene](/EditorToolDemo/Assets/Scenes)

### Inspector Read Only Attribute
Attribute that can be used on fields and properties to make them disabled in inspector making them grayed out and unmodifiable.

![ReadOnlyAttributeCode](https://github.com/user-attachments/assets/1aa400de-9b9f-4835-9acf-7ad5e630bca3)

![ReadOnlyAttribute](https://github.com/user-attachments/assets/8ddc0c8b-1d50-43d2-9049-251395e8d0e9)

### Condition Attribute
Attribute that checks boolean value and either disables or hides fields or properties if the condition is false.

![ConditionAttributesCode](https://github.com/user-attachments/assets/3c2ee984-0727-4c1e-8381-65c031c42278)

![DisabledCondition](https://github.com/user-attachments/assets/fe2e216f-5370-4e6f-8308-25940aa6f2c1)

![EnabledCondition](https://github.com/user-attachments/assets/0b1dfa47-edab-40ae-9b98-6378bd9f4dea)

## 01-IMGUI
This demo shows how you can modify scene objects through editors and how you can create editor windows with IMGUI.

[Demo Files](/EditorToolDemo/Assets/Demo/01-IMGUI)

[Demo Scene](/EditorToolDemo/Assets/Scenes)

### Enemy Tracker
The window can be opened from `Window > Enemy Tracker`.


Editor window that tracks all enemies in the scene and displays their name and health. Enemies can also be killed from the editor window by pressing kill button.

![IMGUIEditorWindow](https://github.com/user-attachments/assets/abf48f10-bcac-424b-9eff-404d0a5cdaa2)


## 02-UI Toolkit Window
Simple editor window that can spawn game objects to a scene. 

[Demo Files](/EditorToolDemo/Assets/Demo/02-UIToolkit-Window)

[Demo Scene](/EditorToolDemo/Assets/Scenes)

### Game Object Spawner
The window can be opened from `Window > Game Object Spawner`.

Spawned objects can be given a spawn count, position and rotation. 

![SpawnerEditorWindow](https://github.com/user-attachments/assets/10957299-cbbc-48bd-bfa7-81bf3ac3d171)


## 03-UI Toolkit Inspector
Includes demo for drawing custom data types in the inspector using UXML, USS and property drawers.

[Demo Files](/EditorToolDemo/Assets/Demo/03-UIToolkit-Inspector)

[Demo Scene](/EditorToolDemo/Assets/Scenes)

### FloatRange
Struct that stores min and max floating point values and can be used to get random values inside the range.
The values are drawn on a single line in the inspector.

![FloatRangeCode](https://github.com/user-attachments/assets/8f291ab9-8c4e-4b4d-bfae-0ceca9971c16)

![FloatRangeInspector](https://github.com/user-attachments/assets/126d8574-3fe5-4629-b57c-925a29a79954)



