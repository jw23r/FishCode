﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FishDataCollection))]
public class FishDataCollectionInspector : Editor
{
    #region On Inspector GUI
    public override void OnInspectorGUI()
    {
        // Make sure object is up-to-date and we are displaying correct values:
        serializedObject.Update();

        // Draw default body content:
        base.OnInspectorGUI();

        // Draw 'refresh' button:
        if (GUILayout.Button("Refresh"))
        {
            // A list of all matching assets in the project that we will populate:
            List<FishDataObject> assetsInProject = new List<FishDataObject>();

            // Get guids for assets that match the given type:
            string[] guids = AssetDatabase.FindAssets("t:FishDataObject");

            for (int i = 0; i < guids.Length; i++)
            {
                // Using the asset guid, get a full path to the asset itself:
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);

                // Using the asset path, load the object itself:
                FishDataObject asset = AssetDatabase.LoadAssetAtPath<FishDataObject>(assetPath);

                // If nothing went wrong, then add the asset to our list:
                if (asset != null) assetsInProject.Add(asset);
            }

            // Check if the target of this inspector is a SimpleDataCollection and cast it as that type:
            if (target is FishDataCollection simpleDataCollection)
            {
                // Finally, set the new list of objects on our collection:
                simpleDataCollection.SetDataObjectList(assetsInProject);
            }
        }

        // Apply any changes we made to the object:
        serializedObject.ApplyModifiedProperties();
    }
    #endregion On Inspector GUI (end)
}