//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Mobile.Crud{
	internal class DrugUnitmCrud {
		///<summary>Gets one DrugUnitm object from the database using primaryKey1(CustomerNum) and primaryKey2.  Returns null if not found.</summary>
		internal static DrugUnitm SelectOne(long customerNum,long drugUnitNum){
			string command="SELECT * FROM drugunitm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND DrugUnitNum = "+POut.Long(drugUnitNum);
			List<DrugUnitm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one DrugUnitm object from the database using a query.</summary>
		internal static DrugUnitm SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<DrugUnitm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of DrugUnitm objects from the database using a query.</summary>
		internal static List<DrugUnitm> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<DrugUnitm> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<DrugUnitm> TableToList(DataTable table){
			List<DrugUnitm> retVal=new List<DrugUnitm>();
			DrugUnitm drugUnitm;
			for(int i=0;i<table.Rows.Count;i++) {
				drugUnitm=new DrugUnitm();
				drugUnitm.CustomerNum   = PIn.Long  (table.Rows[i]["CustomerNum"].ToString());
				drugUnitm.DrugUnitNum   = PIn.Long  (table.Rows[i]["DrugUnitNum"].ToString());
				drugUnitm.UnitIdentifier= PIn.String(table.Rows[i]["UnitIdentifier"].ToString());
				drugUnitm.UnitText      = PIn.String(table.Rows[i]["UnitText"].ToString());
				retVal.Add(drugUnitm);
			}
			return retVal;
		}

		///<summary>Usually set useExistingPK=true.  Inserts one DrugUnitm into the database.</summary>
		internal static long Insert(DrugUnitm drugUnitm,bool useExistingPK){
			if(!useExistingPK) {
				drugUnitm.DrugUnitNum=ReplicationServers.GetKey("drugunitm","DrugUnitNum");
			}
			string command="INSERT INTO drugunitm (";
			command+="DrugUnitNum,";
			command+="CustomerNum,UnitIdentifier,UnitText) VALUES(";
			command+=POut.Long(drugUnitm.DrugUnitNum)+",";
			command+=
				     POut.Long  (drugUnitm.CustomerNum)+","
				+"'"+POut.String(drugUnitm.UnitIdentifier)+"',"
				+"'"+POut.String(drugUnitm.UnitText)+"')";
			Db.NonQ(command);//There is no autoincrement in the mobile server.
			return drugUnitm.DrugUnitNum;
		}

		///<summary>Updates one DrugUnitm in the database.</summary>
		internal static void Update(DrugUnitm drugUnitm){
			string command="UPDATE drugunitm SET "
				+"UnitIdentifier= '"+POut.String(drugUnitm.UnitIdentifier)+"', "
				+"UnitText      = '"+POut.String(drugUnitm.UnitText)+"' "
				+"WHERE CustomerNum = "+POut.Long(drugUnitm.CustomerNum)+" AND DrugUnitNum = "+POut.Long(drugUnitm.DrugUnitNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one DrugUnitm from the database.</summary>
		internal static void Delete(long customerNum,long drugUnitNum){
			string command="DELETE FROM drugunitm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND DrugUnitNum = "+POut.Long(drugUnitNum);
			Db.NonQ(command);
		}

		///<summary>Converts one DrugUnit object to its mobile equivalent.  Warning! CustomerNum will always be 0.</summary>
		internal static DrugUnitm ConvertToM(DrugUnit drugUnit){
			DrugUnitm drugUnitm=new DrugUnitm();
			//CustomerNum cannot be set.  Remains 0.
			drugUnitm.DrugUnitNum   =drugUnit.DrugUnitNum;
			drugUnitm.UnitIdentifier=drugUnit.UnitIdentifier;
			drugUnitm.UnitText      =drugUnit.UnitText;
			return drugUnitm;
		}

	}
}