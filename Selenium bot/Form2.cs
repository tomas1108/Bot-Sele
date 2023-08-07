using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSD.Core.Domain;
using Newtonsoft.Json;
using Selenium_bot;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Data.OleDb;
using System.Threading;
namespace Selenium_bot
{
    public partial class Form2 : Form
    {
        string path = "D:\\FRE\\Cai_FRE\\Report\\FK";

        public Form2()
        {
            InitializeComponent();
            CenterToScreen();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }




        private void btnRun_Click(object sender, EventArgs e)
        {
            selectorCreateFile();

        }



        void selectorCreateFile()
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            string[] filesPath = Directory.GetFiles(path);
            try
            {



                chromeDriver.Url = "https://v2.sc.edu.vn/login";
                chromeDriver.Manage().Window.Maximize();
                chromeDriver.FindElement(By.CssSelector("#root > div > div > div > div > div > form > div > div:nth-child(2) > div:nth-child(1) > div > input")).SendKeys("lopmamnonbaothu@gmail.com");

                chromeDriver.FindElement(By.CssSelector("#root > div > div > div > div > div > form > div > div:nth-child(3) > div:nth-child(1) > div > input")).SendKeys("123abc");


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
                        string input = System.IO.File.ReadAllText(@"D:\2.6.2023-sang.csv").Trim();
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

                                chromeDriver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div[2]/div[1]/div/div/div[2]/div/div/div[1]")).Click();
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



        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            Visible = false;
        }

      

       
    }
}



             
