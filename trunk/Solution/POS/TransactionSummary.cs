﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using POS.APP_Data;

namespace POS
{
    public partial class TransactionSummary : Form
    {
        #region Variable

        POSEntities entity = new POSEntities();
        List<Transaction> transList = new List<Transaction>();
        List<Transaction> RtransList = new List<Transaction>();
        List<Transaction> DtransList = new List<Transaction>();
        List<Transaction> CRtransList = new List<Transaction>();
        List<Transaction> GCtransList = new List<Transaction>();
        List<Transaction> CtransList = new List<Transaction>();
        List<Transaction> MPUtransList = new List<Transaction>();
        List<Transaction> FOCtrnsList = new List<Transaction>();
        #endregion

        #region Event
        public TransactionSummary()
        {
            InitializeComponent();
        }

        private void TransactionSummary_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            LoadData();
        }   

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region [print]
            long totalSale = 0, totalRefund = 0, totalDebt = 0, totalCreditRefund = 0, totalSummary = 0; long totalGiftCard = 0, totalCredit = 0, totalCreditRecieve = 0, totalCashInHand = 0, totalExpense = 0, totalIncomeAmount = 0, totalMPU = 0, totalFOC = 0, totalReceived = 0; long totalDiscount = 0, totalRefundDiscount = 0, totalCreditRefundDiscount = 0,Sc=0,Cf=0,Injec=0;

            totalSale = transList.Sum(x => x.TotalAmount).Value;

            foreach (Transaction t in transList)
            {
                long itemdiscount = (long)t.TransactionDetails.Sum(x => (x.UnitPrice * (x.DiscountRate / 100)) * x.Qty);
                totalDiscount += (long)t.DiscountAmount - itemdiscount;
            }

            foreach (Transaction t in transList)
            {

                Sc += (long)t.ServiceChages;
                Cf += (long)t.Consultantfees;
                Injec += (long)t.TransactionDetails.Sum(x => (x.InjectionRate));
            }
            totalRefund = RtransList.Sum(x => x.TotalAmount).Value;
            totalRefundDiscount = RtransList.Sum(x => x.DiscountAmount).Value;
            totalDebt = DtransList.Sum(x => x.TotalAmount).Value;
            totalCreditRefund = CRtransList.Sum(x => x.TotalAmount).Value;
            totalCreditRefundDiscount = CRtransList.Sum(x => x.DiscountAmount).Value;
            totalGiftCard = GCtransList.Sum(x => x.TotalAmount).Value;
            totalCredit = CtransList.Sum(x => x.TotalAmount).Value;
            totalCreditRecieve = CtransList.Sum(x => x.RecieveAmount).Value;
            totalMPU = MPUtransList.Sum(x => x.TotalAmount).Value;
            totalFOC = FOCtrnsList.Sum(x => x.TotalAmount).Value;


            //totalSummary = (totalSale + totalDebt + totalCreditRefund + totalGiftCard) - totalRefund;
            totalSummary = ((totalSale + totalCredit + totalGiftCard + totalMPU) - (totalRefund + totalCreditRefund + totalFOC));
            totalCashInHand = (totalSale + totalDebt + totalCreditRecieve) - (totalRefund + Cf + Injec);
            totalExpense = (totalRefund + totalCreditRefund + totalFOC);
            totalIncomeAmount = (totalSale + totalCredit + totalGiftCard + totalMPU);
            totalReceived = (totalSale + totalDebt + totalCreditRecieve);
            string reportPath = Application.StartupPath + "\\Reports\\TransactionSummary.rdlc";
            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter TotalDiscount = new ReportParameter("TotalDiscount", totalDiscount.ToString());
            reportViewer1.LocalReport.SetParameters(TotalDiscount);
            
            ReportParameter CFF = new ReportParameter("CF", Cf.ToString());
            reportViewer1.LocalReport.SetParameters(CFF);

            ReportParameter SCC = new ReportParameter("SC", Sc.ToString());
            reportViewer1.LocalReport.SetParameters(SCC);

            ReportParameter Inject = new ReportParameter("Injection", Injec.ToString());
            reportViewer1.LocalReport.SetParameters(Inject);

            ReportParameter TotalRefundDiscount = new ReportParameter("TotalRefundDiscount", totalRefundDiscount.ToString());
            reportViewer1.LocalReport.SetParameters(TotalRefundDiscount);

            ReportParameter TotalCreditRefundDiscount = new ReportParameter("TotalCreditRefundDiscount", totalCreditRefundDiscount.ToString());
            reportViewer1.LocalReport.SetParameters(TotalCreditRefundDiscount);

            ReportParameter ActualAmount = new ReportParameter("ActualAmount", totalReceived.ToString());
            reportViewer1.LocalReport.SetParameters(ActualAmount);

            ReportParameter TotalFOC = new ReportParameter("TotalFOC", totalFOC.ToString());
            reportViewer1.LocalReport.SetParameters(TotalFOC);

            ReportParameter TotalMPU = new ReportParameter("TotalMPU", totalMPU.ToString());
            reportViewer1.LocalReport.SetParameters(TotalMPU);

