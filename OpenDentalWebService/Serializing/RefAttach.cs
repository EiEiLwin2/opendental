using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Drawing;

namespace OpenDentalWebService {
	///<summary>This file is generated automatically by the crud, do not make any changes to this file because they will get overwritten.</summary>
	public class RefAttach {

		///<summary></summary>
		public static string Serialize(OpenDentBusiness.RefAttach refattach) {
			StringBuilder sb=new StringBuilder();
			sb.Append("<RefAttach>");
			sb.Append("<RefAttachNum>").Append(refattach.RefAttachNum).Append("</RefAttachNum>");
			sb.Append("<ReferralNum>").Append(refattach.ReferralNum).Append("</ReferralNum>");
			sb.Append("<PatNum>").Append(refattach.PatNum).Append("</PatNum>");
			sb.Append("<ItemOrder>").Append(refattach.ItemOrder).Append("</ItemOrder>");
			sb.Append("<RefDate>").Append(refattach.RefDate.ToString("yyyyMMddHHmmss")).Append("</RefDate>");
			sb.Append("<IsFrom>").Append((refattach.IsFrom)?1:0).Append("</IsFrom>");
			sb.Append("<RefToStatus>").Append((int)refattach.RefToStatus).Append("</RefToStatus>");
			sb.Append("<Note>").Append(SerializeStringEscapes.EscapeForXml(refattach.Note)).Append("</Note>");
			sb.Append("<IsTransitionOfCare>").Append((refattach.IsTransitionOfCare)?1:0).Append("</IsTransitionOfCare>");
			sb.Append("<ProcNum>").Append(refattach.ProcNum).Append("</ProcNum>");
			sb.Append("<DateProcComplete>").Append(refattach.DateProcComplete.ToString("yyyyMMddHHmmss")).Append("</DateProcComplete>");
			sb.Append("</RefAttach>");
			return sb.ToString();
		}

		///<summary></summary>
		public static OpenDentBusiness.RefAttach Deserialize(string xml) {
			OpenDentBusiness.RefAttach refattach=new OpenDentBusiness.RefAttach();
			using(XmlReader reader=XmlReader.Create(new StringReader(xml))) {
				reader.MoveToContent();
				while(reader.Read()) {
					//Only detect start elements.
					if(!reader.IsStartElement()) {
						continue;
					}
					switch(reader.Name) {
						case "RefAttachNum":
							refattach.RefAttachNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "ReferralNum":
							refattach.ReferralNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "PatNum":
							refattach.PatNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "ItemOrder":
							refattach.ItemOrder=System.Convert.ToInt32(reader.ReadContentAsString());
							break;
						case "RefDate":
							refattach.RefDate=DateTime.ParseExact(reader.ReadContentAsString(),"yyyyMMddHHmmss",null);
							break;
						case "IsFrom":
							refattach.IsFrom=reader.ReadContentAsString()!="0";
							break;
						case "RefToStatus":
							refattach.RefToStatus=(OpenDentBusiness.ReferralToStatus)System.Convert.ToInt32(reader.ReadContentAsString());
							break;
						case "Note":
							refattach.Note=reader.ReadContentAsString();
							break;
						case "IsTransitionOfCare":
							refattach.IsTransitionOfCare=reader.ReadContentAsString()!="0";
							break;
						case "ProcNum":
							refattach.ProcNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "DateProcComplete":
							refattach.DateProcComplete=DateTime.ParseExact(reader.ReadContentAsString(),"yyyyMMddHHmmss",null);
							break;
					}
				}
			}
			return refattach;
		}


	}
}