using UnityEditor;
using UnityEngine;

namespace CustomScriptTemplates
{
    /// <summary>
    /// Custom <see cref="Editor"/> for <see cref="PackageExporter"/>
    /// </summary>
    [CustomEditor(typeof(PackageExporter))]
    internal sealed class PackageExporterEditor : Editor
    {
        #region Fields
        /// <summary>
        /// Reference to the <see cref="PackageExporter"/>.
        /// </summary>
        private PackageExporter packageExporter;
        #endregion
        
        #region Methods
        private void OnEnable()
        {
            this.packageExporter = (PackageExporter)target;
        }

        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();
            
            GUILayout.Space(EditorGUIUtility.singleLineHeight);
            
            if (GUILayout.Button("Export Package"))
            {
                this.packageExporter.ExportPackage();
            }
        }
        #endregion
    }
}