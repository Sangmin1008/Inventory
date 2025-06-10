using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemRegistrySO))]
public class ItemRegistrySOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ItemRegistrySO registry = (ItemRegistrySO)target;

        if (GUILayout.Button("아이템 자동 등록", GUILayout.Height(40)))
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