            ReportParameter TotalSale = new ReportParameter("TotalSale", totalSale.ToString());
            reportViewer1.LocalReport.SetParameters(TotalSale);

            ReportParameter CreditRecieve = new ReportParameter("CreditRecieve", totalCreditRecieve.ToString());
            reportViewer1.LocalReport.SetParameters(CreditRecieve);

            ReportParameter Expense = new ReportParameter("Expense", totalExpense.ToString());
            reportViewer1.LocalReport.SetParameters(Expense);

            ReportParameter IncomeAmount = new ReportParameter("IncomeAmount", totalIncomeAmount.ToString());
            reportViewer1.LocalReport.SetParameters(IncomeAmount);

            ReportParameter CashInHand = new ReportParameter("CashInHand", totalCashInHand.ToString());
            reportViewer1.LocalReport.SetParameters(CashInHand);

            ReportParameter TotalDebt = new ReportParameter("TotalDebt", totalDebt.ToString());
            reportViewer1.LocalReport.SetParameters(TotalDebt);

            ReportParameter TotalRefund = new ReportParameter("TotalRefund", totalRefund.ToString());
            reportViewer1.LocalReport.SetParameters(TotalRefund);

            ReportParameter TotalSummary = new ReportParameter("TotalSummary", totalSummary.ToString());
            reportViewer1.LocalReport.SetParameters(TotalSummary);

            ReportParameter TotalCreditRefund = new ReportParameter("TotalCreditRefund", totalCreditRefund.ToString());
            reportViewer1.LocalReport.SetParameters(TotalCreditRefund);

            ReportParameter TotalGiftCard = new ReportParameter("TotalGiftCard", totalGiftCard.ToString());
            reportViewer1.LocalReport.SetParameters(TotalGiftCard);

            ReportParameter TotalCredit = new ReportParameter("TotalCredit", totalCredit.ToString());
            reportViewer1.LocalReport.SetParameters(TotalCredit);

            ReportParameter HeaderTitle = new ReportParameter("HeaderTitle", "Transaction Summary for " + SettingController.ShopName);
            reportViewer1.LocalReport.SetParameters(HeaderTitle);

            ReportParameter Date = new ReportParameter("Date", " from " + dtpFrom.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpTo.Value.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(Date);

            PrintDoc.PrintReport(reportViewer1);
            #endregion
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region Function
        private void LoadData()
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;

            transList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.IsComplete == true && t.Type == TransactionType.Sale && t.PaymentTypeId == 1 && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            RtransList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.Type == TransactionType.Refund && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            DtransList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && (t.Type == TransactionType.Settlement || t.Type == TransactionType.Prepaid) && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            CRtransList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.Type == TransactionType.CreditRefund && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            GCtransList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.Type == TransactionType.Sale && t.PaymentTypeId == 3 && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            CtransList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.Type == TransactionType.Credit && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            MPUtransList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.Type == TransactionType.Sale && t.PaymentTypeId == 5 && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            FOCtrnsList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.Type == TransactionType.Sale && t.PaymentTypeId == 4 && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            ShowReportViewer1();
            lblPeriod.Text = fromDate.ToString() + " to " + toDate.ToString();
            // lblNumberofTransaction.Text = transList.Count.ToString();
            gbTransactionList.Text = "Transaction Summary Report";
            //lblTotalAmount.Text = "";
        }

