using System;

namespace HSD.Core.Domain
{
	/// <summary>
	/// Summary description for DichVuThucDon.
	/// </summary>
	public class CSVDichVuThucDon
	{
        public CSVDichVuThucDon()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        private int _madichvuthucdon;
        public int Madichvuthucdon
		{
            get { return _madichvuthucdon; }
            set { _madichvuthucdon = value; }
		}
		
		private double _giatienmottre;
		public double Giatienmottre
		{
			get{return _giatienmottre;}
			set{_giatienmottre=value;}
		}
		private double _tongtienmotnhom;
		public double Tongtienmotnhom
		{
			get{return _tongtienmotnhom;}
			set{_tongtienmotnhom=0.0;}
        }
        private string _tenloaihinhdichvu;

        public string Tenloaihinhdichvu
        {
            get { return _tenloaihinhdichvu; }
            set { _tenloaihinhdichvu = value; }
        }
	}
}
