package com.opendental.odweb.client.tabletypes;

import com.google.gwt.xml.client.Document;
import com.google.gwt.xml.client.XMLParser;
import com.opendental.odweb.client.remoting.Serializing;

public class HL7DefSegment {
		/** Primary key. */
		public int HL7DefSegmentNum;
		/** FK to HL7DefMessage.HL7DefMessageNum */
		public int HL7DefMessageNum;
		/** Since we don't enforce or automate, it can be 1-based or 0-based.  For outgoing, this affects the message structure.  For incoming, this is just for convenience and organization in the HL7 Def windows. */
		public int ItemOrder;
		/** For example, a DFT can have multiple FT1 segments.  This turns out to be a completely useless field, since we already know which ones can repeat. */
		public boolean CanRepeat;
		/** If this is false, and an incoming message is missing this segment, then it gets logged as an error/failure.  If this is true, then it will gracefully skip a missing incoming segment.  Not used for outgoing. */
		public boolean IsOptional;
		/** Stored in db as string, but used in OD as enum SegmentNameHL7. Example: PID. */
		public SegmentNameHL7 SegmentName;
		/** . */
		public String Note;

		/** Deep copy of object. */
		public HL7DefSegment Copy() {
			HL7DefSegment hl7defsegment=new HL7DefSegment();
			hl7defsegment.HL7DefSegmentNum=this.HL7DefSegmentNum;
			hl7defsegment.HL7DefMessageNum=this.HL7DefMessageNum;
			hl7defsegment.ItemOrder=this.ItemOrder;
			hl7defsegment.CanRepeat=this.CanRepeat;
			hl7defsegment.IsOptional=this.IsOptional;
			hl7defsegment.SegmentName=this.SegmentName;
			hl7defsegment.Note=this.Note;
			return hl7defsegment;
		}

		/** Serialize the object into XML. */
		public String SerializeToXml() {
			StringBuilder sb=new StringBuilder();
			sb.append("<HL7DefSegment>");
			sb.append("<HL7DefSegmentNum>").append(HL7DefSegmentNum).append("</HL7DefSegmentNum>");
			sb.append("<HL7DefMessageNum>").append(HL7DefMessageNum).append("</HL7DefMessageNum>");
			sb.append("<ItemOrder>").append(ItemOrder).append("</ItemOrder>");
			sb.append("<CanRepeat>").append((CanRepeat)?1:0).append("</CanRepeat>");
			sb.append("<IsOptional>").append((IsOptional)?1:0).append("</IsOptional>");
			sb.append("<SegmentName>").append(SegmentName.ordinal()).append("</SegmentName>");
			sb.append("<Note>").append(Serializing.EscapeForXml(Note)).append("</Note>");
			sb.append("</HL7DefSegment>");
			return sb.toString();
		}

		/** Sets the variables for this object based on the values from the XML.
		 * @param xml The XML passed in must be valid and contain a node for every variable on this object.
		 * @throws Exception Deserialize is encased in a try catch and will pass any thrown exception on. */
		public void DeserializeFromXml(String xml) throws Exception {
			try {
				Document doc=XMLParser.parse(xml);
				if(Serializing.GetXmlNodeValue(doc,"HL7DefSegmentNum")!=null) {
					HL7DefSegmentNum=Integer.valueOf(Serializing.GetXmlNodeValue(doc,"HL7DefSegmentNum"));
				}
				if(Serializing.GetXmlNodeValue(doc,"HL7DefMessageNum")!=null) {
					HL7DefMessageNum=Integer.valueOf(Serializing.GetXmlNodeValue(doc,"HL7DefMessageNum"));
				}
				if(Serializing.GetXmlNodeValue(doc,"ItemOrder")!=null) {
					ItemOrder=Integer.valueOf(Serializing.GetXmlNodeValue(doc,"ItemOrder"));
				}
				if(Serializing.GetXmlNodeValue(doc,"CanRepeat")!=null) {
					CanRepeat=(Serializing.GetXmlNodeValue(doc,"CanRepeat")=="0")?false:true;
				}
				if(Serializing.GetXmlNodeValue(doc,"IsOptional")!=null) {
					IsOptional=(Serializing.GetXmlNodeValue(doc,"IsOptional")=="0")?false:true;
				}
				if(Serializing.GetXmlNodeValue(doc,"SegmentName")!=null) {
					SegmentName=SegmentNameHL7.values()[Integer.valueOf(Serializing.GetXmlNodeValue(doc,"SegmentName"))];
				}
				if(Serializing.GetXmlNodeValue(doc,"Note")!=null) {
					Note=Serializing.GetXmlNodeValue(doc,"Note");
				}
			}
			catch(Exception e) {
				throw e;
			}
		}

		/** The items in this enumeration can be freely rearranged without damaging the database.  But can't change spelling or remove existing item. */
		public enum SegmentNameHL7 {
			/** Db Resource Appointment Information */
			AIG,
			/** Location Resource Appointment Information */
			AIL,
			/** Personnel Resource Appointment Information */
			AIP,
			/** Diagnosis Information */
			DG1,
			/** Event Type */
			EVN,
			/** Financial Transaction Information */
			FT1,
			/** Guarantor Information */
			GT1,
			/** Insurance Information */
			IN1,
			/** Message Header */
			MSH,
			/** Observations Request */
			OBR,
			/** Observation Related to OBR */
			OBX,
			/** Common Order.  Used in outgoing vaccinations VXUs as well as incoming lab result ORUs. */
			ORC,
			/** Patient Identification */
			PID,
			/** Patient additional demographics */
			PD1,
			/** Patient Visit */
			PV1,
			/** Pharmacy Administration Segment */
			RXA,
			/** Scheduling Activity Information */
			SCH,
			/** This can happen for unsupported segments. */
			Unknown,
			/** We use for PDF Data */
			ZX1
		}


}