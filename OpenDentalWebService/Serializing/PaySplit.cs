using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Drawing;

namespace OpenDentalWebService {
	///<summary>This file is generated automatically by the crud, do not make any changes to this file because they will get overwritten.</summary>
	public class PaySplit {

		///<summary></summary>
		public static string Serialize(OpenDentBusiness.PaySplit paysplit) {
			StringBuilder sb=new StringBuilder();
			sb.Append("<PaySplit>");
			sb.Append("<SplitNum>").Append(paysplit.SplitNum).Append("</SplitNum>");
			sb.Append("<SplitAmt>").Append(paysplit.SplitAmt).Append("</SplitAmt>");
			sb.Append("<PatNum>").Append(paysplit.PatNum).Append("</PatNum>");
			sb.Append("<ProcDate>").Append(paysplit.ProcDate.ToString("yyyyMMddHHmmss")).Append("</ProcDate>");
			sb.Append("<PayNum>").Append(paysplit.PayNum).Append("</PayNum>");
			sb.Append("<IsDiscount>").Append((paysplit.IsDiscount)?1:0).Append("</IsDiscount>");
			sb.Append("<DiscountType>").Append(paysplit.DiscountType).Append("</DiscountType>");
			sb.Append("<ProvNum>").Append(paysplit.ProvNum).Append("</ProvNum>");
			sb.Append("<PayPlanNum>").Append(paysplit.PayPlanNum).Append("</PayPlanNum>");
			sb.Append("<DatePay>").Append(paysplit.DatePay.ToString("yyyyMMddHHmmss")).Append("</DatePay>");
			sb.Append("<ProcNum>").Append(paysplit.ProcNum).Append("</ProcNum>");
			sb.Append("<DateEntry>").Append(paysplit.DateEntry.ToString("yyyyMMddHHmmss")).Append("</DateEntry>");
			sb.Append("<UnearnedType>").Append(paysplit.UnearnedType).Append("</UnearnedType>");
			sb.Append("<ClinicNum>").Append(paysplit.ClinicNum).Append("</ClinicNum>");
			sb.Append("</PaySplit>");
			return sb.ToString();
		}

		///<summary></summary>
		public static OpenDentBusiness.PaySplit Deserialize(string xml) {
			OpenDentBusiness.PaySplit paysplit=new OpenDentBusiness.PaySplit();
			using(XmlReader reader=XmlReader.Create(new StringReader(xml))) {
				reader.MoveToContent();
				while(reader.Read()) {
					//Only detect start elements.
					if(!reader.IsStartElement()) {
						continue;
					}
					switch(reader.Name) {
						case "SplitNum":
							paysplit.SplitNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "SplitAmt":
							paysplit.SplitAmt=System.Convert.ToDouble(reader.ReadContentAsString());
							break;
						case "PatNum":
							paysplit.PatNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "ProcDate":
							paysplit.ProcDate=DateTime.ParseExact(reader.ReadContentAsString(),"yyyyMMddHHmmss",null);
							break;
						case "PayNum":
							paysplit.PayNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "IsDiscount":
							paysplit.IsDiscount=reader.ReadContentAsString()!="0";
							break;
						case "DiscountType":
							paysplit.DiscountType=System.Convert.ToByte(reader.ReadContentAsString());
							break;
						case "ProvNum":
							paysplit.ProvNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "PayPlanNum":
							paysplit.PayPlanNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "DatePay":
							paysplit.DatePay=DateTime.ParseExact(reader.ReadContentAsString(),"yyyyMMddHHmmss",null);
							break;
						case "ProcNum":
							paysplit.ProcNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "DateEntry":
							paysplit.DateEntry=DateTime.ParseExact(reader.ReadContentAsString(),"yyyyMMddHHmmss",null);
							break;
						case "UnearnedType":
							paysplit.UnearnedType=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
						case "ClinicNum":
							paysplit.ClinicNum=System.Convert.ToInt64(reader.ReadContentAsString());
							break;
					}
				}
			}
			return paysplit;
		}


	}
}