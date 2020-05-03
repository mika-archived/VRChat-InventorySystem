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
2. Import UnityPackage to your avatar project.
3. Drag and Drop `InventorySystem_DefaultXXX.prefab` to your hierarchy tree.
4. Unpack Prefab.

### Configure Collider

1. Move `Slot[X]_InventoryTrigger` to any location on the avatar.
2. Reset Transform.
3. Replace `Shims` Sphere to `GameObject` or other objects.
   - NOTE: The object name must be `Shims`.
4. Configure Collider-s Triggers in `Particle System`.
   1. Replace `COLLIDER` in Colliders to your hand.
5. Delete `COLLIDER` and `INVENTORY_TRIGGERS`.

### Configure Object(s)

1. Move `Slot[X]_InventoryObject` to any location on the avatar.
   - NOTE: I recommend placing the child of the GameObject that attached Parent Constraint.
2. Reset Transform.
3. Move your object to brother of `PUT_YOUR_INVENTORY_ITEM_HERE`.
4. Delete `PUT_YOUR_INVENTORY_ITEM_HERE` and `INVENTORY_OBJECTS`.

### Cleanup Prefab

1. Delete `InventorySystem_DefaultXXX`.

## Note

This prefab is optimized for [Shapell](https://booth.pm/ja/items/1349366) (and other common humanoid avatars).  
If you want to use a larger/smaller avatar than the common humanoid avatar, change the values to below.

- `(PrefabRoot)/INVENTORY_TRIGGERS/Slot[X]_InventoryTrigger` - Scale in Transform
- `(PrefabRoot)/INVENTORY_TRIGGERS/Slot[X]_InventoryTrigger/Collider` - Radius Scale in Triggers in Particle System

## Known Bugs

- If you want to use Activated to Deactivated Inventory (`DefaultON`), the object must be lazy initialized.

## References

- [Avatars - How to play an animation on particle death.](https://vrcat.club/threads/how-to-play-an-animation-on-particle-death.2993/)
- [Avatars - In-depth guide to animator inventory systems, logic, and syncing!](https://vrcat.club/threads/in-depth-guide-to-animator-inventory-systems-logic-and-syncing-w-unitypackage.2858/)
- [【Unity】新・Animator の GameObject を非アクティブにするとステートマシンがリセットされる問題の対処法](http://tsubakit1.hateblo.jp/entry/2018/10/04/233000)
- [Unity Workaround for KeepAnimatorControllerStateOnDisable](https://github.com/mika-sandbox/Unity-KeepAnimatorControllerStateOnDisable)
