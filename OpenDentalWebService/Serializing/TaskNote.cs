using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Drawing;

namespace OpenDentalWebService {
	///<summary>This file is generated automatically by the crud, do not make any changes to this file because they will get overwritten.</summary>
	public class TaskNote {

		///<summary></summary>
		public static string Serialize(OpenDentBusiness.TaskNote tasknote) {
			StringBuilder sb=new StringBuilder();
			sb.Append("<TaskNote>");
			sb.Append("<TaskNoteNum>").Append(tasknote.TaskNoteNum).Append("</TaskNoteNum>");
			sb.Append("<TaskNum>").Append(tasknote.TaskNum).Append("</TaskNum>");
			sb.Append("<UserNum>").Append(tasknote.UserNum).Append("</UserNum>");
			sb.Append("<DateTimeNote>").Append(tasknote.DateTimeNote.ToString("yyyyMMddHHmmss")).Append("</DateTimeNote>");
			sb.Append("<Note>").Append(SerializeStringEscapes.EscapeForXml(tasknote.Note)).Append("</Note>");
			sb.Append("</TaskNote>");
			return sb.ToString();
		}

		///<summary></summary>
		public static OpenDentBusiness.TaskNote Deserialize(string xml) {
			OpenDentBusiness.TaskNote tasknote=new OpenDentBusiness.TaskNote();
			using(XmlReader reader=XmlReader.Create(new StringReader(xml))) {
				reader.MoveToContent();
				while(reader.Read()) {
					//Only detect start elements.
					if(!reader.IsStartElement()) {
						continue;
					}
					switch(reader.Name) {
						case "TaskNoteNum":
							tasknote.TaskNoteNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "TaskNum":
							tasknote.TaskNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "UserNum":
							tasknote.UserNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "DateTimeNote":
							tasknote.DateTimeNote=DateTime.ParseExact(reader.ReadContentAsString(),"yyyyMMddHHmmss",null);
							break;
						case "Note":
							tasknote.Note=reader.ReadContentAsString();
							break;
					}
				}
			}
			return tasknote;
		}


	}
}