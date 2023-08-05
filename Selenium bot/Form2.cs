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

namespace Selenium_bot
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

         public class ThucDon
    {
        public int maTD { get; set; }
        public string tenTD { get; set; }
        public int siSo { get; set; }
    }


        private void btnRun_Click(object sender, EventArgs e)
        {
            ReadJson();
        }



        void ReadJson()
        {
            CSVThucDon objcSVThucDon = new CSVThucDon();
            string input = System.IO.File.ReadAllText(@"D:\test.json").Trim();
            input = input.Remove(0, 1);
            input = input.Remove(input.Length - 1, 1);
            objcSVThucDon = JsonConvert.DeserializeObject<CSVThucDon>(input);

            if(objcSVThucDon.ChiTietThucDons.Count>0)
            foreach (CSVCTThucDon objCSVCTThucDon in objcSVThucDon.ChiTietThucDons)
                {
                    string tt = objCSVCTThucDon.Tentat;
                    
                }
            if (objcSVThucDon.DichVuThucDons.Count > 0)
                foreach (CSVDichVuThucDon objCSVDichVuThucDon in objcSVThucDon.DichVuThucDons)
                {

                }
         

        }









    }
}

