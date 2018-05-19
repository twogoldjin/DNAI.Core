﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Core.Plugin.Unity.Generator
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class GeneratedCodeTemplate : GeneratedCodeTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"using System;
using UnityEngine;
using UnityEngine.Events;
using CoreCommand;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEditor;
using Core.Plugin.Unity.Editor.Conditions.Inspector;
using Core.Plugin.Unity.Editor.Conditions;

namespace DNAI.");
            
            #line 18 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(@"
{
	[Serializable]
	public class UnityEventOutputChange : UnityEvent<EventOutputChange>
	{
	}

	[System.Serializable]
    public class ConditionItem
    {
		[SerializeField]
        public ACondition cdt;
        public string Test;

        public static readonly string[] Outputs = new string[]
        {
			");
            
            #line 34 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Outputs)
			{ 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\"");
            
            #line 36 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\",\r\n\t\t\t\t\"System.String str\",\r\n\t\t\t");
            
            #line 38 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"        };

		public UnityEventOutputChange OnOutputChanged;
		public int CallbackCount = 0;

		private float drawSize = 0;

		public float ItemSize
        {
            get { return 110f + CallbackCount * 90f + drawSize; }
        }

		public int SelectedIndex = 0;

		public string SelectedOutput { get { return Outputs[SelectedIndex]; } }

		public float Draw(Rect rect)
		{
			//if (cdt != null)
			Debug.Log(""cdt type = "" + cdt.GetType());
				drawSize = cdt.Draw(rect);
			return drawSize;
		}

		public bool Evaluate()
		{
			if (cdt != null)
				return cdt.Evaluate();
			return true;
		}
    }

	[CustomEditor(typeof(");
            
            #line 71 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("), true)]\r\n    public class ListExampleInspector : UnityEditor.Editor\r\n    {\r\n   " +
                    "     private ReorderableList reorderableList;\r\n\t\tprivate int _selectedIndex;\r\n\r\n" +
                    "        private ");
            
            #line 77 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" listExample\r\n        {\r\n            get\r\n            {\r\n                return t" +
                    "arget as ");
            
            #line 81 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(";\r\n            }\r\n        }\r\n\r\n\t\tprivate void OnEnable()\r\n        {\r\n            " +
                    "reorderableList = new ReorderableList(listExample._cdtList, typeof(ConditionItem" +
                    "), true, true, true, true);\r\n\r\n            reorderableList.drawHeaderCallback +=" +
                    " DrawHeader;\r\n            reorderableList.drawElementCallback += DrawElement;\r\n\r" +
                    "\n            reorderableList.onAddCallback += AddItem;\r\n            reorderableL" +
                    "ist.onRemoveCallback += RemoveItem;\r\n\r\n\t\t\treorderableList.elementHeightCallback " +
                    "+= ElementHeightCallback;\r\n        }\r\n\r\n\t\tprivate void OnDisable()\r\n        {\r\n " +
                    "           reorderableList.drawHeaderCallback -= DrawHeader;\r\n            reorde" +
                    "rableList.drawElementCallback -= DrawElement;\r\n\r\n            reorderableList.onA" +
                    "ddCallback -= AddItem;\r\n            reorderableList.onRemoveCallback -= RemoveIt" +
                    "em;\r\n\r\n\t\t\treorderableList.elementHeightCallback -= ElementHeightCallback;\r\n     " +
                    "   }\r\n\r\n        private void DrawHeader(Rect rect)\r\n        {\r\n            GUI.L" +
                    "abel(rect, \"Callbacks invoked when output changes\");\r\n        }\r\n\r\n        priva" +
                    "te void DrawElement(Rect rect, int index, bool active, bool focused)\r\n        {\r" +
                    "\n            ConditionItem item = listExample._cdtList[index];\r\n\t\t\tRect newRect " +
                    "= rect;\r\n\r\n            EditorGUI.BeginChangeCheck();\r\n\t\t\tnewRect.y += 20;\r\n\t\t\tne" +
                    "wRect.x += 18;\r\n            //item.Test = EditorGUI.TextField(new Rect(rect.x + " +
                    "18, rect.y, rect.width - 18, rect.height), ConditionItem.Outputs[0].Item1);\r\n\r\n\t" +
                    "\t\t// Draws the condition item selector\r\n\t\t\titem.SelectedIndex = EditorGUI.Popup(" +
                    "new Rect(rect.x + 18, rect.y + 2, rect.width - 18, 10), item.SelectedIndex, Cond" +
                    "itionItem.Outputs);\r\n\r\n\t\t\tnewRect.y += item.Draw(newRect);\r\n\r\n\t\t\t// Draws the ca" +
                    "llback zone to assign it\r\n\t\t\t//SerializedObject s = new SerializedObject(listExa" +
                    "mple);\r\n            //var p = s.FindProperty(\"_cdtList\").GetArrayElementAtIndex(" +
                    "index);\r\n            //EditorGUI.PropertyField(new Rect(rect.x + 18, newRect.y +" +
                    " 5, rect.width - 18, 20), p.FindPropertyRelative(\"OnOutputChanged\"));\r\n\r\n\t\t\t//fo" +
                    "reach (var x in p.FindPropertyRelative(\"OnOutputChanged\"))\r\n\t\t\t//{\r\n\t\t\t//\tvar u " +
                    "= x as SerializedProperty;\r\n\t\t\t//\tif (u.name == \"size\")\r\n\t\t\t//\t{\r\n\t\t\t//\t\tDebug.L" +
                    "og(\"found size \" + u.intValue);\r\n\t\t\t//\t\titem.CallbackCount = u.intValue;\r\n\t\t\t//\t" +
                    "}\r\n\t\t\t//}\r\n\r\n            if (EditorGUI.EndChangeCheck())\r\n            {\r\n\t\t\t\tDeb" +
                    "ug.Log(\"end change check true\");\r\n                EditorUtility.SetDirty(target)" +
                    ";\r\n            }\r\n        }\r\n\r\n        private void AddItem(ReorderableList list" +
                    ")\r\n        {\r\n            listExample._cdtList.Add(new ConditionItem());\r\n\r\n    " +
                    "        EditorUtility.SetDirty(target);\r\n        }\r\n\r\n        private void Remov" +
                    "eItem(ReorderableList list)\r\n        {\r\n            listExample._cdtList.RemoveA" +
                    "t(list.index);\r\n\r\n            EditorUtility.SetDirty(target);\r\n        }\r\n\t\t\r\n  " +
                    "      private float ElementHeightCallback(int idx)\r\n        {\r\n            retur" +
                    "n listExample._cdtList[idx].ItemSize;\r\n        }\r\n\r\n        public override void" +
                    " OnInspectorGUI()\r\n        {\r\n            base.OnInspectorGUI();\r\n            re" +
                    "orderableList.DoLayoutList();\r\n        }\r\n    }\r\n\r\n\tpublic class EventOutputChan" +
                    "ge : EventArgs\r\n\t{\r\n\t\tpublic ");
            
            #line 179 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" Invoker;\r\n\t\tpublic object Value;\r\n\t\tpublic Type ValueType;\r\n\t}\r\n\r\n\t///<summary>\r" +
                    "\n\t/// Base behaviour for DNAI IA.\r\n\t///</summary>\r\n\tpublic class ");
            
            #line 187 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@" : MonoBehaviour
	{
	    public List<ConditionItem> _cdtList = new List<ConditionItem>();// { new ConditionItem() { cdt = new IntCondition() } };

		//[Serializable]
		//public class UnityEventOutputChange : UnityEvent<EventOutputChange>
		//{
		//}

		///<summary>
		/// Called when output values of the DNAI script change.
		///</summary>
		public UnityEventOutputChange OnOutputChanged;

		");
            
            #line 201 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in DataTypes)
		{
            
            #line default
            #line hidden
            this.Write("\t\t\tpublic ");
            
            #line 203 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t");
            
            #line 204 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t//[Header(\"Input variables\")]\r\n\t\t");
            
            #line 207 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Inputs)
		{ 
            
            #line default
            #line hidden
            this.Write("\t\t\tpublic ");
            
            #line 209 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t");
            
            #line 210 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t//[Header(\"Output variables\")]\r\n\t\t");
            
            #line 213 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Outputs)
		{ 
            
            #line default
            #line hidden
            this.Write("\t\t\tprivate ");
            
            #line 215 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[0]));
            
            #line default
            #line hidden
            this.Write(" _");
            
            #line 215 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[1]));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\tpublic ");
            
            #line 216 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t{\r\n\t\t\t\tget { return _");
            
            #line 218 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[1]));
            
            #line default
            #line hidden
            this.Write("; }\r\n\t\t\t\tprivate set\r\n\t\t\t\t{\r\n\t\t\t\t\t_");
            
            #line 221 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[1]));
            
            #line default
            #line hidden
            this.Write(" = value;\r\n\t\t\t\t\t//OnOutputChanged.Invoke(new EventOutputChange { Value = value, V" +
                    "alueType = value.GetType(), Invoker = this });\r\n\t\t\t\t\t_cdtList.FindAll((x) => x.S" +
                    "electedOutput == \"");
            
            #line 223 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\").ForEach((y) =>\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tif (y.Evaluate())\r\n\t\t\t\t\t\t\ty.OnOutputChanged?.Inv" +
                    "oke(new EventOutputChange { Value = value, ValueType = value.GetType(), Invoker " +
                    "= this });\r\n\t\t\t\t\t});\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t");
            
            #line 230 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\tprivate BinaryManager _manager;\r\n\r\n\t\tpublic ");
            
            #line 234 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("()\r\n\t\t{\r\n\t\t\t_manager = new BinaryManager();\r\n\t\t\t_manager.LoadCommandsFrom(@\"Asset" +
                    "s/Standard Assets/DNAI/Scripts/\" + \"");
            
            #line 237 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FilePath));
            
            #line default
            #line hidden
            this.Write(@""");
		}

		///<summary>
		/// Executes the Duly Behaviour by calling the created function.
		/// Updates Outputs accordingly.
		///</summary>
		public void Execute()
		{
			var results = new Dictionary<string, dynamic>();

			results = _manager.Controller.CallFunction(");
            
            #line 248 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FunctionId));
            
            #line default
            #line hidden
            this.Write(", new Dictionary<string, dynamic>{ ");
            
            #line 248 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FunctionArguments));
            
            #line default
            #line hidden
            this.Write(" });\r\n\t\t\t");
            
            #line 249 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 if (Outputs.Count > 0)
			{
				foreach (var output in Outputs)
				{
					var varName = output.Split(' ')[1]; 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t");
            
            #line 254 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write(" = results[\"");
            
            #line 254 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("\"];\r\n\t\t\t\t");
            
            #line 255 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 }
			} 
            
            #line default
            #line hidden
            this.Write("\t\t}\r\n\t}\t\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"

private string _parameter1Field;

/// <summary>
/// Access the parameter1 parameter of the template.
/// </summary>
private string parameter1
{
    get
    {
        return this._parameter1Field;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool parameter1ValueAcquired = false;
if (this.Session.ContainsKey("parameter1"))
{
    this._parameter1Field = ((string)(this.Session["parameter1"]));
    parameter1ValueAcquired = true;
}
if ((parameter1ValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("parameter1");
    if ((data != null))
    {
        this._parameter1Field = ((string)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class GeneratedCodeTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
