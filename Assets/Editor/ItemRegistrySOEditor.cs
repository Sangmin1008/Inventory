using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemRegistrySO))]
public class ItemRegistrySOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ItemRegistrySO registry = (ItemRegistrySO)target;
        
        GUILayout.Space(10);
        
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontStyle = FontStyle.Bold;
        buttonStyle.fixedHeight = 32;
        buttonStyle.fontSize = 12;
        buttonStyle.margin = new RectOffset(4, 4, 10, 10);

        if (GUILayout.Button("아이템 자동 등록", buttonStyle))
        {
            string[] guids = AssetDatabase.FindAssets("t:GenericItemDataSO", new[] { "Assets/Datas/ItemData" });

            registry.ClearItems();

            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                GenericItemDataSO item = AssetDatabase.LoadAssetAtPath<GenericItemDataSO>(path);
                if (item != null)
                {
                    registry.AddItem(item);
                }
            }

            EditorUtility.SetDirty(registry);
        }
    }
}