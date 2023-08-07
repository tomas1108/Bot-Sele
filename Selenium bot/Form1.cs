using DevExpress.Utils;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors.Frames;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static DevExpress.Drawing.Internal.Fonts.DXFontMetrics;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using AutoItX3Lib;
using System.Security.Cryptography;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.Data.Helpers;
using System.Xml.Linq;
using System.IO;

using DevExpress.XtraEditors;
using OpenQA.Selenium.Support.UI;
using HSD.Core.Domain;
using Newtonsoft.Json;
using System.Data.SqlTypes;
using DevExpress.XtraReports;

namespace Selenium_bot
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private string connStr;
        private string constr;
        private OleDbConnection con1;
        private BindingSource bSource;
        DataTable dt = new DataTable();
        OleDbDataAdapter sda = new OleDbDataAdapter();

        string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data source=D:\Selenium bot\Selenium bot\Database\dbSe.mdb";
        private string date;
        private string mont_date;
        private string month;
        private IWebElement arrow_bt;
        private IWebElement days;
        private string text;
        private DataSet ds1;
        AutoItX3 autoIT = new AutoItX3();

        string _selector = "";
        string _value = "";
        string path = "D:\\FRE\\Cai_FRE\\Report\\FK";

       

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnLogIn.Visible = true;
            fill_combo();
            ConnectToAccess();



        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\dbSe.mdb; Persist Security Info = False; ");
                OleDbCommand command = new OleDbCommand("", connection);
                DataGridViewRow dgRow = dbSele.CurrentRow;
                command.Parameters.AddWithValue("Name", dgRow.Cells[1].Value == DBNull.Value ? "" : dgRow.Cells[1].Value);
                command.Parameters.AddWithValue("userName", dgRow.Cells[2].Value == DBNull.Value ? "" : dgRow.Cells[2].Value);
                command.Parameters.AddWithValue("Value", dgRow.Cells[3].Value == DBNull.Value ? "" : dgRow.Cells[3].Value);
                command.Parameters.AddWithValue("Link", dgRow.Cells[4].Value == DBNull.Value ? "" : dgRow.Cells[4].Value);
                command.Parameters.AddWithValue("Status", dgRow.Cells[5].Value == DBNull.Value ? "" : dgRow.Cells[5].Value);
                command.Parameters.AddWithValue("Selector", dgRow.Cells[6].Value == DBNull.Value ? "" : dgRow.Cells[6].Value);
                command.Parameters.AddWithValue("Type", dgRow.Cells[7].Value == DBNull.Value ? "" : dgRow.Cells[7].Value);
                command.CommandText = "INSERT INTO tbSelen(Name,UserName,Valu,Link,Status,Selec,Type) values ([Name],[userName],[Value],[Link],[Status],[Selector],[Type]);";
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công");
                showData();
                connection.Close();
                //edit - this needs to run or you will have duplicate values inserted
                command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error   " + ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)

        {

            if (dbSele.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                if (MessageBox.Show("Có muốn xóa ?", "DataGridView", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (OleDbConnection oldCon = new OleDbConnection(conString))
                    {
                        DataGridViewRow dgRow = dbSele.CurrentRow;
                        OleDbCommand command = new OleDbCommand("", oldCon);
                        command.Parameters.AddWithValue("STT1", dgRow.Cells[0].Value == DBNull.Value ? "" : dgRow.Cells[0].Value);
                        command.CommandText = "DELETE *FROM tbSelen where STT= [STT1] ;";
                        oldCon.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công");
                    }
                }

            }
            else
                MessageBox.Show("Lỗi");
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\dbSe.mdb; Persist Security Info = False; ");
                OleDbCommand command = new OleDbCommand("", connection);
                DataGridViewRow dgRow = dbSele.CurrentRow;
                command.Parameters.AddWithValue("Name", dgRow.Cells[1].Value == DBNull.Value ? "" : dgRow.Cells[1].Value);
                command.Parameters.AddWithValue("userName", dgRow.Cells[2].Value == DBNull.Value ? "" : dgRow.Cells[2].Value);
                command.Parameters.AddWithValue("Value", dgRow.Cells[3].Value == DBNull.Value ? "" : dgRow.Cells[3].Value);
                command.Parameters.AddWithValue("Link", dgRow.Cells[4].Value == DBNull.Value ? "" : dgRow.Cells[4].Value);
                command.Parameters.AddWithValue("Status", dgRow.Cells[5].Value == DBNull.Value ? "" : dgRow.Cells[5].Value);
                command.Parameters.AddWithValue("Selector", dgRow.Cells[6].Value == DBNull.Value ? "" : dgRow.Cells[6].Value);
                command.Parameters.AddWithValue("Type", dgRow.Cells[7].Value == DBNull.Value ? "" : dgRow.Cells[7].Value);

                command.CommandText = "UPDATE tbSelen SET tbSelen.Name = @Name,tbSelen.UserName = @userName, tbSelen.Valu = @Value,tbSelen.Link = @Link,tbSelen.Status = @Status,tbSelen.Selec = @Selec,tbSelen.Type = @Type ;";
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công");
                showData();
                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error   " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            showData();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            /*  selectorUpLoadFile();*/
            selectorCreateFile();


        }


        void ConnectToAccess()
        {
            using
                (OleDbConnection oldCon = new OleDbConnection(conString))
            {
                oldCon.Open();
                showData();
            }
        }

        void showData()
        {
            using
                  (OleDbConnection oldCon = new OleDbConnection(conString))
            {
                oldCon.Open();
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("SELECT *FROM tbSeLen", oldCon);
                DataTable dt = new DataTable();
                oleDbDataAdapter.Fill(dt);
                dbSele.DataSource = dt;
            }
        }

        void fill_combo()
        {

            using
                  (OleDbConnection oldCon = new OleDbConnection(conString))
            {
                oldCon.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT *FROM tbSeLen", oldCon);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboSele.DataSource = dt;
                comboSele.DisplayMember = "tbSelen";
                comboSele.ValueMember = "Name" + "";




            }

        }


        void selectorUpLoadFile()
        {
            ///navtigate to 1 url website
            ChromeDriver chromeDriver = new ChromeDriver();

            string[] filesPath = Directory.GetFiles(path);
            try
            {

                OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\dbSe.mdb; Persist Security Info = False; ");
                OleDbCommand command = new OleDbCommand("", connection);
                DataGridViewRow dgRow = dbSele.CurrentRow;


                chromeDriver.Url = (String)(dgRow.Cells[4].Value == DBNull.Value ? "" : dgRow.Cells[4].Value);
                chromeDriver.Manage().Window.Maximize();

                SetValue("#root > div > div > div > div > div > form > div > div:nth-child(2) > div:nth-child(1) > div > input", (String)(dgRow.Cells[2].Value == DBNull.Value ? "" : dgRow.Cells[2].Value));
                FindSelectTor(chromeDriver, _selector, _value, 1000);

                SetValue("#root > div > div > div > div > div > form > div > div:nth-child(3) > div:nth-child(1) > div > input", (String)(dgRow.Cells[3].Value == DBNull.Value ? "" : dgRow.Cells[3].Value));
                FindSelectTor(chromeDriver, _selector, _value, 1000);

               

                SetValue("#root > div > div > div > div > div > form > div > div:nth-child(4) > button", "");
                FindSelectTor(chromeDriver, _selector, _value, 2000);


                SetValue("/html/body/div[3]/div/div[2]/div/div[2]/button", "");
                FindXpath(chromeDriver, _selector, _value, 1000);

                /* chromeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div[2]/div[1]/span")).Click();
                                Thread.Sleep(1000);*/

                SetValue("//*[@id=\"root\"]/div[2]/div[1]/span", "");
                FindXpath(chromeDriver, _selector, _value, 1000);


                /*   chromeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div[2]/div[1]/div/div[2]/div/div[1]/div/a")).Click();
                   Thread.Sleep(1000);*/


                SetValue("//*[@id=\"root\"]/div[2]/div[1]/div/div[2]/div/div[1]/div/a", "");
                FindXpath(chromeDriver, _selector, _value, 1000);

                /* chromeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div[3]/div/div[1]/div/div[2]/div/ul/li[4]")).Click();
                 Thread.Sleep(1000);*/

                SetValue("//*[@id=\"root\"]/div[3]/div/div[1]/div/div[2]/div/ul/li[4]", "");
                FindXpath(chromeDriver, _selector, _value, 1000);
                foreach (var filename in filesPath)
                {

                    chromeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div[3]/div/div[2]/div[2]/div[1]/div/div/div/div/div[5]/div/div/div/div/div[5]/span[1]/button")).Click();
                    Thread.Sleep(3000);
                    /* kiểm tra ngày và tháng*/

                    chromeDriver.FindElement(By.XPath("/ html / body / div[5] / div / div / form / div[2] / div / div[1] / div / div")).Click();
                    Thread.Sleep(2000);




                    FileInfo info = new FileInfo(filename);
                    /*  lấy chuỗi ngày trong file */
                    string fileName = info.Name.ToString();
                    char[] kitu = new char[] { ' ', '-', '.' };
                    string[] fileCut = fileName.Split(kitu);

                    /*   lấy ngày trong file*/
                    string dayFile = fileCut[0];

                    /*lấy tháng trong file*/
                    string monthFile = fileCut[1];

                    /*lấy năm trong file*/
                    string yearFile = fileCut[2];

                    /*  lấy giá trị tháng trên website*/
                    string webMonth = chromeDriver.FindElement(By.ClassName("ant-picker-month-btn")).Text;

                    string[] webCut = webMonth.Split(kitu);
                    string monthWeb = webCut[1];

                    if (monthFile == monthWeb)
                    {

                        break;
                    }
                    else
                    {
                        int step = Convert.ToInt32(monthWeb) - Convert.ToInt32(monthFile);
                        for (int i = 0; i < step; i++)
                        {

                            chromeDriver.FindElement(By.ClassName("ant-picker-header-prev-btn")).Click();
                            Thread.Sleep(2000);
                        }


                        IWebElement el = chromeDriver.FindElement(By.ClassName("ant-picker-body"));
                        Thread.Sleep(1000);

                        List<IWebElement> colEl = new List<IWebElement>(el.FindElements(By.TagName("td")));

                        foreach (IWebElement cols in colEl)
                        {
                            if (cols.Text.Equals(dayFile))
                                cols.Click();

                        }
                        Thread.Sleep(3000);
                        /* lấy ngày từ datePicker*/
                        string day = chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-body > div > div > div > div:nth-child(1) > div > div > div > div.ant-picker.form-control.ant-picker-focused > div > input")).GetAttribute("value");
                        Thread.Sleep(1000);
                        MessageBox.Show(day);


                        /* truyền Id vào mã thực đơn*//*
                        chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-body > div > div > div > div:nth-child(2) > div > div > input")).SendKeys(Id1);*/

                        SetValue("body > div.fade.modal.show > div > div > form > div.modal-body > div > div > div > div:nth-child(2) > div > div > input", day);
                        FindSelectTor(chromeDriver, _selector, _value, 1000);


                    }
                    /* lấy ngày từ datePicker*/

                    string idFilePath = chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-body > div > div > div > div:nth-child(2) > div > div > input")).GetAttribute("value");




                    /*bấm vào buton upfile*/
                    IWebElement fileUp = chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-body > div > div > div > div.col-md-12 > div > div > div > div > div.input-group-btn > div"));      
                    fileUp.Click();


                    /*  kiểm tra giá trị của Type*/
                    int value = Convert.ToInt32(dgRow.Cells[7].Value == DBNull.Value ? "" : dgRow.Cells[7].Value);

                    switch (value)
                    {


                        case 1:

                          /*  autoIT.WinActivate("File");*/
                            DateTime d = DateTime.Parse(idFilePath);
                            string pathFile = "D:\\FRE\\Cai_FRE\\Report\\FK\\" + d.ToString("d.M.yyy") + "-sang" + ".csv";
                         

                            chromeDriver.FindElement(By.Id("csvFileInput")).SendKeys("D:\\FRE\\Cai_FRE\\Report\\FK\\1.6.2023-sang.csv");
                            Thread.Sleep(2000);


                            SetValue("/html/body/div[6]/div/div[6]/button[1]", "");
                            FindXpath(chromeDriver, _selector, _value, 2000);


                            SetValue("/html/body/div[4]/div/div/form/div[3]/button[1]", "");
                            FindXpath(chromeDriver, _selector, _value, 2000);


                            SetValue("/html/body/div[6]/div/div[6]/button[1]", "");
                            FindXpath(chromeDriver, _selector, _value, 2000);


         
                            chromeDriver.Navigate();
                            chromeDriver.Navigate().Refresh();
                            Thread.Sleep(2000);
                            break;


                        /*  nếu type = 2 thì import file chieu*/
                        case 2:
                            autoIT.WinActivate("File");
                            DateTime d1 = DateTime.Parse(idFilePath);
                            autoIT.Send("D:\\FRE\\Cai_FRE\\Report\\FK\\" + d1.ToString("dd.MM.yyy") + "-chieu " + ".csv");
                            Thread.Sleep(1000);
                            autoIT.Send("{ENTER}");
                            Thread.Sleep(1000);
                            chromeDriver.FindElement(By.XPath("/ html / body / div[4] / div / div / form / div[3] / button[1]")).Click();
                            Thread.Sleep(1000);
                            chromeDriver.FindElement(By.XPath("/ html/body/div[6]/div/div[6]/button[1]")).Click();
                            chromeDriver.Navigate();
                            Thread.Sleep(2000);
                            MessageBox.Show("Trưa");
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error   " + ex.Message);
            }

        }





        void selectorCreateFile()
        {
            IWebDriver chromeDriver = new ChromeDriver(@"D:\Selenium bot\Selenium bot\Driver\chromedriver.exe");
            string[] filesPath = Directory.GetFiles(path);
            try
            {
                OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\Selenium bot\Selenium bot\Database\dbSe.mdb; Persist Security Info = False; ");
                OleDbCommand command = new OleDbCommand("", connection);

                DataGridViewRow dgRow = dbSele.CurrentRow;


                chromeDriver.Url = "https://v2.sc.edu.vn/login";
                chromeDriver.Manage().Window.Maximize();
                chromeDriver.FindElement(By.CssSelector("#root > div > div > div > div > div > form > div > div:nth-child(2) > div:nth-child(1) > div > input")).SendKeys((String)(dgRow.Cells[1].Value == DBNull.Value ? "" : dgRow.Cells[2].Value));

                chromeDriver.FindElement(By.CssSelector("#root > div > div > div > div > div > form > div > div:nth-child(3) > div:nth-child(1) > div > input")).SendKeys((String)(dgRow.Cells[2].Value == DBNull.Value ? "" : dgRow.Cells[3].Value));


                chromeDriver.FindElement(By.CssSelector("#root > div > div > div > div > div > form > div > div:nth-child(4) > button")).Click();
                Thread.Sleep(2000);


                chromeDriver.FindElement(By.XPath(" /html/body/div[3]/div/div[2]/div/div[2]/button")).Click();
                Thread.Sleep(2000);
                chromeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div[2]/div[1]/span")).Click();
                Thread.Sleep(1000);
                chromeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div[2]/div[1]/div/div[2]/div/div[1]/div/a")).Click();
                Thread.Sleep(1000);
                chromeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div[3]/div/div[1]/div/div[2]/div/ul/li[4]")).Click();
                Thread.Sleep(1000);



                foreach (var filename in filesPath)
                {

                    chromeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div[3]/div/div[2]/div[2]/div[1]/div/div/div/div/div[5]/div/div/div/div/div[2]/span[1]/button")).Click();
                    Thread.Sleep(1000);
                    /* kiểm tra ngày và tháng*/






                    FileInfo info = new FileInfo(filename);
                    /*  lấy chuỗi ngày trong file */
                    string fileName = info.Name.ToString();
                    char[] kitu = new char[] { ' ', '-', '.' };
                    string[] fileCut = fileName.Split(kitu);


                    /*   lấy ngày trong file*/
                    string dayFile = fileCut[0];

                    /*lấy tháng trong file*/
                    string monthFile = fileCut[1];

                    /*lấy năm trong file*/
                    string yearFile = fileCut[2];

                    string buoiFile = fileCut[3];


                    chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-body > div > div:nth-child(2) > div > div")).Click();
                    Thread.Sleep(2000);


                    if (buoiFile == "sang")
                    {


                        chromeDriver.FindElement(By.XPath("/html/body/div[6]/div/div/div/div[2]/div[1]/div/div/div[2]/div")).Click();
                        Thread.Sleep(1000);

                    }
                    else
                    {
                        chromeDriver.FindElement(By.XPath("/html/body/div[5]/div/div/div/div[2]/div[1]/div/div/div[1]/div")).Click();
                        Thread.Sleep(1000);
                    }


                    chromeDriver.FindElement(By.XPath("/ html / body / div[5] / div / div / form / div[2] / div / div[1] / div / div")).Click();
                    Thread.Sleep(2000);
                    /*   lấy giá trị tháng trên website*/
                    string webMonth = chromeDriver.FindElement(By.XPath("/html/body/div[7]/div/div/div/div/div[1]/div[1]/div/button[1]")).Text;

                    string[] webCut = webMonth.Split(kitu);
                    string monthWeb = webCut[1];

                    if (monthFile == monthWeb)
                    {

                        break;
                    }
                    else
                    {
                        int step = Convert.ToInt32(monthWeb) - Convert.ToInt32(monthFile);
                        for (int i = 0; i < step; i++)
                        {

                            chromeDriver.FindElement(By.XPath("/html/body/div[7]/div/div/div/div/div[1]/div[1]/button[2]")).Click();
                            Thread.Sleep(2000);
                        }

                 /*       string e = chromeDriver.FindElement(By.ClassName("ant-picker-content")).Text;
                        MessageBox.Show(e);*/


                        IWebElement el = chromeDriver.FindElement(By.ClassName("ant-picker-content"));
                        Thread.Sleep(1000);

                        List<IWebElement> colEl = new List<IWebElement>(el.FindElements(By.TagName("td")));

                        foreach (IWebElement cols in colEl)
                        {
                            if (cols.Text.Equals(dayFile))
                                cols.Click();
                              
                        }
                        Thread.Sleep(2000);
                        /* lấy ngày từ datePicker*/
                        string maTD = chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-body > div > div:nth-child(1) > div > div > div > input")).GetAttribute("value");
                        Thread.Sleep(2000);

                        /* truyền Id vào mã thực đơn*/
                        chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-body > div > div:nth-child(3) > div > input")).SendKeys(maTD);


                        CSVThucDon objcSVThucDon = new CSVThucDon();
                        string input = System.IO.File.ReadAllText(@"D:\test.json").Trim();
                        input = input.Remove(0, 1);
                        input = input.Remove(input.Length - 1, 1);
                        objcSVThucDon = JsonConvert.DeserializeObject<CSVThucDon>(input);



                        int siSo = objcSVThucDon.Siso;
                        double tienMotTre = objcSVThucDon.Tienmottre;
                        string buaSang = objcSVThucDon.Buasang;




                        string siSoWeb = Convert.ToString(siSo);
                        string tienMotTreWeb = Convert.ToString(tienMotTre);



                        chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-body > div > div:nth-child(4) > div > input")).SendKeys(siSoWeb);
                        Thread.Sleep(1000);

                        chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-body > div > div:nth-child(5) > div > input")).SendKeys(tienMotTreWeb);
                        Thread.Sleep(1000);

                        chromeDriver.FindElement(By.CssSelector("body > div.fade.modal.show > div > div > form > div.modal-footer > button.btn.btn-xs.btn-primary.bg-primary-800.btn-labeled")).Click();
                        Thread.Sleep(3000);

                        chromeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div[3]/div/div[2]/div[2]/div[3]/div/div/div[1]/div[2]/div/div/div[1]/div/div")).Click();
                        Thread.Sleep(2000);

          


                        chromeDriver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/div[1]/div/div/div[2]/div")).Click();
                        Thread.Sleep(2000);

                        if (objcSVThucDon.ChiTietThucDons.Count > 0)
                            foreach (CSVCTThucDon objCSVCTThucDon in objcSVThucDon.ChiTietThucDons)
                            {

                       
                                string tt = objCSVCTThucDon.Tentat;
                                /*truyền tên tắt*/
                                chromeDriver.FindElement(By.CssSelector("#rc_select_0")).SendKeys(tt);
                            
                                chromeDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div[2]/div[1]/div/div/div[2]/div/div/div[1]")).Click() ;
                            /*    col - md - 2
                                string te = chromeDriver.FindElement(By.ClassName("rc-virtual-list-holder")).Text;
                                MessageBox.Show(te);*/
                                Thread.Sleep(3000);



                                /*truyền SL(G) */
                                string sLGram = objCSVCTThucDon.Soluonggam.ToString();


                                for (int i = 0; i < objCSVCTThucDon.Tentat.Length; i++)
                                {
                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[1]/div/div/div/table/tbody/tr[" + i + "]/td[3]")).Click();
                                    Thread.Sleep(1000);
                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[5]/textarea")).SendKeys(sLGram);
                                    Thread.Sleep(1000);



                                    /*truyền DVT */
                                    string dvT = objCSVCTThucDon.Donvitinh;

                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[1]/div/div/div/table/tbody/tr[" + i + "]/td[4]")).Click();
                                    Thread.Sleep(1000);
                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[5]/textarea")).SendKeys(dvT);
                                    Thread.Sleep(1000);

                                    /*truyền SL(DVT) */
                                    string sLDVT = objCSVCTThucDon.Soluongkg.ToString();

                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[1]/div/div/div/table/tbody/tr[" + i + "]/td[5]")).Click();
                                    Thread.Sleep(1000);
                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[5]/textarea")).SendKeys(sLDVT);
                                    Thread.Sleep(1000);

                                    /*truyền thai bo */
                                    string thBo = objCSVCTThucDon.Hesothaibo.ToString();

                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[1]/div/div/div/table/tbody/tr[" + i + "]/td[6]")).Click();
                                    Thread.Sleep(1000);
                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[5]/textarea")).SendKeys(thBo);
                                    Thread.Sleep(1000);

                                    /*truyền thuc mua */
                                    string thucMua = objCSVCTThucDon.Soluongthucmua.ToString();

                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[1]/div/div/div/table/tbody/tr[" + i + "]/td[7]")).Click();
                                    Thread.Sleep(1000);
                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[5]/textarea")).SendKeys(thucMua);
                                    Thread.Sleep(1000);

                                    /*truyền gia tien */
                                    string giaTien = objCSVCTThucDon.Giatien.ToString();

                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[1]/div/div/div/table/tbody/tr[" + i + "]/td[8]")).Click();
                                    Thread.Sleep(1000);
                                    chromeDriver.FindElement(By.XPath("//*[@id=\"hot\"]/div[5]/textarea")).SendKeys(giaTien);
                                    Thread.Sleep(1000);

                                    chromeDriver.FindElement(By.XPath(" //*[@id=\"root\"]/div[3]/div/div[2]/div[2]/div[3]/div/div/div[1]/div[1]/div/div/div/div/div/div[4]/span[1]/button")).Click();
                                    Thread.Sleep(2000);







                                }








                            }



























































                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error   " + ex.Message);
            }
        }


        private void SetValue(string selector, string value)
        {
            try
            {
                _selector = selector;
                _value = value;

            }
            catch
            { }
        }
        private void FindSelectTor(ChromeDriver chd, string selector, string value, int milisecond)
        {
            if (!String.IsNullOrEmpty(value))
            {

                chd.FindElement(By.CssSelector(selector)).SendKeys(value);
            }
            else
                chd.FindElement(By.CssSelector(selector)).Click();
            Thread.Sleep(milisecond);
        }
        private void FindXpath(ChromeDriver chd, string xpath, string value, int milisecond)
        {
            if (!String.IsNullOrEmpty(value))
            {

                chd.FindElement(By.XPath(xpath)).SendKeys(value);
            }
            else
                chd.FindElement(By.XPath(xpath)).Click();
            Thread.Sleep(milisecond);
        }

        
    }


}

















