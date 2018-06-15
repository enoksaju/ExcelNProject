using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;

namespace ControlNominasAddIn.Forms {
	public class customKryptonPage : KryptonPage {
		private string _fullFilePath = null;

		public SQLPage _SQLPage { get; set; }
		public string SQLString {
			get { return _SQLPage.SQLString; }
			set { _SQLPage.SQLString = value; }
		}

		public object DataSource {
			get { return _SQLPage.GridView.DataSource; }
			set { _SQLPage.GridView.DataSource = value; }
		}

		public string fullFilePath {
			get { return _fullFilePath; }
			set {
				_fullFilePath = value;
				this.Text = System.IO.Path.GetFileNameWithoutExtension ( _fullFilePath );
			}
		}
		public void SaveToFile ( string fileName , Encoding enc ) {
			this._SQLPage.SaveToFile ( fileName , enc );
		}
		public void OpenFile ( string fileName , Encoding enc ) {
			this._SQLPage.OpenFile ( fileName , enc );
		}

		public bool ShowData {
			get {
				return _SQLPage.ShowData;
			}
			set {
				_SQLPage.ShowData = value;
			}
		}


		public customKryptonPage ( SQLPage _SQLPage ) {
			this._SQLPage = _SQLPage;
			if ( !this.Controls.Contains ( this._SQLPage ) ) {
				this._SQLPage.Dock = DockStyle.Fill;
				this.Controls.Add ( this._SQLPage );
			}
		}

	}
}
