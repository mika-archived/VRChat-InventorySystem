# VRChat InventorySystem

Experimental Unity Project that provides Inventory System in VRChat.

> NOTICE: THIS PROJECT IS EXPERIMENTAL. PLEASE USE IT AT YOUR OWN RISK.

## Requirements

- Unity 2018.3 or higher
  - This system used new features in Unity 2018.3.
- VRChat 2020.1 or higher

## Note

This prefab is optimized for [Shapell](https://booth.pm/ja/items/1349366) (and other common humanoid avatars).  
If you want to use a larger/smaller avatar than the common humanoid avatar, change the values to below.

- `(PrefabRoot)/Inventory/Slot[A]_Inventory` - Scale in Transform
- `(PrefabRoot)/Inventory/Slot[A]_Inventory/Collider` - Radius Scale in Triggers in Particle System

## Known Bugs

- When deactivate an item in your inventory, the item flashed momentarily.
  - This is an issue with the mechanics using and I can't solve it.
  - The branch `non-blinking-inventory` try to resolve this problem.

## References

- [Avatars - How to play an animation on particle death.](https://vrcat.club/threads/how-to-play-an-animation-on-particle-death.2993/)
- [Avatars - In-depth guide to animator inventory systems, logic, and syncing!](https://vrcat.club/threads/in-depth-guide-to-animator-inventory-systems-logic-and-syncing-w-unitypackage.2858/)
- [【Unity】新・Animator の GameObject を非アクティブにするとステートマシンがリセットされる問題の対処法](http://tsubakit1.hateblo.jp/entry/2018/10/04/233000)
