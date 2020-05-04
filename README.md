# VRChat InventorySystem

Experimental Unity Project that provides Inventory System in VRChat.

> NOTICE: THIS PROJECT IS EXPERIMENTAL. PLEASE USE IT AT YOUR OWN RISK.

## Requirements

- Unity 2018.3 or higher
  - This system used new features in Unity 2018.3.
- VRChat 2020.1 or higher

## How to use

### Preparation

1. Download UnityPackage from [Releases](https://github.com/mika-f/VRChat-InventorySystem/releases).
1. Import UnityPackage to your avatar project.
1. Drag and Drop `InventorySystem_DefaultXXX.prefab` to your hierarchy tree.

### Automatically Setup (Recommend)

1. Open `Inventory Editor` from `Mochizuki/VRChat/Inventory Editor` in menubar.
1. Drag and Drop `InventorySystem_DefaultXXX` into the `Inventory Prefab` field.
1. Drag and Drop avatar GameObject into the `Avatar` field.
1. Drag and Drop collider GameObject into the `Collider` field.
1. Drag and Drop object that you want to in and out into the `Object` field.
1. Drag and Drop trigger's parent GameObject into the `Parent` field.
1. Click `Unpack and Configure Prefab (Breaking)`

### Manual Setup

1. Unpack Prefab.
1. Move `InventoryTrigger` to any location on the avatar.
1. Reset Transform.
1. Replace `Shims` Sphere to `GameObject` or other objects.
   - NOTE: The object name must be `Shims`.
1. Configure Collider-s Triggers in `Particle System`.
   1. Replace `COLLIDER` in Colliders to your hand.
1. Delete `COLLIDER` and `INVENTORY_TRIGGER`.
1. Move `InventoryObject` to any location on the avatar.
   - NOTE: I recommend placing the child of the GameObject that attached Parent Constraint.
1. Reset Transform.
1. Move your object to brother of `PUT_YOUR_INVENTORY_ITEM_HERE`.
1. Delete `PUT_YOUR_INVENTORY_ITEM_HERE` and `INVENTORY_OBJECT`.
1. Delete `InventorySystem_DefaultXXX`.

## Note

This prefab is optimized for [Shapell](https://booth.pm/ja/items/1349366) (and other common humanoid avatars).  
If you want to use a larger/smaller avatar than the common humanoid avatar, change the values to below.

- `(PrefabRoot)/INVENTORY_TRIGGER/InventoryTrigger` - Scale in Transform
- `(PrefabRoot)/INVENTORY_TRIGGER/InventoryTrigger/Collider` - Radius Scale in Triggers in Particle System

## Known Bugs

- Depending on how long it took to initialize, it may appear to be in an incorrect state.
  - Currently, we have confirmed the symptoms only on Unity Editor

## References

- [Avatars - How to play an animation on particle death.](https://vrcat.club/threads/how-to-play-an-animation-on-particle-death.2993/)
- [Avatars - In-depth guide to animator inventory systems, logic, and syncing!](https://vrcat.club/threads/in-depth-guide-to-animator-inventory-systems-logic-and-syncing-w-unitypackage.2858/)
- [【Unity】新・Animator の GameObject を非アクティブにするとステートマシンがリセットされる問題の対処法](http://tsubakit1.hateblo.jp/entry/2018/10/04/233000)
- [Unity Workaround for KeepAnimatorControllerStateOnDisable](https://github.com/mika-sandbox/Unity-KeepAnimatorControllerStateOnDisable)
