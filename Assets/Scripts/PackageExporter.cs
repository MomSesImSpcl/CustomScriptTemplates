using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CustomScriptTemplates
{
    /// <summary>
    /// Creates and exports the package.
    /// </summary>
    internal sealed class PackageExporter : MonoBehaviour
    {
        #region Inspector Fields
        [Tooltip("Add all assets that should be exported with the package.")]
        [SerializeField] private List<Object> assets = new List<Object>();
        #endregion

        #region Constants
        /// <summary>
        /// The name of this plugin.
        /// </summary>
        private const string PACKAGE_NAME = "CustomScriptTemplates";
        #endregion
        
        #region Methods
        /// <summary>
        /// Exports all assets in <see cref="assets"/> into a <c>.unitypackage</c>.
        /// </summary>
        internal void ExportPackage()
        {
            var _exportPath = EditorUtility.SaveFilePanel("Export Package", string.Empty, PACKAGE_NAME, "unitypackage");

            if (string.IsNullOrWhiteSpace(_exportPath))
            {
                return;
            }
            
            var _assetPathNames = (from _asset in this.assets where _asset != null select AssetDatabase.GetAssetPath(_asset)).ToArray();

            AssetDatabase.ExportPackage(_assetPathNames, _exportPath, ExportPackageOptions.Recurse);
        }
        #endregion
    }
}