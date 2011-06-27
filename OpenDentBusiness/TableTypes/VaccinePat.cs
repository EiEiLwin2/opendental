﻿using System;
using System.Collections;
using System.Drawing;

namespace OpenDentBusiness {
	///<summary></summary>
	[Serializable]
	public class VaccinePat:TableBase {
		///<summary>Primary key.</summary>
		[CrudColumn(IsPriKey=true)]
		public long VaccinePatNum;
		///<summary>FK to vaccinedef.VaccineDefNum.</summary>
		public long VaccineDefNum;
		///<summary></summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		public DateTime DateTimeStart;
		///<summary></summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		public DateTime DateTimeEnd;
		///<summary>Size of the dose of the vaccine.  999 indicates unknown.</summary>
		public float AdministeredAmt;
		///<summary>FK to drugunit.DrugUnitNum. Unit of measurement of the AdministeredAmt.  0 represents null.</summary>
		public long DrugUnitNum;
		///<summary></summary>
		public string LotNumber;
		///<summary>FK to patient.PatNum.</summary>
		public long PatNum;
		///<summary>Set to true if no vaccine given.  Documentation required in the Note.</summary>
		public bool NotGiven;
		///<summary></summary>
		public string Note;

		///<summary></summary>
		public VaccinePat Copy() {
			return (VaccinePat)this.MemberwiseClone();
		}

	}
}