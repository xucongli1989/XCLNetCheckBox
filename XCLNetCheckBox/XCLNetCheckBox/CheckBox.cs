using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
namespace XCLNetCheckBox
{
    /// <summary>
    /// 原理：vs的checkboxlist无value值，因此才有此控件
    /// by:xcl @2012.9  qq:80213876  http://blog.csdn.net/luoyeyu1989 （如需修改此控件，请保留此行信息即可，谢谢）
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    public class CheckBox : CheckBoxList
    {
        private static string getGuid = "_" + Guid.NewGuid().ToString("N");

        protected override void OnLoad(EventArgs e)
        {
            #region 设置默认选中项
            if (!string.IsNullOrEmpty(this.SetSelectedValues))
            {
                string[] vs = this.SetSelectedValues.Split(',');
                if (vs.Length > 0)
                {
                    for (int i = 0; i < vs.Length; i++)
                    {
                        if (vs[i].Length > 0)
                        {
                            if (this.Items.Count > 0)
                            {
                                for (int j = 0; j < this.Items.Count; j++)
                                {
                                    if (string.Equals(this.Items[j].Value, vs[i], StringComparison.OrdinalIgnoreCase))
                                    {
                                        this.Items[j].Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            base.OnLoad(e);
        }

        /// <summary>
        /// 以此作为每个item的name
        /// </summary>
        public string GetName
        {
            get
            {
                return getGuid + this.UniqueID.Replace('$', '_');
            }
        }

        #region 样式
        /// <summary>
        /// UL的class
        /// </summary>
        public string UlClass
        {
            get;
            set;
        }

        /// <summary>
        /// Li的class
        /// </summary>
        public string LiClass
        {
            get;
            set;
        }

        /// <summary>
        /// UL的style
        /// </summary>
        public string UlStyle
        {
            get;
            set;
        }

        /// <summary>
        /// LI的style
        /// </summary>
        public string LiStyle
        {
            get;
            set;
        }
        #endregion

        #region 其它信息
        /// <summary>
        /// （如需修改此控件，请保留此信息即可，谢谢）
        /// </summary>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("<!--*****************by xcl @2012.9 http://blog.csdn.net/luoyeyu1989*****************-->");
            base.RenderBeginTag(writer);
        }

        /// <summary>
        /// （如需修改此控件，请保留此信息即可，谢谢）
        /// </summary>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("<!--*****************by xcl @2012.9 http://blog.csdn.net/luoyeyu1989*****************-->");
            base.RenderEndTag(writer);
        }
        #endregion


        private string _selectedValues = string.Empty;
        /// <summary>
        /// 设置默认选中值(用,分隔)
        /// </summary>
        public string SetSelectedValues
        {
            get;
            set;
        }

        /// <summary>
        /// 渲染html
        /// </summary>
        protected override void Render(HtmlTextWriter output)
        {
            //base.Render(writer);//莫加此句，加了后，原来的html不会被清空的
            StringBuilder str = new StringBuilder();
            if (this.Items.Count > 0)
            {
                string ulCss=(string.IsNullOrEmpty(this.UlStyle) ? "style='width:100%;list-style-type:none;'" :string.Format("style='{0}'",this.UlStyle))+
                                    (string.IsNullOrEmpty(this.UlClass)?"":string.Format(" class='{0}' ",this.UlClass));
                string liCss = (string.IsNullOrEmpty(this.LiStyle) ? "style='width:33%;list-style-type:none;float:left;'" : string.Format("style='{0}'", this.LiStyle)) +
                                    (string.IsNullOrEmpty(this.LiClass) ? "" : string.Format(" class='{0}' ", this.LiClass));
                str.AppendFormat("<ul {0}>",ulCss);
                for (int i = 0; i < this.Items.Count; i++)
                {
                    str.AppendFormat("<li {4}><input type='checkbox' id='{0}{1}' name='{0}' value='{2}' {5}/><label for='{0}{1}'>{3}</label></li>", this.GetName, i, this.Items[i].Value, this.Items[i].Text,liCss,this.Items[i].Selected?"checked='checked'":"");
                }
                str.Append("</ul>");
            }
            output.Write(str.ToString());
        }
    }
}
