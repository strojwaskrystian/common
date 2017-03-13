using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace sk.wpf.common.Helper
{
    public class FolderBrowserEditorHelper : UITypeEditor
    {

        /// <summary>
        /// Get the edit style for the editor
        /// </summary>
        /// <param name="context">Context descriptor</param>
        /// <returns>Edit style</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Edit a value
        /// </summary>
        /// <param name="context">Context descriptor</param>
        /// <param name="provider">Provider</param>
        /// <param name="value">Edited value</param>
        /// <returns>Selected folder</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Get the current value
            string sPath = Convert.ToString(value);
            // Create a browser dialog
            using (FolderBrowserDialog fbdDialog = new FolderBrowserDialog())
            {
                // If there is a current path, select the path in the browser dialog
                if (!string.IsNullOrEmpty(sPath) && Directory.Exists(sPath))
                    fbdDialog.SelectedPath = sPath;

                // If there is a context
                if (context != null && context.PropertyDescriptor != null)
                {
                    // Get the [Description], [DisplayName] or [Name] to display in the browser dialog
                    string sCaption = context.PropertyDescriptor.Description;
                    if (string.IsNullOrEmpty(sCaption))
                        sCaption = context.PropertyDescriptor.DisplayName;
                    if (string.IsNullOrEmpty(sCaption))
                        sCaption = context.PropertyDescriptor.Name;
                    // Display in the browser dialog
                    fbdDialog.Description = sCaption;
                }
                // If the folder selection has been validated
                if (fbdDialog.ShowDialog() == DialogResult.OK)
                    // Get the selected folder
                    sPath = fbdDialog.SelectedPath;
            }
            // Return the selected folder
            return sPath;
        }
    }
}
