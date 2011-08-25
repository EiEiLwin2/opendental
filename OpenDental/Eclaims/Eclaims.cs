using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental.Eclaims
{
	/// <summary>
	/// Summary description for Eclaims.
	/// </summary>
	public class Eclaims{
		/// <summary></summary>
		public Eclaims()
		{
			
		}

		///<summary>Supply a list of ClaimSendQueueItems. Called from FormClaimSend.  Can send to multiple clearinghouses simultaneously or can also just send one claim.  Cannot include Canadian.</summary>
		public static void SendBatches(List<ClaimSendQueueItem> queueItems){
			List<ClaimSendQueueItem>[] claimsByCHouse=new List<ClaimSendQueueItem>[Clearinghouses.Listt.Length];
			//ArrayList[Clearinghouses.List.Length];
			for(int i=0;i<claimsByCHouse.Length;i++){
				claimsByCHouse[i]=new List<ClaimSendQueueItem>();
				//claimsByCHouse[i]=new ArrayList();
			}
			//divide the items by clearinghouse:
			for(int i=0;i<queueItems.Count;i++){
				claimsByCHouse[ClearinghouseL.GetIndex(queueItems[i].ClearinghouseNum)].Add(queueItems[i]);
			}
			//for any clearinghouses with claims, send them:
			int batchNum;
			//bool result=true;
			string messageText="";
			for(int i=0;i<claimsByCHouse.Length;i++){
				if(claimsByCHouse[i].Count==0){
					continue;
				}
				if(Clearinghouses.Listt[i].Eformat==ElectronicClaimFormat.Canadian){
					MsgBox.Show("Eclaims","Cannot send Canadian claims as part of SendBatches.");
					continue;
				}
				//get next batch number for this clearinghouse
				batchNum=Clearinghouses.GetNextBatchNumber(Clearinghouses.Listt[i]);
				//---------------------------------------------------------------------------------------
				//Create the claim file(s) for this clearinghouse
				if(Clearinghouses.Listt[i].Eformat==ElectronicClaimFormat.X12){
					messageText=x837Controller.SendBatch(claimsByCHouse[i],batchNum);
				}
				else if(Clearinghouses.Listt[i].Eformat==ElectronicClaimFormat.Renaissance){
					messageText=Renaissance.SendBatch(claimsByCHouse[i],batchNum);
				}
				//else if(Clearinghouses.Listt[i].Eformat==ElectronicClaimFormat.Canadian) {
					//Canadian is a little different because we need the sequence numbers.
					//So all programs are launched and statuses changed from within Canadian.SendBatch()
					//We don't care what the result is.
				//	Canadian.SendBatch(claimsByCHouse[i],batchNum);
				//	continue;
				//}
				else if(Clearinghouses.Listt[i].Eformat==ElectronicClaimFormat.Dutch) {
					messageText=Dutch.SendBatch(claimsByCHouse[i],batchNum);
				}
				else{
					messageText="";//(ElectronicClaimFormat.None does not get sent)
				}
				if(messageText==""){//if failed to create claim file properly,
					continue;//don't launch program or change claim status
				}
				//----------------------------------------------------------------------------------------
				//Launch Client Program for this clearinghouse if applicable
				if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.None){
					AttemptLaunch(Clearinghouses.Listt[i],batchNum);
				}
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.WebMD){
					if(!WebMD.Launch(Clearinghouses.Listt[i],batchNum)){
						MessageBox.Show(Lan.g("Eclaims","Error sending."));
						continue;
					}
				}
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.BCBSGA){
					if(!BCBSGA.Launch(Clearinghouses.Listt[i],batchNum)){
						MessageBox.Show(Lan.g("Eclaims","Error sending."));
						continue;
					}
				}
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.Renaissance){
					AttemptLaunch(Clearinghouses.Listt[i],batchNum);
				}
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.ClaimConnect){
					if(!ClaimConnect.Launch(Clearinghouses.Listt[i],batchNum)){
						MessageBox.Show(Lan.g("Eclaims","Error sending."));
						continue;
					}
				}
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.RECS){
					if(!RECS.Launch(Clearinghouses.Listt[i],batchNum)){
						MessageBox.Show("Claim file created, but could not launch RECS client.");
						//continue;
					}
				}
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.Inmediata){
					if(!Inmediata.Launch(Clearinghouses.Listt[i],batchNum)){
						MessageBox.Show("Claim file created, but could not launch Inmediata client.");
						//continue;
					}
				}
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.AOS){ // added by SPK 7/13/05
					if(!AOS.Launch(Clearinghouses.Listt[i],batchNum)){
						MessageBox.Show("Claim file created, but could not launch AOS Communicator.");
						//continue;
					}
				}
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.PostnTrack){
					AttemptLaunch(Clearinghouses.Listt[i],batchNum);
					//if(!PostnTrack.Launch(Clearinghouses.List[i],batchNum)){
					//	MessageBox.Show("Claim file created, but could not launch AOS Communicator.");
						//continue;
					//}
				}
				/*else if(Clearinghouses.List[i].CommBridge==EclaimsCommBridge.Tesia) {
					if(!Tesia.Launch(Clearinghouses.List[i],batchNum)) {
						MessageBox.Show(Lan.g("Eclaims","Error sending."));
						continue;
					}
				}*/
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.MercuryDE){
					if(!MercuryDE.Launch(Clearinghouses.Listt[i],batchNum)){
						MsgBox.Show("Eclaims","Error sending.");
						continue;
					}
				}
				else if(Clearinghouses.Listt[i].CommBridge==EclaimsCommBridge.ClaimX) {
					if(!ClaimX.Launch(Clearinghouses.Listt[i],batchNum)) {
						MessageBox.Show("Claim file created, but encountered an error while launching ClaimX Client.");
						//continue;
					}
				}
				//----------------------------------------------------------------------------------------
				//finally, mark the claims sent. (only if not Canadian)
				EtransType etype=EtransType.ClaimSent;
				if(Clearinghouses.Listt[i].Eformat==ElectronicClaimFormat.Renaissance){
					etype=EtransType.Claim_Ren;
				}
				if(Clearinghouses.Listt[i].Eformat!=ElectronicClaimFormat.Canadian){
					for(int j=0;j<claimsByCHouse[i].Count;j++){
						Etrans etrans=Etranss.SetClaimSentOrPrinted(claimsByCHouse[i][j].ClaimNum,claimsByCHouse[i][j].PatNum,Clearinghouses.Listt[i].ClearinghouseNum,etype,batchNum);
						Etranss.SetMessage(etrans.EtransNum,messageText);
					}
				}
			}//for(int i=0;i<claimsByCHouse.Length;i++){
		}

		///<summary>If no comm bridge is selected for a clearinghouse, this launches any client program the user has entered.  We do not want to cause a rollback, so no return value.</summary>
		private static void AttemptLaunch(Clearinghouse clearhouse,int batchNum){
			if(clearhouse.ClientProgram==""){
				return;
			}
			if(!File.Exists(clearhouse.ClientProgram)){
				MessageBox.Show(clearhouse.ClientProgram+" "+Lan.g("Eclaims","does not exist."));
				return;
			}
			try{
				Process.Start(clearhouse.ClientProgram);
			}
			catch{
				MessageBox.Show(Lan.g("Eclaims","Client program could not be started.  It may already be running. You must open your client program to finish sending claims."));
			}
		}

		///<summary>Returns a string describing all missing data on this claim.  Claim will not be allowed to be sent electronically unless this string comes back empty.</summary>
		public static string GetMissingData(ClaimSendQueueItem queueItem, out string warnings){
			warnings="";
			Clearinghouse clearhouse=ClearinghouseL.GetClearinghouse(queueItem.ClearinghouseNum);
			if(clearhouse==null){
				return "";
			}
			if(clearhouse.Eformat==ElectronicClaimFormat.X12){
				string retVal=X837_4010.Validate(queueItem,out warnings);
				return retVal;
			}
			else if(clearhouse.Eformat==ElectronicClaimFormat.Renaissance){
				return Renaissance.GetMissingData(queueItem);
			}
			else if(clearhouse.Eformat==ElectronicClaimFormat.Canadian) {
				return Canadian.GetMissingData(queueItem);
			}
			else if(clearhouse.Eformat==ElectronicClaimFormat.Dutch) {
				return Dutch.GetMissingData(queueItem,out warnings);
			}
			return "";
		}

	


	}
}



