        private void ShowReportViewer1()
        {
            long totalSale = 0, totalRefund = 0, totalDebt = 0, totalCreditRefund = 0, totalSummary = 0; long totalGiftCard = 0, totalCredit = 0, totalCreditRecieve = 0, totalCashInHand = 0, totalExpense = 0, totalIncomeAmount = 0, totalMPU = 0, totalFOC = 0, totalReceived = 0; long totalDiscount = 0, totalRefundDiscount = 0, totalCreditRefundDiscount = 0,Sc=0,Cf=0,Injec=0;
           
            totalSale =  transList.Sum(x => x.TotalAmount).Value;

            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;
            List<Transaction> discounttransList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && (t.Type == TransactionType.Sale || t.Type == TransactionType.Credit)  && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            foreach (Transaction t in discounttransList)
            {
                long itemdiscount = (long)t.TransactionDetails.Sum(x => (x.UnitPrice * (x.DiscountRate / 100)) * x.Qty);
                totalDiscount += (long)t.DiscountAmount - itemdiscount;
            }
            List<Transaction> injecttransList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && (t.Type == TransactionType.Sale || t.Type == TransactionType.Credit) && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            foreach (Transaction t in injecttransList)
            {
              
                Sc += (long)t.ServiceChages;
                Cf += (long)t.Consultantfees;
                Injec += (long)t.TransactionDetails.Sum(x => (x.InjectionRate));
            }

            totalRefund = RtransList.Sum(x => x.RecieveAmount).Value;
            totalRefundDiscount = RtransList.Sum(x => x.DiscountAmount).Value;
            totalDebt = DtransList.Sum(x => x.TotalAmount).Value;
            totalCreditRefund = CRtransList.Sum(x => x.RecieveAmount).Value;
            totalCreditRefundDiscount = CRtransList.Sum(x => x.DiscountAmount).Value;
            totalGiftCard = GCtransList.Sum(x => x.TotalAmount).Value;
            totalCredit = CtransList.Sum(x => x.TotalAmount).Value;
            totalCreditRecieve = CtransList.Sum(x => x.RecieveAmount).Value;
            totalMPU = MPUtransList.Sum(x => x.TotalAmount).Value;
            totalFOC = FOCtrnsList.Sum(x => x.TotalAmount).Value;
            
            
            //totalSummary = (totalSale + totalDebt + totalCreditRefund + totalGiftCard) - totalRefund;
            totalSummary = ((totalSale + totalCredit + totalGiftCard + totalMPU) - (totalRefund + totalCreditRefund + totalFOC));
            totalCashInHand = (totalSale + totalDebt + totalCreditRecieve) - (totalRefund + Cf + Injec);
            totalExpense = (totalRefund + totalCreditRefund + totalFOC);
            totalIncomeAmount = (totalSale + totalCredit + totalGiftCard + totalMPU);
            totalReceived = (totalSale + totalDebt + totalCreditRecieve);
            string reportPath = Application.StartupPath + "\\Reports\\TransactionSummary.rdlc";
            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter TotalDiscount = new ReportParameter("TotalDiscount", totalDiscount.ToString());
            reportViewer1.LocalReport.SetParameters(TotalDiscount);

            ReportParameter CFF = new ReportParameter("CF", Cf.ToString());
            reportViewer1.LocalReport.SetParameters(CFF);

            ReportParameter SCC = new ReportParameter("SC", Sc.ToString());
            reportViewer1.LocalReport.SetParameters(SCC);

            ReportParameter Inject = new ReportParameter("Injection", Injec.ToString());
            reportViewer1.LocalReport.SetParameters(Inject);

            ReportParameter TotalRefundDiscount = new ReportParameter("TotalRefundDiscount", totalRefundDiscount.ToString());
            reportViewer1.LocalReport.SetParameters(TotalRefundDiscount);

            ReportParameter TotalCreditRefundDiscount = new ReportParameter("TotalCreditRefundDiscount", totalCreditRefundDiscount.ToString());
            reportViewer1.LocalReport.SetParameters(TotalCreditRefundDiscount);

            ReportParameter ActualAmount = new ReportParameter("ActualAmount", totalReceived.ToString());
            reportViewer1.LocalReport.SetParameters(ActualAmount);

            ReportParameter TotalFOC = new ReportParameter("TotalFOC", totalFOC.ToString());
            reportViewer1.LocalReport.SetParameters(TotalFOC);

            ReportParameter TotalMPU = new ReportParameter("TotalMPU", totalMPU.ToString());
            reportViewer1.LocalReport.SetParameters(TotalMPU);

            ReportParameter TotalSale = new ReportParameter("TotalSale", totalSale.ToString());
            reportViewer1.LocalReport.SetParameters(TotalSale);

            ReportParameter CreditRecieve = new ReportParameter("CreditRecieve", totalCreditRecieve.ToString());
            reportViewer1.LocalReport.SetParameters(CreditRecieve);

            ReportParameter Expense = new ReportParameter("Expense", totalExpense.ToString());
            reportViewer1.LocalReport.SetParameters(Expense);

            ReportParameter IncomeAmount = new ReportParameter("IncomeAmount", totalIncomeAmount.ToString());
            reportViewer1.LocalReport.SetParameters(IncomeAmount);

            ReportParameter CashInHand = new ReportParameter("CashInHand", totalCashInHand.ToString());
            reportViewer1.LocalReport.SetParameters(CashInHand);

            ReportParameter TotalDebt = new ReportParameter("TotalDebt", totalDebt.ToString());
            reportViewer1.LocalReport.SetParameters(TotalDebt);

            ReportParameter TotalRefund = new ReportParameter("TotalRefund", totalRefund.ToString());
            reportViewer1.LocalReport.SetParameters(TotalRefund);

            ReportParameter TotalSummary = new ReportParameter("TotalSummary", totalSummary.ToString());
            reportViewer1.LocalReport.SetParameters(TotalSummary);

            
            ReportParameter TotalCreditRefund = new ReportParameter("TotalCreditRefund", totalCreditRefund.ToString());
            reportViewer1.LocalReport.SetParameters(TotalCreditRefund);

            ReportParameter TotalGiftCard = new ReportParameter("TotalGiftCard", totalGiftCard.ToString());
            reportViewer1.LocalReport.SetParameters(TotalGiftCard);

            ReportParameter TotalCredit = new ReportParameter("TotalCredit", totalCredit.ToString());
            reportViewer1.LocalReport.SetParameters(TotalCredit);

            ReportParameter HeaderTitle = new ReportParameter("HeaderTitle", "Transaction Summary for " + SettingController.ShopName  );
            reportViewer1.LocalReport.SetParameters(HeaderTitle);

            ReportParameter Date = new ReportParameter("Date", " from " + dtpFrom.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpTo.Value.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(Date);

            reportViewer1.RefreshReport();
        }

        #endregion

       
    }
}
