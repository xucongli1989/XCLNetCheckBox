using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ListItem> lst = new List<ListItem>() { 
                new ListItem("aaaa","1"),
                new ListItem("bbbbb","2"),
                new ListItem("cccc","3")
            };
            this.xcl.DataSource = lst;
            this.xcl.DataTextField = "text";
            this.xcl.DataValueField = "value";
            this.xcl.DataBind();
            this.xcl.SetSelectedValues = "1,3";
        }
    }
}