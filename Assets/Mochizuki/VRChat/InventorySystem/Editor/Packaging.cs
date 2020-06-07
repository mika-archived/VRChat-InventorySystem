/*-------------------------------------------------------------------------------------------
 * Copyright (c) Fuyuno Mikazuki / Natsuneko. All rights reserved.
 * Licensed under the MIT License. See LICENSE in the project root for license information.
 *------------------------------------------------------------------------------------------*/

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
        private const string UnityPackageName = "VRChat-InventorySystem.unitypackage";
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
            _projectRoot = Path.Combine(Application.dataPath, "Mochizuki", "VRChat", "InventorySystem");
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
                CreatePackage();

            EditorGUI.EndDisabledGroup();
        }

        private string ReadCurrentVersion()
        {
            if (!File.Exists(_versionMetaPath))
                return "0.0.0";
            using (var sr = new StreamReader(_versionMetaPath)) return sr.ReadLine();
        }

        private void WriteNewVersion()
        {
            using (var sw = new StreamWriter(_versionMetaPath))
                sw.WriteLine(_version);
        }

        private void CreatePackage()
        {
            var assets = Directory.GetFiles(_projectRoot, "*", SearchOption.AllDirectories)
                                  .Where(w => Path.GetExtension(w) != ".meta" && !w.EndsWith("Packaging.cs"))
                                  .Select(w => $"Assets{w.Replace(Application.dataPath, "").Replace("\\", "/")}")
                                  .ToArray();

            var destRoot = Path.Combine(Application.dataPath, "Mochizuki", "Packages", $"VRChat-InventorySystem-{_version}");

            if (!Directory.Exists(destRoot))
                Directory.CreateDirectory(destRoot);

            AssetDatabase.ExportPackage(assets, Path.Combine(destRoot, UnityPackageName), ExportPackageOptions.Default);
            if (File.Exists(Path.Combine(destRoot, "README.txt")))
                File.Delete(Path.Combine(destRoot, "README.txt"));
            File.Copy(Path.Combine(_projectRoot, "README.txt"), Path.Combine(destRoot, "README.txt"));

            WriteNewVersion();

            var dest = Path.Combine(Application.dataPath, "Mochizuki", "Packages", $"VRChat-InventorySystem-{_version}.zip");
            if (File.Exists(dest))
                File.Delete(dest);
            ZipFile.CreateFromDirectory(destRoot, dest, CompressionLevel.Optimal, true);

            Directory.Delete(destRoot, true);
        }
    }
}