using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Runtime.InteropServices;
using POS.APP_Data;

namespace POS
{
    public partial class PrintBarcode : Form
    {
        #region Variable

        public int productId;
        POSEntities entity = new POSEntities();
        Product productObj = new Product();
        #endregion

        #region Event

        public PrintBarcode()
        {
            InitializeComponent();
        }

        private void PrintBarcode_Load(object sender, EventArgs e)
        {
            productObj = (from p in entity.Products where p.Id == productId select p).FirstOrDefault();
            lblBarCode.Text = productObj.Barcode.ToString();
            lblId.Text = productObj.Barcode.ToString();
            lblItemName.Text = productObj.Name;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region [ Print ]


            //string reportPath = "";
            //ReportViewer rv = new ReportViewer();
            //reportPath = Application.StartupPath + "\\Reports\\Sticker.rdlc";
            //rv.Reset();
            //rv.LocalReport.ReportPath = reportPath;

            //ReportParameter ProductName = new ReportParameter("ProductName", productObj.Name);
            //rv.LocalReport.SetParameters(ProductName);

            //ReportParameter ProductId = new ReportParameter("ProductId", productObj.Id.ToString());
            //rv.LocalReport.SetParameters(ProductId);

            //ReportParameter ProductIdBarcode = new ReportParameter("ProductIdBarcode", productObj.Id.ToString());
            //rv.LocalReport.SetParameters(ProductIdBarcode);

            //int t = Convert.ToInt32(txtQty.Text);
            //for (int i = 0; i < t; i++)
            //{
            //    PrintDoc.PrintReport(rv, "BarcodeSticker");
            //}

            //string bcode = productObj.Barcode + "  " + productObj.Price.ToString() + "Ks";
            string price = productObj.Price + "Ks";

            print(productObj.Barcode.ToString(), productObj.Name.ToString(),price);
           
            #endregion
        }

        private void print(string barcode, string productname, string bid)
        {
            PrintLab.OpenPort("POSTEK C168/200s (Copy 1)");
            PrintLab.PTK_ClearBuffer();
            PrintLab.PTK_SetPrintSpeed(4);
            PrintLab.PTK_SetDarkness(10);
            PrintLab.PTK_SetLabelHeight(1, 1, 0, false);
            PrintLab.PTK_SetLabelWidth(800);
            try
            {
                for (int i = 0; i <= 2; i++)
                {

                    PrintLab.PTK_DrawTextTrueTypeW(350, 3, 25, 0, "Arial", 1, 250, false, false, false, "A1", bid);
                    PrintLab.PTK_DrawText(290, 30, 0, 1, 1, 1, 'N', productname);
                    PrintLab.PTK_DrawBarcode(290, 50, 0, "1", 2, 2, 50, 'B', barcode);
                    PrintLab.PTK_PrintLabel(1, 2);

                }
            }
            catch (Exception e)
            {

            }
           
            //Book Editb = (from bb in l.Books where bb.BookID == bid select bb).FirstOrDefault();
            //Editb.PrintStatus = false;

            //l.Entry(Editb).State = EntityState.Modified;
            //l.SaveChanges();
            //if (rdoNew.Checked == true)
            //{

            //    fillComboBarcode(Editb.Title, true);
            //}
            //else if (rdoOld.Checked == true)
            //{

            //    fillComboBarcode(Editb.Title, false);
            //}

            PrintLab.ClosePort();
        }


     


        #endregion
    }
   
}
public class PrintLab
{
    [DllImport("WINPSK.dll")]
    public static extern int OpenPort(string printname);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_SetPrintSpeed(uint px);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_SetDarkness(uint id);
    [DllImport("WINPSK.dll")]
    public static extern int ClosePort();
    [DllImport("WINPSK.dll")]
    public static extern int PTK_PrintLabel(uint number, uint cpnumber);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawTextTrueTypeW
                                        (int x, int y, int FHeight,
                                        int FWidth, string FType,
                                        int Fspin, int FWeight,
                                        bool FItalic, bool FUnline,
                                        bool FStrikeOut,
                                        string id_name,
                                        string data);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawBarcode(uint px,
                                    uint py,
                                    uint pdirec,
                                    string pCode,
                                    uint pHorizontal,
                                    uint pVertical,
                                    uint pbright,
                                    char ptext,
                                    string pstr);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_SetLabelHeight(uint lheight, uint gapH, int gapOffset, bool bFlag);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_SetLabelWidth(uint lwidth);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_ClearBuffer();
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawRectangle(uint px, uint py, uint thickness, uint pEx, uint pEy);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawLineOr(uint px, uint py, uint pLength, uint pH);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawBar2D_QR(uint x, uint y, uint w, uint v, uint o, uint r, uint m, uint g, uint s, string pstr);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawBar2D_Pdf417(uint x, uint y, uint w, uint v, uint s, uint c, uint px, uint py, uint r, uint l, uint t, uint o, string pstr);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_PcxGraphicsDel(string pid);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_PcxGraphicsDownload(string pcxname, string pcxpath);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawPcxGraphics(uint px, uint py, string gname);
    [DllImport("WINPSK.dll")]
    public static extern int PTK_DrawText(uint px, uint py, uint pdirec, uint pFont, uint pHorizontal, uint pVertical, char ptext, string pstr);

}