﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace MobileWeb {
	public partial class ProcessLogout:System.Web.UI.Page {

		protected void Page_Load(object sender,EventArgs e) {
			Thread.Sleep(3000);
			Session["CustomerNum"]=null;
			Session.Abandon();
			Message.Text="LoggedOut";
		}
	}
}