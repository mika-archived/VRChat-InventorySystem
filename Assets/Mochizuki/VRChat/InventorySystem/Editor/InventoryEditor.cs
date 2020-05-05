/*-------------------------------------------------------------------------------------------
 * Copyright (c) Fuyuno Mikazuki / Natsuneko. All rights reserved.
 * Licensed under the MIT License. See LICENSE in the project root for license information.
 *------------------------------------------------------------------------------------------*/

using UnityEditor;

using UnityEngine;

namespace Mochizuki.VRChat.InventorySystem
{
    public class InventoryEditor : EditorWindow
    {
        private GameObject _avatar;
        private Collider _collider;
        private GameObject _object;
        private GameObject _parent;
        private GameObject _prefab;

        [MenuItem("Mochizuki/VRChat/Inventory Editor")]
        public static void ShowWindow()
        {
            var window = GetWindow<InventoryEditor>();
            window.titleContent = new GUIContent("Inventory Editor");

            window.Show();
        }

        public void OnGUI()
        {
            EditorGUILayout.Space();

            _prefab = ObjectPicker("Inventory Prefab", _prefab);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Your Inventory Information:");

            _avatar = ObjectPicker("Avatar", _avatar);
            _collider = ObjectPicker("Collider", _collider);
            _object = ObjectPicker("Object", _object);
            _parent = ObjectPicker("Inventory Parent", _parent);

            EditorGUI.BeginDisabledGroup(_prefab == null || _avatar == null || _collider == null || _object == null || _parent == null);

            if (GUILayout.Button("Unpack and Configure Prefab (Breaking)")) ConfigurePrefab();

            EditorGUI.EndDisabledGroup();
        }

        private static T ObjectPicker<T>(string label, T obj) where T : Object
        {
            return EditorGUILayout.ObjectField(new GUIContent(label), obj, typeof(T), true) as T;
        }

        private void ConfigurePrefab()
        {
            PrefabUtility.UnpackPrefabInstance(_prefab, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);

            // configure
            foreach (var transform in _prefab.GetComponentsInChildren<Transform>(true))
                switch (transform.name)
                {
                    case "InventoryObject":
                        transform.parent = _object.transform.parent;
                        transform.localPosition = Vector3.zero;
                        transform.localRotation = Quaternion.identity;
                        transform.localScale = Vector3.one;
                        break;

                    case "Object":
                        _object.transform.parent = transform;
                        break;

                    case "PUT_YOUR_INVENTORY_ITEM_HERE":
                        DestroyImmediate(transform.gameObject);
                        break;

                    case "InventoryTrigger":
                        transform.parent = _parent.transform;
                        transform.localPosition = Vector3.zero;
                        transform.localRotation = Quaternion.identity;
                        transform.localScale = Vector3.one;
                        break;

                    case "Trigger":
                        var trigger = transform.gameObject.GetComponent<ParticleSystem>();
                        trigger.trigger.SetCollider(0, _collider.transform);
                        break;
                }

            // cleanup
            DestroyImmediate(_prefab);

            _avatar = null;
            _collider = null;
            _object = null;
            _parent = null;
            _prefab = null;
        }
    }
}