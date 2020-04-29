# VRChat InventorySystem

Experimental Unity Project that provides Inventory System in VRChat.

> NOTICE: THIS PROJECT IS EXPERIMENTAL. PLEASE USE IT AT YOUR OWN RISK.

## Requirements

- Unity 2018.3 or higher
  - This system used new features in Unity 2018.3.
- VRChat 2020.1 or higher

## How to use

1. Download UnityPackage from [Releases](https://github.com/mika-f/VRChat-InventorySystem/releases).
2. Import UnityPackage to your avatar project.

## Note

This prefab is optimized for [Shapell](https://booth.pm/ja/items/1349366) (and other common humanoid avatars).  
If you want to use a larger/smaller avatar than the common humanoid avatar, change the values to below.

- `(PrefabRoot)/INVENTORY_TRIGGERS/Slot[A]_InventoryTrigger` - Scale in Transform
- `(PrefabRoot)/INVENTORY_TRIGGERS/Slot[A]_InventoryTrigger/Collider` - Radius Scale in Triggers in Particle System

## Known Bugs

- If you want to use Activated to Deactivated Inventory (`DefaultON`), the object must be lazy initialized.

## References

- [Avatars - How to play an animation on particle death.](https://vrcat.club/threads/how-to-play-an-animation-on-particle-death.2993/)
- [Avatars - In-depth guide to animator inventory systems, logic, and syncing!](https://vrcat.club/threads/in-depth-guide-to-animator-inventory-systems-logic-and-syncing-w-unitypackage.2858/)
- [【Unity】新・Animator の GameObject を非アクティブにするとステートマシンがリセットされる問題の対処法](http://tsubakit1.hateblo.jp/entry/2018/10/04/233000)
