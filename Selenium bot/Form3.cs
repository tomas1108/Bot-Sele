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

using DevExpress.Utils;

namespace Selenium_bot
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            try
            {

                chromeDriver.Url = "https://qlmn.vn/";
                chromeDriver.Manage().Window.Maximize();
                chromeDriver.FindElement(By.XPath("//*[@id=\"username\"]")).SendKeys("hcm.demo1");


                
                chromeDriver.FindElement(By.XPath("//*[@id=\"password-mash\"]")).SendKeys("123456");


    
                IWebElement imageElement = chromeDriver.FindElement(By.XPath("//*[@id=\"img-captcha\"]"));

                Screenshot imageScreenshot = ((ITakesScreenshot)imageElement).GetScreenshot();

                string screenshotPath = "screenshot.png";

                imageScreenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

             



                File.Delete(screenshotPath);


                chromeDriver.FindElement(By.CssSelector("#root > div > div > div > div > div > form > div > div:nth-child(4) > button")).Click();
                Thread.Sleep(2000);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
