using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.APP_Data;
using System.Data.Objects;
using Microsoft.Reporting.WinForms;

namespace POS
{
    public partial class NetIncomeSummaryInformationReport : Form
    {

        #region Initialize
        public NetIncomeSummaryInformationReport()
        {
            InitializeComponent();
        }
        #endregion

        #region variable

        bool IsStart = false;
        DateTime _fromDate = new DateTime();
        DateTime _toDate = new DateTime();
        POSEntities entity = new POSEntities();
        #endregion

        private void NetIncomeSummaryInformationReport_Load(object sender, EventArgs e)
        {
            dtFrom.Format = DateTimePickerFormat.Custom;
            dtFrom.CustomFormat = "dd-MMM-yyyy";

            dtTo.Format = DateTimePickerFormat.Custom;
            dtTo.CustomFormat = "dd-MMM-yyyy";

            Default_Date();
            IsStart = true;
            LoadData();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            Date_Assign();
            LoadData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            Date_Assign();
            LoadData();
        }

        private void cboExpenseCag_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Method
        private void Default_Date()
        {
            dtTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            Date_Assign();
        }

        private void Date_Assign()
        {
            _fromDate = dtFrom.Value;
            _toDate = dtTo.Value;
        }

        private class PercentTable
        {
            public long? Group { get; set; }
            public long? Total { get; set; }
            public string Staffs { get; set; }

