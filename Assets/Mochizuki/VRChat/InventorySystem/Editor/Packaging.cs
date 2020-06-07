/*-------------------------------------------------------------------------------------------
 * Copyright (c) Fuyuno Mikazuki / Natsuneko. All rights reserved.
 * Licensed under the MIT License. See LICENSE in the project root for license information.
 *------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

using Semver;

using UnityEditor;

using UnityEngine;

using CompressionLevel = System.IO.Compression.CompressionLevel;

namespace Mochizuki.VRChat.InventorySystem
{
    public class Packaging : EditorWindow
    {
        private const string UnityProjectName = "InventorySystem";
        private const string UnityPackageName = "VRChat-InventorySystem.unitypackage";
        private string _destRoot;
        private string _projectRoot;
        private string _version;
        private string _versionMetaPath;

        [MenuItem("Mochizuki/VRChat/InventorySystem/Create Package")]
        public static void ShowWindow()
        {
            var window = GetWindow<Packaging>();
            window.titleContent = new GUIContent("Create a new package");
            window.Show();
        }

        public void OnEnable()
        {
            _destRoot = Path.Combine(Application.dataPath, "Mochizuki", "Packages");
            _projectRoot = Path.Combine(Application.dataPath, "Mochizuki", "VRChat", UnityProjectName);
            _version = ReadCurrentVersion();
            _versionMetaPath = Path.Combine(_projectRoot, "VERSION");
        }

        public void OnGUI()
        {
            EditorGUILayout.Space();

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.TextField("Current Version", ReadCurrentVersion());
            EditorGUI.EndDisabledGroup();
            _version = EditorGUILayout.TextField("Deployment Version", _version);

            SemVersion.TryParse(ReadCurrentVersion(), out var oldVersion);
            SemVersion.TryParse(_version, out var newVersion);
            var isValidNewVersion = oldVersion != null && newVersion != null && newVersion > oldVersion;
            EditorGUI.BeginDisabledGroup(!isValidNewVersion);

            if (GUILayout.Button("Create Deployment Package"))
            {
                EditorUtility.DisplayProgressBar("Creating packages...", "", 0.0f);

                CreateProductionPackage();
                CreateTrialPackage();
                WriteNewVersion();

                EditorUtility.ClearProgressBar();
            }

            EditorGUI.EndDisabledGroup();
        }

        private string ReadCurrentVersion()
        {
            if (!File.Exists(_versionMetaPath))
                return "0.0.0";

            using (var sr = new StreamReader(_versionMetaPath))
                return sr.ReadLine();
        }

        private void WriteNewVersion()
        {
            using (var sw = new StreamWriter(_versionMetaPath))
                sw.WriteLine(_version);
        }

        private void CreateProductionPackage()
        {
            var assets = Directory.GetFiles(_projectRoot, "*", SearchOption.AllDirectories)
                                  .Where(w => Path.GetExtension(w) != ".meta" && !w.EndsWith("Packaging.cs"))
                                  .Select(w => $"Assets{w.Replace(Application.dataPath, "").Replace("\\", "/")}")
                                  .ToList();

            var dest = Path.Combine(_destRoot, $"VRChat-{UnityProjectName}-{_version}");

            CreatePackage(dest, assets);
        }

        private void CreateTrialPackage()
        {
            var assets = Directory.GetFiles(_projectRoot, "*", SearchOption.AllDirectories)
                                  .Where(w => Path.GetExtension(w) != ".meta" && !w.EndsWith("Packaging.cs"))
                                  .Where(w => !w.Contains("Animation") && !w.Contains("AnimationControllers"))
                                  .Where(w => !w.EndsWith("InventorySystem_DefaultOFF_V3.prefab"))
                                  .Select(w => $"Assets{w.Replace(Application.dataPath, "").Replace("\\", "/")}")
                                  .ToList();
            var dest = Path.Combine(_destRoot, $"VRChat-{UnityProjectName}-Trial-{_version}");

            CreatePackage(dest, assets);
        }

        private void CreatePackage(string dest, List<string> assets)
        {
            if (!Directory.Exists(dest))
                Directory.CreateDirectory(dest);

            AssetDatabase.ExportPackage(assets.ToArray(), Path.Combine(dest, UnityPackageName), ExportPackageOptions.IncludeDependencies);

            if (File.Exists(Path.Combine(dest, "README.txt")))
                File.Delete(Path.Combine(dest, "README.txt"));
            File.Copy(Path.Combine(_projectRoot, "README.txt"), Path.Combine(dest, "README.txt"));

            ZipFile.CreateFromDirectory(dest, $"{dest}.zip", CompressionLevel.Optimal, true);

            Directory.Delete(dest, true);
        }
    }
}