using System;
using System.Xml.Serialization;  // Does XML serializing for a class.
using System.IO;
using System.Collections.Generic;			     // Required for using Memory stream objects.

namespace HSD.Core.Domain
{
	/// <summary>
	/// Summary description for ThucDon.
	/// </summary>
	public class CSVThucDon
	{
        public CSVThucDon()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private int _mathucdon;
		public int Mathucdon
		{
			get{return _mathucdon;}
			set{_mathucdon=value;}
		}

		private string _tenthucdon;
		public string Tenthucdon
		{
			get{return _tenthucdon;}
			set{_tenthucdon=value;}
		}
        private int _chiase;
        public int Chiasethucdon
        {
            get { return _chiase; }
            set { _chiase = 0; }
        }
		private int _siso;
		public int Siso
		{
			get{return _siso;}
			set{_siso=value;}
		}
		private double _tiendinhmuc;
		public double Tiendinhmuc
		{
			get{return _tiendinhmuc;}
			set{_tiendinhmuc=value;}
		}
		private double _tienmottre;
		public double Tienmottre
		{
			get{return _tienmottre;}
			set{_tienmottre=value;}
		}
		
        //new
        private string _buasang;

        public string Buasang
        {
            get { return _buasang; }
            set { _buasang = value; }
        }
        private string _buatrua;

        public string Buatrua
        {
            get { return _buatrua; }
            set { _buatrua = value; }
        }
        private string _buaxe;

        public string Buaxe
        {
            get { return _buaxe; }
            set { _buaxe = value; }
        }
        private string _buaphu;

        public string Buaphu
        {
            get { return _buaphu; }
            set { _buaphu = value; }
        }
		private double _tongdamdv;
		public double Tongdamdv
		{
			get{return _tongdamdv;}
			set{_tongdamdv=value;}
		}
		private double _tongdamtv;
		public double Tongdamtv
		{
			get{return _tongdamtv;}
			set{_tongdamtv=value;}
		}
		private double _tongbeodv;
		public double Tongbeodv
		{
			get{return _tongbeodv;}
			set{_tongbeodv=value;}
		}
		private double _tongbeotv;
		public double Tongbeotv
		{
			get{return _tongbeotv;}
			set{_tongbeotv=value;}
		}
		private double _tongduong;
		public double Tongduong
		{
			get{return _tongduong;}
			set{_tongduong=value;}
		}
        private double _tongmuoi;
        public double Tongmuoi
        {
            get { return _tongmuoi; }
            set { _tongmuoi = value; }
        }
		private double _tongcalo;
		public double Tongcalo
		{
			get{return _tongcalo;}
			set{_tongcalo=value;}
		}
		private double _tongcanxi;
		public double Tongcanxi
		{
			get{return _tongcanxi;}
			set{_tongcanxi=value;}
		}
		private double _tongphotpho;
		public double Tongphotpho
		{
			get{return _tongphotpho;}
			set{_tongphotpho=value;}
		}
		private double _tongsat;
		public double Tongsat
		{
			get{return _tongsat;}
			set{_tongsat=value;}
		}
		private double _tongvitamina;
		public double Tongvitamina
		{
			get{return _tongvitamina;}
			set{_tongvitamina=value;}
		}
		private double _tongvitaminb1;
		public double Tongvitaminb1
		{
			get{return _tongvitaminb1;}
			set{_tongvitaminb1=value;}
		}
		private double _tongvitaminb2;
		public double Tongvitaminb2
		{
			get{return _tongvitaminb2;}
			set{_tongvitaminb2=value;}
		}
		private double _tongvitaminpp;
		public double Tongvitaminpp
		{
			get{return _tongvitaminpp;}
			set{_tongvitaminpp=value;}
		}
		private double _tongvitaminc;
		public double Tongvitaminc
		{
			get{return _tongvitaminc;}
			set{_tongvitaminc=value;}
		}
		
        public IList<CSVCTThucDon> ChiTietThucDons
        { get; set; }
        public IList<CSVDichVuThucDon> DichVuThucDons
        { get; set; }

	}
}