            public decimal? PercentIndividual { get; set; }
        }
        private void LoadData()
        {
            if (IsStart)
            {
                int? PTTConsultationFees = 0, ODrConsulationFees = 0,
               ServiceChargesFees = 0,
                 PTTInjectionFees = 0, ODrInjectionFees = 0, BookIncomeFees = 0, MedicineIncomeFees = 0,
                 BookExpFees = 0, MedicineExpFees = 0, XRayIncomeFees = 0, XRayExpFees = 0, XRayPurchaseFees=0, CommoditiesFees = 0, SalaryFees = 0,
                 PTIncomeFees = 0, PartTimePTFees = 0, DailyPTFees = 0, ODrInjectionChargesFees = 0,CorsetIncomesFees = 0,CorsetExpFees=0, CollarIncomeFees=0, CollarExpFees=0;

                try{
                #region Consultation fee and Service fee
                try
                {
                    //Prof Than Toe Transaction List
                    var DoctorTranList = (from t in entity.Transactions
                                          join d in entity.DoctorPhysios on t.DoctorID equals d.Id
                                          where
                                              //d.Name == "Prof. Than Toe" && 
                                          d.IsDoctor == true
                                          && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                                          && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                                          && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                                          && t.IsActive == true

                                          select new
                                          {
                                              DoctorName = d.Name,
                                              ConsultantFees = t.Consultantfees,
                                              ServiceCharges = t.ServiceChages
                                          }).ToList();




                    //Doctor Consulation fee and Service Fees
                    if (DoctorTranList.Count > 0)
                    {
                        PTTConsultationFees = DoctorTranList.Where(x => x.DoctorName == "Prof. Than Toe").Sum(o => o.ConsultantFees);
                        ODrConsulationFees = DoctorTranList.Where(x => x.DoctorName != "Prof. Than Toe").Sum(o => o.ConsultantFees);
                        ServiceChargesFees = DoctorTranList.Sum(o => o.ServiceCharges);
                    }
                }
                catch
                {
                }
                #endregion

                #region Injection Fee
                //Injection Fees List by doctor name
                var InjectionList = (from td in entity.TransactionDetails
                                     join t in entity.Transactions on td.TransactionId equals t.Id
                                     join d in entity.DoctorPhysios on t.DoctorID equals d.Id
                                     where d.IsDoctor == true
                                  && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                                  && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                                  && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                                  && td.InjectionRate > 0
                                  && t.IsActive == true

                                     select new
                                     {
                                         DoctorName = d.Name,
                                        InjectionFees = td.InjectionRate,
                                        Qty= td.Qty,
                                         UnitPrice=td.UnitPrice
                                     }
                               ).ToList();

              
                if (InjectionList.Count > 0)
                {
                    //Prof Than Thoe  and Other Dr Injection Fees 
                    PTTInjectionFees = InjectionList.Where(x => x.DoctorName == "Prof. Than Toe").Sum(x => Convert.ToInt32(x.Qty * x.UnitPrice));
                    ODrInjectionFees = InjectionList.Where(x => x.DoctorName != "Prof. Than Toe").Sum(x => Convert.ToInt32(x.Qty * x.UnitPrice));

                    //Income Injection Fees
                    ODrInjectionChargesFees = InjectionList.Where(x => x.InjectionFees > 0 && x.DoctorName != "Prof. Than Toe").Sum(x => Convert.ToInt32(x.InjectionFees));
                }

                #endregion

                #region Book and Medicine Income Fee
                List<string> cagType = new List<string> { "Book", "Medicine","X-Ray" };
                var ProIncomeList = (from td in entity.TransactionDetails
                                     join t in entity.Transactions on td.TransactionId equals t.Id
                                     join p in entity.Products on td.ProductId equals p.Id
                                     join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                                     where cagType.Contains(pc.Name)
                                    && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                                  && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                                  && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                                  && t.IsActive == true 
                                     select new
                                     {
                                         TranId=td.TransactionId,
                                         ParentId=t.ParentId,
                                         Type=t.Type,
                                         TotalAmt = td.TotalAmount,
                                         CagName = pc.Name
                                     }
                              ).ToList();

                if (ProIncomeList.Count > 0)
                {
                var _tranIdList= ProIncomeList.Where(x=>x.Type=="Sale").Select(x=>x.TranId).ToList();
                int _bookRefundTotalAmt = 0, _medicineRefundTotalAmt = 0;
                 var _bookRefundList= ProIncomeList.Where(x => _tranIdList.Contains(x.ParentId) && x.Type=="Refund" && x.CagName=="Book") .ToList();
                 var _medicineRefundList = ProIncomeList.Where(x => _tranIdList.Contains(x.ParentId) && x.Type == "Refund" && x.CagName == "Medicine").ToList();

                    _bookRefundTotalAmt= _bookRefundList.Sum(x=>Convert.ToInt32(x.TotalAmt));
                    _medicineRefundTotalAmt  = _medicineRefundList.Sum(x=>Convert.ToInt32(x.TotalAmt));



                    var _bookIncomefees = ProIncomeList.Where(x => x.CagName == "Book" && x.Type == "Sale").Sum(x => x.TotalAmt);
                    BookIncomeFees = Convert.ToInt32(_bookIncomefees) - Convert.ToInt32(_bookRefundTotalAmt);

                    var _medicineIncomesfees = ProIncomeList.Where(x => x.CagName == "Medicine" && x.Type == "Sale").Sum(x => x.TotalAmt);
                    MedicineIncomeFees = Convert.ToInt32(_medicineIncomesfees) -  Convert.ToInt32 (_medicineRefundTotalAmt);

                }

                #endregion

                #region Corset and Collar Income Fee
                List<string> _CcagType = new List<string> { "CORSET", "COLLAR"};
                var CIncomeList = (from td in entity.TransactionDetails
                                     join t in entity.Transactions on td.TransactionId equals t.Id
                                     join p in entity.Products on td.ProductId equals p.Id
                                     join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                                     where _CcagType.Contains(pc.Name)
                                    && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                                  && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                                  && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                                  && t.IsActive == true 
                                     select new
                                     {
                                         TranId = td.TransactionId,
                                         ParentId = t.ParentId,
                                         Type = t.Type,
                                         TotalAmt = td.TotalAmount,
                                         CagName = pc.Name
                                     }
                              ).ToList();
                if (CIncomeList.Count > 0)
                {
                    int _corsetRefundTotalAmt = 0, _collarRefundTotalAmt = 0;
                var _CtranIdList = CIncomeList.Where(x => x.Type == "Sale").Select(x => x.TranId).ToList();

                 var _corsetRefundList = CIncomeList.Where(x => _CtranIdList.Contains(x.ParentId) && x.Type == "Refund" && x.CagName == "CORSET").ToList();
                 var _collarRefundList = CIncomeList.Where(x => _CtranIdList.Contains(x.ParentId) && x.Type == "Refund" && x.CagName == "COLLAR").ToList();

                 _corsetRefundTotalAmt = _corsetRefundList.Sum(x => Convert.ToInt32(x.TotalAmt));
                 _collarRefundTotalAmt = _collarRefundList.Sum(x => Convert.ToInt32(x.TotalAmt));
          
                    var _corsetIncomeFees = CIncomeList.Where(x => x.CagName == "CORSET" && x.Type=="Sale").Sum(x => x.TotalAmt);
                    CorsetIncomesFees = Convert.ToInt32(_corsetIncomeFees) - Convert.ToInt32(_corsetRefundTotalAmt);

                    var _colarIncomeFees = CIncomeList.Where(x => x.CagName == "COLLAR" && x.Type == "Sale").Sum(x => x.TotalAmt);
                    CollarIncomeFees = Convert.ToInt32(_colarIncomeFees) - Convert.ToInt32(_collarRefundTotalAmt);

                }

                #endregion

                #region Book and Medicine Expenditure Fee

                ////////////////////////////var ProExpList = (from pd in entity.PurchaseDetails
                ////////////////////////////                  join pdt in entity.PurchaseDetailInTransactions on pd.Id equals pdt.PurchaseDetailId
                ////////////////////////////                  join td in entity.TransactionDetails on pdt.TransactionDetailId equals td.Id
                ////////////////////////////                  join t in entity.Transactions on td.TransactionId equals t.Id
                ////////////////////////////                  join p in entity.Products on pd.ProductId equals p.Id
                ////////////////////////////                  join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                ////////////////////////////                  where cagType.Contains(pc.Name)
                ////////////////////////////                 && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                ////////////////////////////               && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                ////////////////////////////                       && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                ////////////////////////////                          && t.IsActive == true && pd.IsDeleted == false && td.IsDeleted == false
                ////////////////////////////                  select new
                ////////////////////////////                  {
                ////////////////////////////                      TotalAmt = (pdt.Qty * pd.UnitPrice),
                ////////////////////////////                      CagName = pc.Name
                ////////////////////////////                  }
                ////////////////////////////              ).ToList();

                var ProExpList = (from pd in entity.PurchaseDetails
                                   join mp in entity.MainPurchases on pd.MainPurchaseId equals mp.Id
                                  join p in entity.Products on pd.ProductId equals p.Id
                                  join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                                  where cagType.Contains(pc.Name)
                                 && EntityFunctions.TruncateTime(mp.Date.Value) >= _fromDate
                               && EntityFunctions.TruncateTime(mp.Date.Value) <= _toDate
                                       && mp.IsDeleted == false && mp.IsCompletedInvoice ==true
                                          && mp.IsActive == true && pd.IsDeleted == false 
                                  select new
                                  {
                                      TotalAmt = (pd.Qty * pd.UnitPrice),
                                      CagName = pc.Name
                                  }
                           ).ToList();

                if (ProExpList.Count > 0)
                {
                    var _bookExpfees = ProExpList.Where(x => x.CagName == "Book").Sum(x => x.TotalAmt);
                    BookExpFees = Convert.ToInt32(_bookExpfees);

                    var _medicineExpfees = ProExpList.Where(x => x.CagName == "Medicine").Sum(x => x.TotalAmt);
                    MedicineExpFees = Convert.ToInt32(_medicineExpfees);

                }

                #endregion

                #region Corset and Collar Expenditure Fee


                var CExpList = (from pd in entity.PurchaseDetails
                                  join mp in entity.MainPurchases on pd.MainPurchaseId equals mp.Id
                                  join p in entity.Products on pd.ProductId equals p.Id
                                  join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                                  where _CcagType.Contains(pc.Name)
                                 && EntityFunctions.TruncateTime(mp.Date.Value) >= _fromDate
                               && EntityFunctions.TruncateTime(mp.Date.Value) <= _toDate
                                       && mp.IsDeleted == false && mp.IsCompletedInvoice == true
                                          && mp.IsActive == true && pd.IsDeleted == false
                                  select new
                                  {
                                      TotalAmt = (pd.Qty * pd.UnitPrice),
                                      CagName = pc.Name
                                  }
                           ).ToList();

                if (CExpList.Count > 0)
                {
                    var _corsetExpFees = CExpList.Where(x => x.CagName == "CORSET").Sum(x => x.TotalAmt);
                    CorsetExpFees = Convert.ToInt32(_corsetExpFees);

                    var _collarExpfees = CExpList.Where(x => x.CagName == "COLLAR").Sum(x => x.TotalAmt);
                    CollarExpFees = Convert.ToInt32(_collarExpfees);

                }

                #endregion

                #region x-ray Income Fee

                var XRayList = (from td in entity.TransactionDetails
                                join t in entity.Transactions on td.TransactionId equals t.Id
                                join p in entity.Products on td.ProductId equals p.Id
                                join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                                where pc.Name == "X-Ray"
                               && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                             && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                             && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                             && t.IsActive == true
                                select td.TotalAmount).ToList();

                if (XRayList.Count > 0)
                {
                    var _xrayncomefees = XRayList.Sum(x => x);
                    XRayIncomeFees = Convert.ToInt32(_xrayncomefees);
                }

                #endregion

                #region x-ray expenditure Fee and x-ray purchase fee
                //Injection Fees List by doctor name
                var XRayExpList = (from td in entity.TransactionDetails
                                   join t in entity.Transactions on td.TransactionId equals t.Id
                                   join d in entity.DoctorPhysios on t.DoctorID equals d.Id
                                   where d.IsDoctor == true
                                && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                                && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                                && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                                && t.IsActive == true

                                   select new
                                   {
                                       DoctorName = d.Name,
                                       XRayFees = td.XRayRate
                                   }
                               ).ToList();

                //Prof Than Thoe  and Other Dr Injection Fees 
                if (XRayExpList.Count > 0)
                {
                    // PTTInjectionFees = InjectionList.Where(x => x.DoctorName == "Prof. Than Toe").Sum(x => Convert.ToInt32(x.InjectionFees));
                    XRayExpFees = XRayExpList.Sum(x => Convert.ToInt32(x.XRayFees));
                }
                
                //X-Ray Purchase List
                var XRayPurchaseList = (from pd in entity.PurchaseDetails
                                  join pdt in entity.PurchaseDetailInTransactions on pd.Id equals pdt.PurchaseDetailId
                                  join td in entity.TransactionDetails on pdt.TransactionDetailId equals td.Id
                                  join t in entity.Transactions on td.TransactionId equals t.Id
                                  join p in entity.Products on pd.ProductId equals p.Id
                                  join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                                  where pc.Name == "X-Ray"
                                 && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                               && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                                       && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                                          && t.IsActive == true && pd.IsDeleted == false && td.IsDeleted == false
                                  select new
                                  {
                                      TotalAmt = (pdt.Qty * pd.UnitPrice),
                                      CagName = pc.Name
                                  }
                              ).ToList();
                if (XRayPurchaseList.Count > 0)
                {
                    var _xrayPurchasefees = XRayPurchaseList.Sum(x => x.TotalAmt);
                    XRayPurchaseFees = Convert.ToInt32(_xrayPurchasefees);

                }
                #endregion

                #region  Commodities and Salary Fees

                var ExpenseList = (from e in entity.Expenses
                                   join ec in entity.ExpenseCategories on e.ExpenseCategoryId equals ec.Id
                                   where e.IsApproved == true && e.IsDeleted == false
                           && EntityFunctions.TruncateTime(e.ExpenseDate.Value) >= _fromDate
                           && EntityFunctions.TruncateTime(e.ExpenseDate.Value) <= _toDate
                                   select new
                                   {
                                       TotalAmount = e.TotalExpenseAmount,
                                       ExpCag = ec.Name
                                   }
                                   ).ToList();

                if (ExpenseList.Count > 0)
                {
                    //var _applianceFees = ExpenseList.Where(x => x.ExpCag == "Appliance").Sum(x => x.TotalAmount);
                    //ApplianceFees = Convert.ToInt32(_applianceFees);

                    var _commoditiesFees = ExpenseList.Where(x => x.ExpCag == "Commodities").Sum(x => x.TotalAmount);
                    CommoditiesFees = Convert.ToInt32(_commoditiesFees);

                    var _salaryFees = ExpenseList.Where(x => x.ExpCag == "Salary").Sum(x => x.TotalAmount);
                    SalaryFees = Convert.ToInt32(_salaryFees);
                }

                #endregion

                #region PT Income fees

                var PTIncomeList = (from td in entity.TransactionDetails
                                    join t in entity.Transactions on td.TransactionId equals t.Id
                                    join p in entity.Products on td.ProductId equals p.Id
                                    join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                                    where pc.Name == "PT"
                                    && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                                  && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                                  && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                                  && t.IsActive == true
                                    select td).ToList();

                if (PTIncomeList.Count > 0)
                {
                    var _ptIncomeFees = PTIncomeList.Sum(x => x.TotalAmount);
                    PTIncomeFees = Convert.ToInt32(_ptIncomeFees);
                }
                #endregion

                #region PT Expenditure Fees"
                var DailyDutyPTList = (from t in entity.Transactions
                                       join td in entity.TransactionDetails on t.Id equals td.TransactionId
                                       join da in entity.DailyDutyPhysios on t.GroupID equals da.Id
                                       join p in entity.Products on td.ProductId equals p.Id
                                       join pc in entity.ProductCategories on p.ProductCategoryId equals pc.Id
                                       where (t.GroupID != null || t.GroupID != 0)
                                           && pc.Name == "PT"
                                           && EntityFunctions.TruncateTime(t.DateTime.Value) >= _fromDate
                                          && EntityFunctions.TruncateTime(t.DateTime.Value) <= _toDate
                                          && t.IsDeleted == false && t.PaymentTypeId != 4 && t.IsComplete == true
                                          && t.IsActive == true 

                                       select new
                                       {
                                           PartTimePT = da.StaffID,
                                           DailyPT = da.GroupID,
                                           TotalAmount = td.TotalAmount,
                                           DutyDate = da.DutyDate,
                                           GroupT = t.GroupID
                                       }).ToList();
       
                #region PartTime PT Fees
                var ParttimePTList = DailyDutyPTList.Select(x => x.PartTimePT).ToList();
                    //LHST
                var PPercentPTList = DailyDutyPTList.GroupBy(x => new { x.GroupT, x.PartTimePT }).ToList()
                                        .Select(y => new PercentTable
                                        {
                                            Total=y.Sum(x=>x.TotalAmount),
                                            Group=y.Key.GroupT,
                                            Staffs=y.Key.PartTimePT
                                           
                                        }).ToList();
                List<PercentTable> percentSeperatedList = new List<PercentTable>();
                var physiolist = entity.DoctorPhysios.ToList();
             
                foreach (var p in PPercentPTList)
                {
                    string[] sStaff = p.Staffs.Split(',').Select(s => s.ToString()).ToArray();
                    foreach (var s in sStaff)
                    {
                        if (s.ToString()!="")
                        {
                            PercentTable singlerow = new PercentTable();
                            singlerow.Group = p.Group;
                            singlerow.Total = p.Total;
                            singlerow.Staffs = s.ToString();
                            int staffid = Convert.ToInt16(s);
                            singlerow.PercentIndividual = physiolist.Where(d => d.Id == staffid).FirstOrDefault()== null ? 0 : physiolist.Where(d => d.Id == staffid).FirstOrDefault().ForPhysioTrain;
                            percentSeperatedList.Add(singlerow);
                        }
                        
                    }
                }
                //Lhst
                

                try
                {
                    if (ParttimePTList.Count > 0)
                    {
                        while (ParttimePTList.FindIndex(a => a == "") != -1)
                        {
                            ParttimePTList[ParttimePTList.FindIndex(a => a == "")] = "0";
                        }
                       
                        var _joinparttimePTList = string.Join(",", ParttimePTList.Select(n => n.ToString()).ToArray());

                        List<string> _splitCollectSTaffList = new List<string>(_joinparttimePTList.Split(','));

                        var _SplintParttimePTIntList = _splitCollectSTaffList.Select(int.Parse).ToList();

                        var ParttimePTIntList = _SplintParttimePTIntList.Select(grp => grp).Distinct().ToList();

                        //LHST
                        var PartTimePT1DayFees = entity.DoctorPhysios.Where(x => ParttimePTIntList.Contains(x.Id) && x.ForPhysioTrain > 100).ToList().Sum(x => x.ForPhysioTrain);
                        var PartTimePT1DayFeesPercent = entity.DoctorPhysios.Where(x => ParttimePTIntList.Contains(x.Id) && x.ForPhysioTrain <= 100).ToList();
                        if (PartTimePT1DayFees!=null)
                        {
                            //var _partT1DayFees = Convert.ToInt32(PartTimePT1DayFees);
                            //var chk = DailyDutyPTList.OrderBy(x => x.DutyDate.Year).OrderBy(x => x.DutyDate.Month).OrderBy(x => x.DutyDate.Day).Select(x => x.PartTimePT).Distinct().ToList();
                            //int parttimePTCount = DailyDutyPTList.OrderBy(x => x.DutyDate.Year).OrderBy(x => x.DutyDate.Month).OrderBy(x => x.DutyDate.Day).Select(x => x.PartTimePT).Distinct().Count();
                            ////PartTimePTFees =
                            percentSeperatedList.Where(x=>x.PercentIndividual>100).ToList().ForEach(x=>PartTimePTFees+=(int)x.PercentIndividual);
                        }
                        if(PartTimePT1DayFeesPercent.Count()>0)
                        {

                            var SeperatedPercentToGroupBy = percentSeperatedList.GroupBy(p => new { p.Group, p.Total }).
                                                            Select(x => new 
                                                            { 
                                                                x.Key.Total,
                                                                Percent=(x.Where(z=>z.PercentIndividual<=100).Sum(z=>z.PercentIndividual)),
                                                                x.Key.Group
                                                            }).ToList();
                            long? penc=0;
                            SeperatedPercentToGroupBy.ForEach(x => penc += Convert.ToInt16( (x.Total * SettingController.DefaultPhysioPercent / 100)*x.Percent/100));
                            PartTimePTFees += Convert.ToInt16(penc);
                        }
                      
                    }
                    //LHST
                #endregion

                    #region Daily PT Fees
                    var DailyPTGroupList = DailyDutyPTList.Select(x => x.DailyPT).ToList();

                    if (DailyPTGroupList.Count > 0 )
                    {
                        var DailyPTDailyPTGroupListTotalAmtList = DailyDutyPTList.Where(x => DailyPTGroupList.Contains(x.DailyPT)).Sum(x => x.TotalAmount);

                        //zp

                        var Data = DailyDutyPTList.GroupBy(x => new { Date = x.DutyDate.Date, x.DailyPT })

                                  .Select(y => new Transaction()
                                  {

                                      TotalAmount = (y.Sum(x => x.TotalAmount)),
                                      GroupID = y.Key.DailyPT,
                                    

                                  }).ToList();

                        //zp
                        int _physioPercent = SettingController.DefaultPhysioPercent;
                     

                        var DailyPTlist = (from gp in entity.GroupByPhysios where DailyPTGroupList.Contains(gp.GroupID) select gp.PhysioID).ToList();

                        var docGP=(from p in entity.DoctorPhysios
                                   join gp in entity.GroupByPhysios on p.Id equals gp.PhysioID 
                                   select new{
                                      percent= p.ForPhysioTrain,
                                      groupid=gp.GroupID,
                                      stafid=p.Id
                                   }).ToList();
                        foreach (var pp in Data)
                        {
                            var sumpercent = docGP.Where(x => x.groupid == pp.GroupID).Sum(x => x.percent);
                            var subSettingPercent = (pp.TotalAmount * _physioPercent / 100);
                            DailyPTFees += Convert.ToInt32(subSettingPercent) * Convert.ToInt32(sumpercent) / 100;

                        }

                        #region old
                        //var DailyPTTotalPercent = entity.DoctorPhysios.Where(x => DailyPTlist.Contains(x.Id)).Sum(x => x.ForPhysioTrain);

                        //if (DailyPTTotalPercent != null)
                        //{
                            //DailyPTFees = Convert.ToInt32(SubstractPTPercent) * Convert.ToInt32(DailyPTTotalPercent)  / 100;
                        //}
                        //else
                        //{
                        //    DailyPTFees = Convert.ToInt32(SubstractPTPercent) * PartTimePT1DayFeesPercent / 100;
                        //}
                        #endregion
                    }
                    
                    #endregion
                #endregion
                }
                    catch
                {
                    throw;
                    }
                List<NetIncomeReportController> reportList = new List<NetIncomeReportController>();

                #region Assign Data to For DataSet
                    dsReportTemp dsReport = new dsReportTemp();
                    dsReportTemp.NetIncomeSummaryDataTable dtPdReport = (dsReportTemp.NetIncomeSummaryDataTable)dsReport.Tables["NetIncomeSummary"];

                    dsReportTemp.NetIncomeSummaryRow newRow = dtPdReport.NewNetIncomeSummaryRow();

                    newRow.DrTTConsultationFee = PTTConsultationFees.ToString();
                    newRow.OtherDrConsultationFee = ODrConsulationFees.ToString();
                    newRow.DrTTInjectionFee =Convert.ToInt32( PTTInjectionFees);
                    newRow.OtherDrInjectionFee =Convert.ToInt32(  ODrInjectionFees);
                    newRow.OtherDoctorsInjectionChargesFees = Convert.ToInt32(ODrInjectionChargesFees);
                    newRow.PTIncomeFees = Convert.ToInt32(PTIncomeFees);
                    newRow.DailyPTFee = DailyPTFees.ToString();
                    newRow.PartTimePTFee = PartTimePTFees.ToString();
                    newRow.ServiceChargesFee = Convert.ToInt32(ServiceChargesFees);
                    newRow.BookIncomeFee = Convert.ToInt32(BookIncomeFees);
                    newRow.BookExpFees = Convert.ToInt32(BookExpFees);
                    newRow.XRayIncomeFee = Convert.ToInt32(XRayIncomeFees);
                    newRow.XRayExpFees = XRayExpFees.ToString();
                   // newRow.ApplianceExpFee = Convert.ToInt32(ApplianceFees);
                    newRow.CorsetIncomeFees = Convert.ToInt32(CorsetIncomesFees);
                    newRow.CorsetExpFees =  Convert.ToInt32(CorsetExpFees);
                    newRow.CollarIncomeFees = Convert.ToInt32(CollarIncomeFees);
                    newRow.CollarExpFees = Convert.ToInt32(CollarExpFees);
                    newRow.MedicineIncomeFee = Convert.ToInt32(MedicineIncomeFees);
                    newRow.MedicineExpFees = Convert.ToInt32(MedicineExpFees);
                    newRow.CommoditiesExpFee = Convert.ToInt32(CommoditiesFees);
                    newRow.SalaryExpFee = Convert.ToInt32(SalaryFees);
                    newRow.XRayPurchaseFees = XRayPurchaseFees.ToString();
                    dtPdReport.AddNetIncomeSummaryRow(newRow);

                    #endregion

               #region Show Report Viewer Part

                    ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["NetIncomeSummary"]);
                    string reportPath = Application.StartupPath + "\\Reports\\SanpyaSummaryReport.rdlc";

                    reportViewer1.LocalReport.ReportPath = reportPath;
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.RefreshReport();

                }
                catch
                {
                }
                    #endregion
            }
        }
        #endregion
    }
}

